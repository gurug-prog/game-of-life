using System.Text;

namespace GameOfLife.Model;

public static class ClassicConverter
{
    public static ClassicCell[,] ConvertToCellMatrix(char[,] charMatrix)
    {
        var height = charMatrix.GetLength(0);
        var length = charMatrix.GetLength(1);
        var cellMatrix = new ClassicCell[height, length];
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < length; column++)
            {
                cellMatrix[row, column] =
                    charMatrix[row, column] == 'x'
                    ? ClassicCell.Alive
                    : ClassicCell.Dead;
            }
        }

        return cellMatrix;
    }

    public static char[,] ConvertToCharMatrix(ClassicCell[,] cellMatrix)
    {
        var height = cellMatrix.GetLength(0);
        var length = cellMatrix.GetLength(1);
        var charMatrix = new char[height, length];
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < length; column++)
            {
                charMatrix[row, column] =
                    cellMatrix[row, column] == ClassicCell.Alive
                    ? 'x'
                    : '.';
            }
        }

        return charMatrix;
    }

    public static string ConvertFromCharsToString(char[,] charMatrix)
    {
        var height = charMatrix.GetLength(0);
        var length = charMatrix.GetLength(1);
        var sb = new StringBuilder();
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < length; column++)
            {
                sb.Append(charMatrix[row, column]);
            }

            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }

    public static string ConvertFromCellsToString(ClassicCell[,] cellMatrix)
    {
        var height = cellMatrix.GetLength(0);
        var length = cellMatrix.GetLength(1);
        var sb = new StringBuilder();
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < length; column++)
            {
                sb.Append(
                    cellMatrix[row, column] == ClassicCell.Alive
                    ? 'x'
                    : '.');
            }

            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }

    public static ClassicCell[,] ConvertFromStringToCells(string matrix)
    {
        var rows = matrix.Split(Environment.NewLine);
        var cellMatrix = new ClassicCell[rows.Length, rows[0].Length];
        for (int i = 0; i < rows.Length; i++)
        {
            var row = rows[i];
            for (int j = 0; j < row.Length; j++)
            {
                cellMatrix[i, j] =
                    row[j] == 'x'
                    ? ClassicCell.Alive
                    : ClassicCell.Dead;
            }
        }

        return cellMatrix;
    }
}
