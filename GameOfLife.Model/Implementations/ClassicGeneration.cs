using System.Collections;

namespace GameOfLife.Model;

public sealed class ClassicGeneration : IGeneration<ClassicCell>
{
    public int Columns => throw new NotImplementedException();

    public int Rows => throw new NotImplementedException();

    public IEnumerator<ClassicCell> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
