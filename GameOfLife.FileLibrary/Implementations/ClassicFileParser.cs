using GameOfLife.Model;

namespace GameOfLife.FileLibrary;

public sealed class ClassicFileParser : IFileParser<ClassicGeneration, ClassicCell>
{
    public int Count => throw new NotImplementedException();

    public ClassicGeneration Generation => throw new NotImplementedException();

    public void Parse(IFileReader fileReader)
    {
        throw new NotImplementedException();
    }
}
