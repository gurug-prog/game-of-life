using System.Collections;

namespace GameOfLife.Model;

public sealed class ClassicUniverse : IUniverse<
    ClassicGeneration,
    ClassicGameRules,
    ClassicCell>
{
    public ClassicUniverse(
        ClassicGeneration initialGeneration)
    {
        throw new NotImplementedException();
    }

    public ClassicGeneration Initial
    {
        get { throw new NotImplementedException(); }
    }

    public ClassicGameRules Rules
    {
        get { throw new NotImplementedException(); }
    }

    public IEnumerator<ClassicGeneration> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
