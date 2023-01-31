namespace Examples;

internal static partial class Program
{
    private static List<ExampleContainer> Options = new List<ExampleContainer>()
    {
        new ManualJobContainer<ThinWrapperPlaySong>("Thin wrapper - play a song"),
        new ManualJobContainer<ThinWrapperListModulesAndPatterns>("Thin wrapper - list modules and patterns"),
        new ManualJobContainer<ThinWrapperSendEvents>("Thin wrapper - send events"),
        new ManualJobContainer<ThinWrapperUserAudioCallback>("ThinWrapper - user audio callback"),
        new ManualJobContainer<ObjectWrapperPlaySong>("Object wrapper - play a song"),
        new ManualJobContainer<ObjectWrapperListModulesAndPatterns>("Object wrapper - list modules and patterns"),
        new ManualJobContainer<ObjectWrapperSendEvents>("Object wrapper - send events"),
        new ManualJobContainer<AbstractionHorizontalJumps>("Abstraction - horizontal jumps"),
    };

    private static void Main(string[] args)
    {
        Console.WriteLine($"Select an option:");
        for(int index = 0; index < Options.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {Options[index].Name}");
        }


        if (int.TryParse(Console.ReadLine(), out int number))
        {
            number--;
            if (number < 0 || number >= Options.Count)
                return;

            Options[number].Run();
        }
    }
}
