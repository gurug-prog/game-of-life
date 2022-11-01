using GameOfLife.FileLibrary;
using GameOfLife.Model;

namespace GameOfLife.Tests;

public class ClassicFileParserTests
{
    [Fact]
    public void ParseFromUnusedReader_Throws_FormatException()
    {
        IFileReader fileReader = new ClassicFileReader();

        var act = () =>
        {
            var parser = new ClassicFileParser();
            parser.Parse(fileReader);
        };

        Assert.Throws<FormatException>(act);
    }

    [Fact]
    public void Parse_FileContainsBadGenerationsCount_Throws_FormatException()
    {
        const string FILE_PATH = "../Assets/test-parser_incorrect-count.txt";
        IFileReader fileReader = new ClassicFileReader();
        fileReader.Read(FILE_PATH);

        var act = () =>
        {
            var parser = new ClassicFileParser();
            parser.Parse(fileReader);
        };

        Assert.Throws<FormatException>(act);
    }

    [Fact]
    public void Parse_FileContainsBadHeader_Throws_FormatException()
    {
        const string FILE_PATH = "../Assets/test-parser_incorrect-header.txt";
        IFileReader fileReader = new ClassicFileReader();
        fileReader.Read(FILE_PATH);

        var act = () =>
        {
            var parser = new ClassicFileParser();
            parser.Parse(fileReader);
        };

        Assert.Throws<FormatException>(act);
    }

    [Fact]
    public void Parse_FileContainsBadGameMatrix_Throws_FormatException()
    {
        const string FILE_PATH = "../Assets/test-parser_incorrect-matrix.txt";
        IFileReader fileReader = new ClassicFileReader();
        fileReader.Read(FILE_PATH);

        var act = () =>
        {
            var parser = new ClassicFileParser();
            parser.Parse(fileReader);
        };

        Assert.Throws<FormatException>(act);
    }

    [Fact]
    public void Parse_FileContainsGlider_ReturnsGlider()
    {
        ClassicGeneration expected = default!;
        const string FILE_PATH = "../Assets/glider.txt";
        IFileReader fileReader = new ClassicFileReader();
        fileReader.Read(FILE_PATH);

        var parser = new ClassicFileParser();
        parser.Parse(fileReader);

        Assert.Equal(expected, parser.Generation);
    }

    [Fact]
    public void Parse_FileContainsCount_5_CountEquals_5()
    {
        const int expected = 5;
        const string FILE_PATH = "../Assets/glider.txt";
        IFileReader fileReader = new ClassicFileReader();
        fileReader.Read(FILE_PATH);

        var parser = new ClassicFileParser();
        parser.Parse(fileReader);

        Assert.Equal(expected, parser.Count);
    }
}
