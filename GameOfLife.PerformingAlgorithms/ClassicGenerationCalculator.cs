using GameOfLife.Model;

namespace GameOfLife.PerformingAlgorithms;
public class ClassicGenerationCalculator :
    GenerationCalculator<ClassicGeneration, ClassicGameRules, ClassicCell>
{
    public ClassicGenerationCalculator(
        IUniverse<ClassicGeneration, ClassicGameRules, ClassicCell> universe)
        : base(universe)
    {
    }

    public ClassicGenerationCalculator(
        IUniverse<ClassicGeneration, ClassicGameRules, ClassicCell> universe,
        bool allowConsoleLogging)
        : base(universe, allowConsoleLogging)
    {
    }
}
