using GameOfLife.FileLibrary;

namespace GameOfLife.Tests;

public class FileReaderTests
{
    [Fact]
    public void Read_EmptyFilepathIsSpecified_Throws_IOException()
    {
        const string path = "";
        IFileReader fileReader = new ClassicFileReader();

        Assert.Throws<IOException>(() => fileReader.Read(path));
    }

    [Fact]
    public void Read_BadFilepathIsSpecified_Throws_IOException()
    {
        const string path = "what !the f@$$ is it [a really --correc*t path???";
        IFileReader fileReader = new ClassicFileReader();

        Assert.Throws<IOException>(() => fileReader.Read(path));
    }

    [Fact]
    public void Read_FileHasNoRequiredInfo_Throws_FormatException()
    {
        const string path = "../Assets/test-file_no-required-info.txt";
        IFileReader fileReader = new ClassicFileReader();

        Assert.Throws<FormatException>(() => fileReader.Read(path));
    }

    [Fact]
    public void Read_FileIsEmpty_Throws_FormatException()
    {
        const string path = "../Assets/empty-file.txt";
        IFileReader fileReader = new ClassicFileReader();

        Assert.Throws<IOException>(() => fileReader.Read(path));
    }

    [Fact]
    public void Read_CorrectFilePathIsSpecified_Returns_NonEmptyValues()
    {
        const string path = "../Assets/glider.txt";
        IFileReader fileReader = new ClassicFileReader();

        fileReader.Read(path);
        
        Assert.False(String.IsNullOrEmpty(fileReader.CountString));
        Assert.False(String.IsNullOrEmpty(fileReader.GenerationHeader));
        Assert.False(String.IsNullOrEmpty(fileReader.GenerationString));
    }
}
