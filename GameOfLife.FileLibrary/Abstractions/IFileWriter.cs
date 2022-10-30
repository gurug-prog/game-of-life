using GameOfLife.Model;

namespace GameOfLife.FileLibrary;

public interface IFileWriter<TGeneration, TCell>
    where TGeneration : IGeneration<TCell>
{
    //
    // Summary:
    //     Writes the generation to a specified file path.
    void Write(string path, TGeneration generation);
}
