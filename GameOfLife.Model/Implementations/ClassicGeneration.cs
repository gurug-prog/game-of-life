using GameOfLife.Model.Implementations;
using System.Collections;

namespace GameOfLife.Model;

public sealed class ClassicGeneration : IGeneration<ClassicCell>
{
    public ClassicCell[,] Map { get; }
    public int Columns => Map.GetLength(0);
    public int Rows => Map.GetLength(1);

    public ClassicGeneration(ClassicCell[,] cellMatrix)
    {
        Map = cellMatrix ??
            throw new ArgumentNullException(nameof(cellMatrix));
    }

    public ClassicGeneration(char[,] charMatrix)
    {
        if (charMatrix == null)
            throw new ArgumentNullException(nameof(charMatrix));

        Map = ClassicConverter.ConvertToCellMatrix(charMatrix);
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
