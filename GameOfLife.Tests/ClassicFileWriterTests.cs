using GameOfLife.FileLibrary;
using GameOfLife.Model;
using GameOfLife.Model.Implementations;

namespace GameOfLife.Tests;

public class ClassicFileWriterTests
{
    [Fact]
    public void Write_FileInCurrentDirectory_Result_FileWasWritten()
    {
        const string FILE_PATH = "./saved-file.txt";
        IFileWriter<ClassicGeneration, ClassicCell> writer =
            new ClassicFileWriter();

        writer.Write(FILE_PATH, ClassicSeed.Blicker);

        Assert.True(File.Exists(FILE_PATH));
    }

    [Fact]
    public void Write_PathDoesNotExist_Throws_IOException()
    {
        const string FILE_PATH = "hey, what r u finding here???";
        IFileWriter<ClassicGeneration, ClassicCell> writer =
            new ClassicFileWriter();

        Assert.Throws<IOException>(
            () => writer.Write(FILE_PATH, ClassicSeed.Block));
    }
}
