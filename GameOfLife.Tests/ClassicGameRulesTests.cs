using GameOfLife.Model;
using GameOfLife.Model.Implementations;

namespace GameOfLife.Tests;

public class ClassicGameRulesTests
{
    [Fact]
    public void Apply_RulesToBlock_Result_ExpectedMathesActual()
    {
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                {  '.', '.', '.', '.' },
                {  '.', 'x', 'x', '.' },
                {  '.', 'x', 'x', '.' },
                {  '.', '.', '.', '.' },
            });

        var rules = ClassicGameRules.Instance;
        var actualGeneration = rules.Apply(ClassicSeed.Block);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Apply_RulesToBlinker_Result_ExpectedMathesActual()
    {
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                {  '.', '.', '.', '.', '.', },
                {  '.', '.', 'x', '.', '.', },
                {  '.', '.', 'x', '.', '.', },
                {  '.', '.', 'x', '.', '.', },
                {  '.', '.', '.', '.', '.', },
            });

        var rules = ClassicGameRules.Instance;
        var actualGeneration = rules.Apply(ClassicSeed.Blicker);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }

    [Fact]
    public void Apply_RulesToGlider10x10_Result_ExpectedMathesActual()
    {
        var expectedGeneration = new ClassicGeneration(
            new char[,]
            {
                {  '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                {  'x', '.', 'x', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', 'x', 'x', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', 'x', '.', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                {  '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            });

        var rules = ClassicGameRules.Instance;
        var actualGeneration = rules.Apply(ClassicSeed.Glider10x10);

        Assert.True(ClassicGeneration.Compare(
            expectedGeneration, actualGeneration));
    }
}
