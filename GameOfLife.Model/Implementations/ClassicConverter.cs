using System.Text;

namespace GameOfLife.Model.Implementations;

public static class ClassicConverter
{
    public static ClassicCell[,] ConvertToCellMatrix(char[,] charMatrix)
    {
        var height = charMatrix.GetLength(0);
        var length = charMatrix.GetLength(0);
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
        var length = cellMatrix.GetLength(0);
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
        var length = charMatrix.GetLength(0);
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
        var length = cellMatrix.GetLength(0);
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
}
