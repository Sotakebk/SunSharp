using SunSharp;
using SunSharp.Abstractions.Horizontal.Jumping;
using SunSharp.DerivedData;
using SunSharp.ObjectWrapper;

namespace ManualJobs.Tests
{
    public class JumpGraphTest : BaseManualTest
    {
        protected override void RunTest(ISunVoxLib lib)
        {
            var _description = BuildDescription();
            var _sunVox = new SunVox(lib);

            WriteLine("Loading SunVox project...");
            var slot = _sunVox.Slots[0];
            slot.Open();
            slot.RunInLock(() =>
            {
                slot.Load(Path.Join(Program.SunVoxProjectFolder, "jump_demo.sunvox"));
            });
            WriteLine("SunVox project loaded.");

            void Feedback(SunSharp.Abstractions.MessageType type, string message)
            {
                Console.WriteLine($"[{type}]{message}");
            }

            WriteLine("Building description and graph...");
            var songData = SongData.ReadSongData(slot);
            var graph = GraphBuilder.BuildJumpGraph(songData, _description, Feedback);
            var controller = new GraphController(slot, graph);
            WriteLine("Description and graph built.");

            WriteLine("Enumerating states.");
            foreach (var state in graph.States)
                WriteLine($"{state.Id}. {state.Name}");

            WriteLine("Enumerating transitions.");
            foreach (var transition in graph.Transitions)
                WriteLine($"{transition.Id}. {transition.Name} (from: \"{transition.FromStateId}\" to: \"{transition.ToStateId}\")");

            var allowedNames = graph.States.Select(s => s.Name);
            controller.Start(controller.GetState("I"));
            var input = string.Empty;
            do
            {
                WriteLine("Select a target state or type \"exit\" to stop");
                WriteLine($"Available states: {string.Join(", ", allowedNames)}");

                input = ReadLine();
                input = input?.Trim() ?? string.Empty;
                if (allowedNames.Contains(input))
                {
                    var targetState = controller.GetState(input);
                    controller.DirectGraphToState(targetState);
                }
            } while (string.Compare(input, "exit", true) != 0);

            slot.Close();
        }

        private static IGraphDescription BuildDescription()
        {
            var description = new SimpleGraphDescription();
            description.Name = "Example";
            var I = description.AddState("I", "State1", hasLoop: true);
            var ii = description.AddState("ii", "State2", hasLoop: true);
            var iii = description.AddState("iii", "State3", hasLoop: true);
            var IV = description.AddState("IV", "State4", hasLoop: true);
            var V = description.AddState("V", "State5", hasLoop: true);
            var vi = description.AddState("vi", "State6", hasLoop: true);
            var viio = description.AddState("viio", "State7", hasLoop: true);
            description.AddTransition("I-ii", I, ii);
            description.AddTransition("I-iii", I, iii);
            description.AddTransition("I-IV", I, IV);
            description.AddTransition("I-V", I, V);
            description.AddTransition("I-vi", I, vi);
            description.AddTransition("I-viio", I, viio);

            description.AddTransition("ii-V", ii, V);

            description.AddTransition("iii-vi", iii, vi);
            description.AddTransition("iii-IV", iii, IV);

            description.AddTransition("IV-ii", IV, ii);
            description.AddTransition("IV-V", IV, V);

            description.AddTransition("V-I", V, I);

            description.AddTransition("vi-IV", vi, IV);
            description.AddTransition("vi-ii", vi, ii);

            description.AddTransition("viio-I", viio, I);
            description.AddTransition("viio-V", viio, V);

            return description;
        }
    }
}
