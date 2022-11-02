using GameOfLife.Model;
using GameOfLife.Model.Implementations;

namespace GameOfLife.FileLibrary;

public sealed class ClassicFileParser : IFileParser<ClassicGeneration, ClassicCell>
{
    public int Count { get; private set; }

    public ClassicGeneration? Generation { get; private set; }

    public void Parse(IFileReader fileReader)
    {
        ValidateFileReader(fileReader);
        Count = ValidateCount(fileReader);
        var (rows, columns) = ValidateDimensions(fileReader);
        Generation = ValidateGeneration(fileReader, rows, columns);
    }

    private static void ValidateFileReader(IFileReader fileReader)
    {
        var readerIsUnused =
            String.IsNullOrEmpty(fileReader.CountString) ||
            String.IsNullOrEmpty(fileReader.GenerationHeader) ||
            String.IsNullOrEmpty(fileReader.GenerationString);
        if (readerIsUnused)
        {
            throw new ArgumentException(
                $"The {nameof(fileReader)} is unused.");
        }
    }

    private static int ValidateCount(IFileReader fileReader)
    {
        var isCountCorrect = int.TryParse(fileReader.CountString, out var count);
        if (!isCountCorrect)
        {
            throw new FormatException("The count of generation " +
                $"has invalid value. Got: {fileReader.CountString} " +
                "expected positive integer instead.");
        }

        return count;
    }

    private static (int rows, int cols) ValidateDimensions(IFileReader fileReader)
    {
        int columns = 0, rows = 0;
        var delimiter = ' ';
        var dimensionsStrings =
            fileReader.GenerationHeader.Split(delimiter);

        var dimensionsIsCorrect =
            dimensionsStrings.Length == 2
            && int.TryParse(dimensionsStrings[0], out columns)
            && int.TryParse(dimensionsStrings[1], out rows);

        if (!dimensionsIsCorrect)
        {
            throw new FormatException("Wrong format of " +
                "classic game dimensions!");
        }

        return (rows, columns);
    }

    private static ClassicGeneration ValidateGeneration(
        IFileReader fileReader, int rows, int columns)
    {
        var matrix = fileReader.GenerationString;
        var lines = matrix.Split(Environment.NewLine);
        if (lines.Length != rows)
        {
            throw new FormatException("Header rows count does not " +
                $"match matrix rows count.");
        }

        var cellMatrix = new ClassicCell[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            var line = lines[i];
            if (line.Length != columns)
            {
                throw new FormatException("Header columns count does not " +
                    $"match matrix columns count.");
            }

            for (int j = 0; j < columns; j++)
            {
                var matrixSymbol = line[j];
                switch (matrixSymbol)
                {
                    case 'x':
                        cellMatrix[i, j] = ClassicCell.Alive;
                        break;
                    case '.':
                        cellMatrix[i, j] = ClassicCell.Dead;
                        break;
                    default:
                        throw new FormatException("Unexpected matrix " +
                            $"symbol: {matrixSymbol}");
                }
            }
        }

        return new ClassicGeneration(cellMatrix);
    }
}
