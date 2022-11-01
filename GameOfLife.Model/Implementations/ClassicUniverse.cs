using System.Collections;

namespace GameOfLife.Model;

public sealed class ClassicUniverse : IUniverse<
    ClassicGeneration,
    ClassicGameRules,
    ClassicCell>
{
    public ClassicGeneration Initial { get; }

    public ClassicGameRules Rules => ClassicGameRules.Instance;

    public ClassicUniverse(
        ClassicGeneration initialGeneration)
    {
        Initial = initialGeneration ??
            throw new ArgumentNullException(nameof(initialGeneration));
    }

    public IEnumerator<ClassicGeneration> GetEnumerator()
    {
        var currentGeneration = Initial;

        while (true)
        {
            yield return currentGeneration;
            currentGeneration = Rules.Apply(currentGeneration);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
