using System.Collections;

namespace GameOfLife.Model;

public sealed class ClassicGeneration : IGeneration<ClassicCell>
{
    public ClassicCell[,] Map { get; }
    public int Rows => Map.GetLength(0);
    public int Columns => Map.GetLength(1);

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
        var dimensionsAreNotMatching =
            cg1.Rows != cg2.Rows || cg1.Columns != cg2.Columns;
        if (dimensionsAreNotMatching)
        {
            return false;
        }

        for (int row = 0; row < cg1.Rows; row++)
        {
            for (int column = 0; column < cg1.Columns; column++)
            {
                if (cg1.Map[row, column] != cg2.Map[row, column])
                {
                    return false;
                }
            }
        }

        return true;
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

    public override string? ToString()
    {
        return ClassicConverter.ConvertFromCellsToString(Map);
    }
}
