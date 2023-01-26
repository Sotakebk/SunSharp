using SunSharp.DerivedData;
using SunSharp.ThinWrapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SunSharp.Abstractions.Horizontal.JumpGraph
{
    public static class JumpGraphBuilder
    {
        #region building

        public static JumpGraphData BuildJumpGraph(IReadOnlySongData songData, IJumpGraphDescription description, Action<MessageType, string> feedback = null)
        {
            var patterns = AnalyzePatterns(songData, feedback);
            var stacks = OrganizeStacks(patterns, feedback);
            var segments = SplitTimeline(stacks, description, feedback);
            var transitions = BuildTransitions(segments, patterns, feedback);
            var graph = ConstructGraph(segments, transitions, description, feedback);

            if (ValidateConstructedGraph(graph, description, feedback))
                throw new AbstractionBuildingException("Graph validation failed. Is the input data correct?");

            return graph;
        }

        #region pattern analysis

        private struct AnalyzedPattern
        {
            public int Id;
            public string Name;
            public int FirstLine;
            public int LastLine;
            public bool HasData;
            public (int from, int to)[] Jumps;
            public int[] Stops;

            public bool HasJumps => Jumps?.Any() ?? false;
            public bool HasStops => Stops?.Any() ?? false;
        }

        private static AnalyzedPattern[] AnalyzePatterns(IReadOnlySongData songData, Action<MessageType, string> feedback)
        {
            var analyzedPatterns = new List<AnalyzedPattern>(songData.Patterns.Count);
            foreach (var pattern in songData.Patterns)
            {
                var analzedPattern = AnalyzePattern(pattern, feedback);
                analyzedPatterns.Add(analzedPattern);
            }
            return analyzedPatterns.ToArray();
        }

        private static AnalyzedPattern AnalyzePattern(IReadOnlyPatternData patternData, Action<MessageType, string> feedback)
        {
            int CalculateJumpTargetLine(int currentLine, ReadOnlyEvent mode, ReadOnlyEvent jump)
            {
                switch (mode.XXYY)
                {
                    case 0: //0 - absolute address, relative to the start of the timeline(default)
                        return jump.XXYY;

                    case 1: //1 - (pattern beginning + address)
                        return patternData.Position.X + jump.XXYY;

                    case 2: //2 - (pattern beginning - address)
                        return patternData.Position.X - jump.XXYY;

                    case 3: //3 - (next line + address)
                        return patternData.Position.X + currentLine + 1 + jump.XXYY;

                    case 4: //4 - (next line - address);
                        return patternData.Position.X + currentLine + 1 - jump.XXYY;

                    default:
                        feedback?.Invoke(MessageType.Warning, $"Unknown jump type {mode.XXYY} at line {currentLine} of pattern \"{patternData.Name}\", assuming absolute address.");
                        return jump.XXYY;
                }
            }

            var hasNormalData = false;
            var jumps = new List<(int from, int to)>();
            var stops = new List<int>();

            var lines = patternData.Lines;
            var tracks = patternData.Tracks;
            if (!patternData.IsLinear)
            {
                for (int l = 0; l < lines; l++)
                {
                    ReadOnlyEvent? setJumpMode = null;
                    ReadOnlyEvent? jump = null;

                    for (int t = 0; t < tracks; t++)
                    {
                        var cEvent = patternData.Data.ElementAt(l * tracks + t);
                        if (cEvent.NN != 0 || cEvent.MM != 0 || cEvent.CC != 0)
                            hasNormalData = true;

                        if (cEvent.Effect == Effect.SetJumpMode)
                        {
                            if (setJumpMode != null)
                                feedback?.Invoke(MessageType.Warning, $"Line {l} of pattern \"{patternData.Name}\" (id:{patternData.Id}) has multiple jump mode setting effects.");
                            else
                                setJumpMode = cEvent;
                        }
                        if (cEvent.Effect == Effect.Jump)
                        {
                            if (jump != null)
                                feedback?.Invoke(MessageType.Warning, $"Line {l} of pattern \"{patternData.Name}\" (id:{patternData.Id}) has multiple jump effects.");
                            else
                                jump = cEvent;
                        }
                        if (cEvent.Effect == Effect.StopPlaying)
                        {
                            stops.Add(patternData.Position.X + l);
                        }
                    }
                    if (setJumpMode != null && jump != null)
                    {
                        jumps.Add((patternData.Position.X + l, CalculateJumpTargetLine(l, setJumpMode.Value, jump.Value)));
                    }
                    if ((setJumpMode == null && jump != null) || (setJumpMode != null && jump == null))
                    {
                        feedback?.Invoke(MessageType.Warning, $"Line {l} of pattern \"{patternData.Name}\" (id:{patternData.Id}) has malformed jump instruction. Both jump and jump mode setting effects must exist on the same line. Jump ignored!");
                    }
                }
            }

            var ap = new AnalyzedPattern()
            {
                FirstLine = patternData.Position.X,
                LastLine = patternData.Position.X + patternData.Lines - 1,
                Id = patternData.Id,
                Name = patternData.Name,
                HasData = hasNormalData,
                Jumps = jumps.ToArray(),
                Stops = stops.ToArray()
            };

            if (ap.HasData && ap.HasJumps)
            {
                feedback?.Invoke(MessageType.Warning, $"Pattern \"{patternData.Name}\" (id:{patternData.Id}) has both jumps and normal data, which may cause unexpected behaviour.");
            }

            if (patternData.IsDestructive)
            {
                feedback?.Invoke(MessageType.Info, $"Pattern \"{patternData.Name}\" (id:{patternData.Id}) has destructive effects, which may cause unexpected behaviour.");
            }

            if (ap.HasJumps && ap.HasStops)
            {
                feedback?.Invoke(MessageType.Error, $"Pattern \"{patternData.Name}\" (id:{patternData.Id}) has both jumps and stops, which may cause unexpected behaviour.");
                throw new AbstractionBuildingException($"Pattern \"{patternData.Name}\" (id:{patternData.Id}) has both jumps and stops, which may cause unexpected behaviour.");
            }

            if (ap.HasJumps && !jumps.Any(j => j.from == patternData.Position.X + patternData.Lines - 1))
            {
                feedback?.Invoke(MessageType.Warning, $"Pattern \"{patternData.Name}\" (id:{patternData.Id}) doesn't have any jumps on the final line, which may cause unexpected behaviour.");
            }

            if (ap.HasStops && !stops.Any(s => s == patternData.Position.X + patternData.Lines - 1))
            {
                feedback?.Invoke(MessageType.Warning, $"Pattern \"{patternData.Name}\" (id:{patternData.Id}) despite having stopping effects, doesn't have any stops on the final line, which may cause unexpected behaviour.");
            }

            return ap;
        }

        #endregion pattern analysis

        #region stack organisation

        private struct PatternStack
        {
            public int FirstLine;
            public int LastLine;
            public AnalyzedPattern[] Stack;
        }

        private static PatternStack[] OrganizeStacks(AnalyzedPattern[] analyzedPatterns, Action<MessageType, string> feedback = null)
        {
            var firstLine = analyzedPatterns.Min(p => p.FirstLine);
            var lastLine = analyzedPatterns.Max(p => p.LastLine);

            var leftEdges = analyzedPatterns.Select(p => p.FirstLine);
            var rightEdges = analyzedPatterns.Select(p => p.LastLine);
            var edges = leftEdges.Union(rightEdges).OrderBy(i => i).ToArray();

            var stacks = new List<PatternStack>();
            for (int i = 0; i < edges.Length - 1; i++)
            {
                var left = edges[i];
                var right = edges[i + 1];

                var stack = analyzedPatterns.Where(p => (left < p.LastLine) && (p.FirstLine < right)).ToArray();
                if (stack.Length != 0)
                    stacks.Add(new PatternStack() { FirstLine = left, LastLine = right, Stack = stack });
            }

            return stacks.ToArray();
        }

        #endregion stack organisation

        #region split timeline

        private enum SegmentType
        {
            Unknown,
            Known,
            Overlap
        }

        private class TimelineSegment
        {
            public string Name;
            public int FirstLine;
            public int LastLine;
            public SegmentType Type;
            public AnalyzedPattern? GuidePattern;
            public AnalyzedPattern[] Patterns;
        }

        private static TimelineSegment[] SplitTimeline(PatternStack[] stacks, IJumpGraphDescription description, Action<MessageType, string> feedback)
        {
            var sortedStacks = stacks.OrderBy(s => s.FirstLine).ToArray();
            var segments = new List<TimelineSegment>();
            var stateNames = description.DescribedStates.ToDictionary(s => s.GuideName, s => s.Name);

            int i = 0;
            TimelineSegment currentSegment = null;

            while (i < sortedStacks.Length)
            {
                var currentStack = sortedStacks[i];

                var names = currentStack.Stack.Where(p => stateNames.ContainsKey(p.Name)).Select(p => stateNames[p.Name]);

                var type = SegmentType.Unknown;
                if (names.Count() == 1)
                    type = SegmentType.Known;
                else if (names.Count() > 1)
                    type = SegmentType.Overlap;

                var segmentName = string.Empty;
                if (type == SegmentType.Known)
                    segmentName = names.First();
                else if (type == SegmentType.Unknown)
                    segmentName = "Unknown";
                else if (type == SegmentType.Overlap)
                    segmentName = $"Overlap ({string.Join(",", names)})";

                // merge the segments if possible
                if (currentSegment != null && type == currentSegment.Type && segmentName == currentSegment.Name && currentSegment.LastLine + 1 == stacks[i].FirstLine)
                {
                    currentSegment.LastLine = currentStack.LastLine;
                    currentSegment.Patterns = currentSegment.Patterns.Union(currentStack.Stack)
                                                                     .GroupBy(p => p.Id)
                                                                     .Select(g => g.First())
                                                                     .ToArray();
                }
                else
                {
                    currentSegment = new TimelineSegment()
                    {
                        FirstLine = currentStack.FirstLine,
                        LastLine = currentStack.LastLine,
                        Name = segmentName,
                        Patterns = currentStack.Stack,
                        Type = type,
                    };
                    if (type == SegmentType.Known)
                        currentSegment.GuidePattern = currentStack.Stack.First(p => stateNames.ContainsKey(p.Name));
                    segments.Add(currentSegment);
                }
                i++;
            }

            foreach (var segment in segments)
            {
                if (segment.Type == SegmentType.Overlap)
                    feedback?.Invoke(MessageType.Warning, $"{segment.Name} at lines {segment.FirstLine} to {segment.LastLine}.");
                if (segment.Type == SegmentType.Unknown)
                    feedback?.Invoke(MessageType.Warning, $"Unknown state at lines {segment.FirstLine} to {segment.LastLine}.");
            }

            var multipleSegments = segments.Where(s => s.Type == SegmentType.Known).GroupBy(s => s.Name);
            foreach (var group in multipleSegments)
            {
                if (group.Count() > 1)
                {
                    feedback?.Invoke(MessageType.Error, $"State \"{group.Key}\" occurs multiple times.");
                    throw new AbstractionBuildingException($"State \"{group.Key}\" occurs multiple times.");
                }
            }

            return segments.ToArray();
        }

        #endregion split timeline

        #region build transitions

        private class PreparedTransition
        {
            public TimelineSegment From;
            public TimelineSegment To;
            public bool HasJumps;
            public bool HasStops;
            public List<int> PatternIds;
        }

        private static PreparedTransition[] BuildTransitions(TimelineSegment[] segments, AnalyzedPattern[] patterns, Action<MessageType, string> feedback)
        {
            var transitions = new List<PreparedTransition>();

            TimelineSegment SegmentFromPosition(int i)
            {
                return segments.Where(s => s.FirstLine <= i && s.LastLine >= i).FirstOrDefault();
            }

            foreach (var pattern in patterns)
            {
                if (pattern.HasJumps)
                {
                    var segmentsFrom = pattern.Jumps.Select(j => SegmentFromPosition(j.from)).Distinct();
                    var segmentsTo = pattern.Jumps.Select(j => SegmentFromPosition(j.to)).Distinct();

                    if (segmentsFrom.Contains(null) || segmentsFrom.Any(s => s.Type == SegmentType.Unknown))
                    {
                        feedback?.Invoke(MessageType.Error, $"Transition pattern \"{pattern.Name}\" (id:{pattern.Id}) has jumps from an unknown state or silence. Pattern ignored!");
                        continue;
                    }

                    if (segmentsTo.Contains(null) || segmentsTo.Any(s => s.Type == SegmentType.Unknown))
                    {
                        feedback?.Invoke(MessageType.Error, $"Transition pattern \"{pattern.Name}\" (id:{pattern.Id}) has jumps to an unknown state or silence. Pattern ignored!");
                        continue;
                    }

                    if (segmentsFrom.Count() != 1)
                    {
                        feedback?.Invoke(MessageType.Error, $"Transition pattern \"{pattern.Name}\" (id:{pattern.Id}) has jumps from multiple states. Pattern ignored!");
                        continue;
                    }
                    if (segmentsTo.Count() != 1)
                    {
                        feedback?.Invoke(MessageType.Error, $"Transition pattern \"{pattern.Name}\" (id:{pattern.Id}) has jumps to multiple states. Pattern ignored!");
                        continue;
                    }

                    var segmentFrom = segmentsFrom.First();
                    var segmentTo = segmentsTo.First();

                    var existing = transitions.FirstOrDefault(t => t.From == segmentFrom && t.To == segmentTo && t.HasJumps == true && t.HasStops == false);

                    if (existing != null)
                        existing.PatternIds.Add(pattern.Id);
                    else
                    {
                        transitions.Add(new PreparedTransition()
                        {
                            From = segmentFrom,
                            To = segmentTo,
                            HasJumps = true,
                            PatternIds = new List<int>() { pattern.Id }
                        });
                    }
                }
                else if (pattern.HasStops)
                {
                    var segmentsIn = pattern.Stops.Select(s => SegmentFromPosition(s)).Distinct();
                    if (segmentsIn.Contains(null) || segmentsIn.Any(s => s.Type == SegmentType.Unknown))
                    {
                        feedback?.Invoke(MessageType.Error, $"Transition pattern \"{pattern.Name}\" (id:{pattern.Id}) has stops in unknown states. Pattern ignored!");
                        continue;
                    }
                    if (segmentsIn.Count() != 1)
                    {
                        feedback?.Invoke(MessageType.Error, $"Transition pattern \"{pattern.Name}\" (id:{pattern.Id}) has jumps in multiple states. Pattern ignored!");
                        continue;
                    }

                    var segmentIn = segmentsIn.First();
                    var existing = transitions.FirstOrDefault(t => t.From == segmentIn && t.To == segmentIn && t.HasJumps == false && t.HasStops == true);

                    if (existing != null)
                        existing.PatternIds.Add(pattern.Id);
                    else
                    {
                        transitions.Add(new PreparedTransition()
                        {
                            From = segmentIn,
                            To = segmentIn,
                            HasStops = true,
                            PatternIds = new List<int>() { pattern.Id }
                        });
                    }
                }
            }

            return transitions.ToArray();
        }

        #endregion build transitions

        #region construct graph

        private static JumpGraphData ConstructGraph(TimelineSegment[] segments, PreparedTransition[] transitions, IJumpGraphDescription description, Action<MessageType, string> feedback)
        {
            var _states = new List<JumpGraphStateData>();
            var _transitions = new List<JumpGraphTransitionData>();

            int _stateId = 1;
            foreach (var segment in segments)
            {
                if (segment.GuidePattern == null) // ignore overlaps and unknowns
                    continue;

                var newState = new JumpGraphStateData()
                {
                    Id = _stateId,
                    FirstLine = segment.FirstLine,
                    LastLine = segment.LastLine,
                    Name = segment.Name
                };
                _states.Add(newState);
                _stateId++;
            }

            int _transitionId = 1;
            foreach (var transition in transitions)
            {
                var newTransition = new JumpGraphTransitionData()
                {
                    Id = _transitionId,
                    Name = description.DescribedTransitions
                    .FirstOrDefault(dt => dt.From.Name == transition.From.Name && dt.To.Name == transition.To.Name)
                    ?.Name ?? $"(from \"{transition.From.Name}\" to \"{transition.To.Name}\")",
                    PatternIds = transition.PatternIds.ToArray(),
                    IsStopping = transition.HasStops,
                    FromStateId = _states.First(s => s.Name == transition.From.Name).Id,
                    ToStateId = _states.First(s => s.Name == transition.To.Name).Id
                };
                _transitions.Add(newTransition);
                _transitionId++;
            }

            var graph = new JumpGraphData()
            {
                Name = description.Name,
                States = _states.ToArray(),
                Transitions = _transitions.ToArray(),
                StartStateId = (description.StartState != null)
                                ? (int?)_states.FirstOrDefault(s => s.Name == description.StartState.Name).Id
                                : null
            };

            return graph;
        }

        #endregion construct graph

        #region validate constructed graph

        private static bool ValidateConstructedGraph(JumpGraphData graph, IJumpGraphDescription description, Action<MessageType, string> feedback)
        {
            foreach (var describedState in description.DescribedStates)
            {
                var state = graph.States.FirstOrDefault(s => s.Name == describedState.Name);
                if (state == null)
                {
                    feedback?.Invoke(MessageType.Error, $"Expected state \"{describedState.Name}\" was not found in built graph.");
                    return false;
                }
                if (describedState.HasLoop)
                {
                    var loopTransition = graph.Transitions.FirstOrDefault(t => t.FromStateId == state.Id && t.ToStateId == state.Id && t.IsStopping);
                    if (loopTransition == null)
                    {
                        feedback?.Invoke(MessageType.Error, $"Expected loop transition for state \"{describedState.Name}\" was not found in built graph.");
                        return false;
                    }
                }
                if (describedState.HasStop)
                {
                    var stopTransition = graph.Transitions.FirstOrDefault(t => t.FromStateId == state.Id && t.ToStateId == state.Id && t.IsStopping);
                    if (stopTransition == null)
                    {
                        feedback?.Invoke(MessageType.Error, $"Expected stop transition for state \"{describedState.Name}\" was not found in built graph.");
                        return false;
                    }
                }
            }

            foreach (var describedTransition in description.DescribedTransitions)
            {
                var transition = graph.Transitions.FirstOrDefault(t =>
                        graph.States.First(s => s.Id == t.FromStateId).Name == describedTransition.From.Name
                     && graph.States.First(s => s.Id == t.ToStateId).Name == describedTransition.To.Name);
                if (transition == null)
                    feedback?.Invoke(MessageType.Error, $"Expected transition \"{describedTransition.Name}\" was not found in built graph.");
                return false;
            }
            return true;
        }

        #endregion validate constructed graph

        #endregion building
    }
}
