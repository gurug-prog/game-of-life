using GameOfLife.Model;
using GameOfLife.FileLibrary;
using GameOfLife.Model.Implementations;

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

        // must be configurated with
        // fileParser.Generation
        // and rules
        var universe = new ClassicUniverse(ClassicSeed.Glider10x10);
        var iteration = 0;

        foreach (var generation in universe.Take(fileParser.Count))
        {
            Console.WriteLine($"Generation: {iteration++}");
            Console.WriteLine(generation);
            Console.WriteLine();

            if (iteration == fileParser.Count)
            {
                var fileWriter = new ClassicFileWriter();
                fileWriter.Write(OUTPUT_FILE_PATH, generation);
            }
        }

        Console.WriteLine("Written generation:");
        Console.WriteLine(fileParser.Generation);
    }
}
