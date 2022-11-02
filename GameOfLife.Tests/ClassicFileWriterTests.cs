using GameOfLife.FileLibrary;
using GameOfLife.Model;

namespace GameOfLife.Tests;

public class ClassicFileWriterTests
{
    [Fact]
    public void Write_FileInCurrentDirectory_Result_FileWasWritten()
    {
        const string FILE_PATH = "./saved-file.txt";
        IFileWriter<ClassicGeneration, ClassicCell> writer =
            new ClassicFileWriter();

        writer.Write(FILE_PATH, ClassicSeed.Blinker);

        Assert.True(File.Exists(FILE_PATH));
    }

    [Fact]
    public void Write_PathDoesNotExist_Throws_IOException()
    {
        const string FILE_PATH = "hey/\\\\/$//,!/**\"\\@@ /w/a# r u/ f!d/ing h/er/e??";
        IFileWriter<ClassicGeneration, ClassicCell> writer =
            new ClassicFileWriter();

        Assert.ThrowsAny<IOException>(
            () => writer.Write(FILE_PATH, ClassicSeed.Block));
    }
}
