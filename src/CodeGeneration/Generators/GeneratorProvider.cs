namespace CodeGeneration.Generators;

public interface IGeneratorProvider
{
    static abstract BaseGenerator[] GetGenerators();
}
