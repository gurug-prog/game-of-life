using GameOfLife.Model.Implementations;
using System.Collections;

namespace GameOfLife.Model;

public sealed class ClassicGeneration : IGeneration<ClassicCell>
{
    public ClassicCell[,] Map { get; }
    public int Columns { get; }
    public int Rows { get; }

    public ClassicGeneration(ClassicCell[,] cellMatrix)
    {
        Map = cellMatrix ??
            throw new ArgumentNullException(nameof(cellMatrix));
        Rows = Map.GetLength(0);
        Columns = Map.GetLength(1);
    }

    public ClassicGeneration(char[,] charMatrix)
    {
        if (charMatrix == null)
            throw new ArgumentNullException(nameof(charMatrix));

        Map = ClassicConverter.ConvertToCellMatrix(charMatrix);
        Rows = Map.GetLength(0);
        Columns = Map.GetLength(1);
    }

    public static bool Compare(ClassicGeneration cg1, ClassicGeneration cg2)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<ClassicCell> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
