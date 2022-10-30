using GameOfLife.Model;

namespace GameOfLife.FileLibrary;

public interface IFileParser<TGeneration, TCell>
    where TGeneration : IGeneration<TCell>
{
    // 
    // Summary:
    //     Parses the info contained in the fileReader.
    void Parse(IFileReader fileReader);
    //
    // Summary:
    //     Count of generations to be calculated.
    //
    // Returns:
    //     Integer value of generations.
    int Count { get; }
    //
    // Summary:
    //     The generation build from the file.
    //
    // Returns:
    //     The generation to which the calculations
    //     may be applied.
    TGeneration Generation { get; }
}
