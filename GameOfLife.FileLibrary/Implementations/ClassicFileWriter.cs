using GameOfLife.Model;

namespace GameOfLife.FileLibrary;

public sealed class ClassicFileWriter : IFileWriter<ClassicGeneration, ClassicCell>
{
    public void Write(string path, ClassicGeneration generation)
    {
        File.WriteAllText(path, generation.ToString());
    }
}
