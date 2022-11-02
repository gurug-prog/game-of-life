using GameOfLife.Model;
using GameOfLife.FileLibrary;
using GameOfLife.PerformingAlgorithms;

namespace GameOfLife.ConsoleHost;
public class Program
{
    public static void Main()
    {
        const string INPUT_FILE_PATH = "./input.txt";
        const string OUTPUT_FILE_PATH = "./output.txt";

        var fileReader = new ClassicFileReader();
        fileReader.Read(INPUT_FILE_PATH);

        var fileParser = new ClassicFileParser();
        fileParser.Parse(fileReader);

        var universe = new ClassicUniverse(fileParser.Generation!);
        var calculator = new ClassicGenerationCalculator(universe, true);
        var outputGeneration = calculator.Calculate(fileParser.Count);

        var fileWriter = new ClassicFileWriter();
        fileWriter.Write(OUTPUT_FILE_PATH, outputGeneration);

        Console.WriteLine("Written generation:");
        Console.WriteLine(outputGeneration);
    }
}
