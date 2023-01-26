using SunSharp;
using SunSharp.Abstractions.Horizontal.JumpGraph;
using SunSharp.DerivedData;
using SunSharp.ObjectWrapper;

namespace Examples.ExampleCode
{
    internal static class JumpGraphExample
    {
        private static IJumpGraphDescription BuildDescription()
        {
            var description = new SimpleJumpGraphDescription();
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

        public static void RunExample(ISunVoxLib lib)
        {
            using (var sv = new SunVox(lib))
            {
                DoWork(sv);
            }
        }

        private static void DoWork(SunVox sv)
        {
            var slot = sv.Slots[0];
            slot.Open();
            slot.RunInLock(() =>
            {
                slot.Load(@"ExampleProjects/jump_demo.sunvox");
            });

            void Feedback(SunSharp.Abstractions.MessageType type, string message)
            {
                Console.WriteLine($"[{type}]{message}");
            }

            var description = BuildDescription();
            var songData = SongData.ReadSongData(slot);
            var graph = JumpGraphBuilder.BuildJumpGraph(songData, description, Feedback);
            var controller = new JumpGraphController(slot, graph);

            Console.WriteLine("States:");
            foreach (var state in graph.States)
            {
                Console.WriteLine($"{state.Id}. {state.Name}");
            }

            Console.WriteLine("Transitions:");
            foreach (var transition in graph.Transitions)
            {
                Console.WriteLine($"{transition.Id}. {transition.Name} (from: \"{transition.FromStateId}\" to: \"{transition.ToStateId}\")");
            }

            var allowedNames = graph.States.Select(s => s.Name);
            controller.Start(controller.GetState("I"));
            string? input = string.Empty;
            do
            {
                Console.WriteLine("Select a target state or type \"exit\" to stop");
                Console.WriteLine($"Available states: {string.Join(", ", allowedNames)}");

                input = Console.ReadLine();
                input = input?.Trim() ?? string.Empty;
                if (allowedNames.Contains(input))
                {
                    var targetState = controller.GetState(input);
                    controller.DirectGraphToState(targetState);
                }
            } while (string.Compare(input, "exit", true) != 0);

            slot.Close();
        }
    }
}
