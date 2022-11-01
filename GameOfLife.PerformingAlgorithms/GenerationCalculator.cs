using GameOfLife.Model;

namespace GameOfLife.PerformingAlgorithms;

public class GenerationCalculator<TGeneration, TRules, TCell>
    where TGeneration : IGeneration<TCell>
    where TRules : IGameRules<TGeneration, TCell>
{
    private readonly IUniverse<TGeneration, TRules, TCell> _universe;

    public bool AllowConsoleLogging { get; set; }

    public GenerationCalculator(IUniverse<TGeneration, TRules, TCell> universe)
    {
        _universe = universe ?? throw new ArgumentNullException(nameof(universe));
        AllowConsoleLogging = false;
    }

    public GenerationCalculator(
        IUniverse<TGeneration, TRules, TCell> universe,
        bool allowConsoleLogging)
    {
        _universe = universe ?? throw new ArgumentNullException(nameof(universe));
        AllowConsoleLogging = allowConsoleLogging;
    }

    public TGeneration Calculate(int count)
    {
        TGeneration calculatedGeneration = _universe.Initial;
        var iteration = 0;
        foreach (var generation in _universe.Take(count + 1))
        {
            if (AllowConsoleLogging)
            {
                LogGeneration(iteration, generation);
            }

            if (iteration == count)
            {
                calculatedGeneration = generation;
                break;
            }

            iteration++;
        }

        return calculatedGeneration;
    }

    private static void LogGeneration(int iteration, TGeneration generation)
    {
        Console.WriteLine($"Iteration {iteration}:");
        Console.WriteLine(generation);
        Console.WriteLine();
    }
}
