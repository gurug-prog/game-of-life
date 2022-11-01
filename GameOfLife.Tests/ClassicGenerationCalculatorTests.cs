using GameOfLife.Model;
using GameOfLife.Model.Implementations;
using GameOfLife.PerformingAlgorithms;

namespace GameOfLife.Tests;

public class ClassicGenerationCalculatorTests
{
    [Fact]
    public void Calculate_Block1Time_Result_BlockHasNotChanged()
    {
        const int generationCount = 1;
        var expectedGeneration = ClassicSeed.Block;
        var universe = new ClassicUniverse(ClassicSeed.Block);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_Block100Times_Result_BlockHasNotChanged()
    {
        const int generationCount = 100;
        var expectedGeneration = ClassicSeed.Block;
        var universe = new ClassicUniverse(ClassicSeed.Block);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_Blinker27Times_Result_BlinkerWasRotated()
    {
        const int generationCount = 27;
        var expectedGeneration = new ClassicGeneration(
            new char[,]
                {
                    {  '.', '.', '.', '.', '.', },
                    {  '.', '.', 'x', '.', '.', },
                    {  '.', '.', 'x', '.', '.', },
                    {  '.', '.', 'x', '.', '.', },
                    {  '.', '.', '.', '.', '.', },
                });
        var universe = new ClassicUniverse(ClassicSeed.Blinker);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_Blinker54Times_Result_BlinkerHasNotChanged()
    {
        const int generationCount = 54;
        var expectedGeneration = ClassicSeed.Blinker;
        var universe = new ClassicUniverse(ClassicSeed.Blinker);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }
}
