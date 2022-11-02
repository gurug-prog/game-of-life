using GameOfLife.Model;
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

    [Fact]
    public void Calculate_StillLife25Times_Result_PatternHasNotChanged()
    {
        const int generationCount = 25;
        var inputGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', 'x', '.', '.', '.', '.', },
                { '.', '.', '.', 'x', '.', 'x', '.', '.', '.', },
                { '.', '.', '.', 'x', '.', 'x', '.', '.', '.', },
                { '.', '.', '.', '.', 'x', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            });
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', 'x', '.', '.', '.', '.', },
                { '.', '.', '.', 'x', '.', 'x', '.', '.', '.', },
                { '.', '.', '.', 'x', '.', 'x', '.', '.', '.', },
                { '.', '.', '.', '.', 'x', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            });
        var universe = new ClassicUniverse(inputGeneration);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_Glider666Times_Result_PatternMatchesExpected()
    {
        const int generationCount = 666;
        var inputGeneration = ClassicSeed.Glider10x10;
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', 'x', '.', },
                { '.', '.', '.', '.', '.', '.', 'x', '.', 'x', '.', },
                { '.', '.', '.', '.', '.', '.', '.', 'x', 'x', '.', },
            });
        var universe = new ClassicUniverse(inputGeneration);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_GliderPeriodTimes_Result_PatternWasShiftedButStillLookLikeOriginal()
    {
        const int gliderPeriod = 4;
        var inputGeneration = ClassicSeed.Glider10x10;
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', 'x', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', 'x', '.', '.', '.', '.', '.', '.', },
                { '.', 'x', 'x', 'x', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            });
        var universe = new ClassicUniverse(inputGeneration);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(gliderPeriod);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_GliderInTheRightBottomCorner_Result_PatternCrossedTopOfTheMap()
    {
        const int generationCount = 1;
        var inputGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', 'x', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', 'x', },
                { '.', '.', '.', '.', '.', '.', '.', 'x', 'x', 'x', },
            });
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', 'x', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', '.', '.', 'x', '.', 'x', },
                { '.', '.', '.', '.', '.', '.', '.', '.', 'x', 'x', },
            });
        var universe = new ClassicUniverse(inputGeneration);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_BlinkerPusshedAtTheRightBorder_Result_BlinkerCrossedTheLeftBorder()
    {
        const int generationCount = 1;
        var inputGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', 'x', },
                { '.', '.', '.', '.', 'x', },
                { '.', '.', '.', '.', 'x', },
                { '.', '.', '.', '.', '.', },
            });
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', },
                { 'x', '.', '.', 'x', 'x', },
                { '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', },
            });
        var universe = new ClassicUniverse(inputGeneration);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Calculate_GliderCrossedMapCornerCase_Result_GliderCrumbledOverTheMap()
    {
        const int generationCount = 1;
        var inputGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', 'x', 'x', },
                { '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', },
                { '.', '.', 'x', '.', 'x', },
                { '.', '.', '.', '.', 'x', },
            });
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                { '.', '.', '.', 'x', 'x', },
                { '.', '.', '.', '.', '.', },
                { '.', '.', '.', '.', '.', },
                { '.', '.', '.', 'x', '.', },
                { 'x', '.', '.', '.', 'x', },
            });
        var universe = new ClassicUniverse(inputGeneration);
        var calculator = new ClassicGenerationCalculator(universe);

        var actualGeneration = calculator.Calculate(generationCount);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }
}
