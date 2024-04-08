// A class should only have 1 responsibility. Part of SOLID
namespace SRP_SingleResponsibilityPrinciple
{
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
            Console.ReadKey();
        }
    }

    class NameValidator
    {
        public bool IsValid(string name)
        {
            return name.Length >= 2 &&
                name.Length < 25 &&
                char.IsUpper(name[0]) &&
                name.All(char.IsLetter);
        }
    }

    class Names
    {
        public List<string> All { get; } = new List<string>();
        private readonly NameValidator _nameValidator = new NameValidator();

        public void AddNames(List<string> stringsFromFile)
        {
            foreach(var name in stringsFromFile)
            {
                AddName(name);
            }
        }

        public void AddName(string name)
        {
            if (_nameValidator.IsValid(name))
            {
                All.Add(name);
            }
        }
    }

    class NamesFormatter
    {
        public string Format(List<string> names)
        {
            return string.Join(Environment.NewLine + "-----" + Environment.NewLine, names);
        }
    }

    class NamesFilePathBuilder
    {
        public string BuildFilePath()
        {
            return "names.txt";
        }
    }

    class StringsTextualRepository
    {
        private static readonly string Separator = Environment.NewLine;
        public List<string> Read(string filePath)
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(Separator).ToList();
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, string.Join(Separator, strings));
        }
    }
}
