using System.Text;

namespace GameOfLife.FileLibrary;

public sealed class ClassicFileReader : IFileReader
{
    public string CountString { get; private set; }

    public string GenerationHeader { get; private set; }

    public string GenerationString { get; private set; }

    public ClassicFileReader()
    {
        CountString = string.Empty;
        GenerationHeader = string.Empty;
        GenerationString = string.Empty;
    }

    public void Read(string path)
    {
        var fileState = ClassicFileState.Count;
        var reader = new StreamReader(path);
        while (fileState != ClassicFileState.EOF)
        {
            switch (fileState)
            {
                case ClassicFileState.Count:
                    ReadCount(reader);
                    fileState = ClassicFileState.Header;
                    break;
                case ClassicFileState.Header:
                    ReadHeader(reader);
                    fileState = ClassicFileState.Matrix;
                    break;
                case ClassicFileState.Matrix:
                    ReadGeneration(reader);
                    fileState = ClassicFileState.EOF;
                    break;
                case ClassicFileState.EOF:
                    break;
                default:
                    throw new ArgumentException($"Unexpected " +
                        $"{nameof(fileState)} status value.");
            }
        }
    }

    private void ReadCount(StreamReader reader)
    {
        var str = reader.ReadLine();
        CountString = str ??
            throw new FormatException("File does not contain " +
            "count of generation to be calculated.");
    }

    private void ReadHeader(StreamReader reader)
    {
        var str = reader.ReadLine();
        GenerationHeader = str ??
            throw new FormatException("File does not contain " +
            "initial generation header.");
    }

    private void ReadGeneration(StreamReader reader)
    {
        var sb = new StringBuilder();
        var generationLine = reader.ReadLine();
        if (String.IsNullOrEmpty(generationLine))
        {
            throw new FormatException("File does not contain " +
            "generation matrix.");
        }

        while (generationLine != null)
        {
            sb.Append(generationLine);
            generationLine = reader.ReadLine();
            if (generationLine != null)
            {
                sb.Append(Environment.NewLine);
            }
        }

        GenerationString = sb.ToString();
    }
}
