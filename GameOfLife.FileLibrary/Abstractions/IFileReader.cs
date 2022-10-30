namespace GameOfLife.FileLibrary;

public interface IFileReader
{
    //
    // Summary:
    //     Reads the file by specified path.
    void Read(string path);
    //
    // Summary:
    //     Represents count of generations to be calculated.
    //
    // Returns:
    //     String containing info about generations count.
    string CountString { get; }
    //
    // Summary:
    //     Represents extra info about generation
    //     e.g. dimension, width, height.
    //
    // Returns:
    //     Header string.
    string GenerationHeader { get; }
    //
    // Summary:
    //     String containing info about the
    //     generation object that will be built.
    //
    // Returns:
    //     Plain text generation string.
    string GenerationString { get; }
}
