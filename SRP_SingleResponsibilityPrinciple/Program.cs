global using System.Diagnostics;
using SRP_SingleResponsibilityPrinciple.DataAccess;
using SRP_SingleResponsibilityPrinciple.Helpers;

// A class should only have 1 responsibility. Part of SOLID
namespace SRP_SingleResponsibilityPrinciple;

internal class Program
{
    static void Main(string[] args)
    {
        var names = new Names();
        var namesFilePathBuilder = new NamesFilePathBuilder();
        var path = namesFilePathBuilder.BuildFilePath();
        var stringsTextualRepository = new StringsTextualRepository();

        if (File.Exists(path))
        {
            Console.WriteLine("Names file already exists. Loading names");
            var stringsFromFile = stringsTextualRepository.Read(path);
            names.AddNames(stringsFromFile);
        }
        else
        {
            Console.WriteLine("Names file does not exist yet.");

            names.AddName("John");
            names.AddName("Not a valid name");
            names.AddName("Claire");
            names.AddName("123 definitely not a valid name");

            Console.WriteLine("Saving names to a file");

            stringsTextualRepository.Write(path, names.All);
        }
        Console.WriteLine(new NamesFormatter().Format(names.All));

        var stopWatch = Stopwatch.StartNew();

        for (int i = 0; i < 10000; i++)
        {
            Console.WriteLine($"Loop number {i}");
        }
        stopWatch.Stop();
        Console.WriteLine($"Time in seconds: {stopWatch.ElapsedMilliseconds/1000.0}");

        Console.ReadKey();
    }
}

