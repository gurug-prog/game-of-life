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
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                yield return Map[row, column];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
