internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            PromptAndPrintUserChoiceForTODOList();
        }

        void PrintSelectedOption(string message)
        {
            Console.WriteLine("\nSelected option: " + message + "\n");
        }

        void PromptAndPrintUserChoiceForTODOList()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("What would you like to do? :)");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit\n");

            string userChoice = Console.ReadLine().ToUpper();

            if (userChoice?.Length > 0)
            {
                if (userChoice == "S")
                {
                    PrintSelectedOption("See all TODOs");
                }
                else if (userChoice == "A")
                {
                    PrintSelectedOption("Add a TODO");
                }
                else if (userChoice == "R")
                {
                    PrintSelectedOption("Remove a TODO");
                }
                else if (userChoice == "E")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice\n");
                }
            }
            else
            {
                Console.WriteLine("Did not provide input of valid length. Try again\n");
            }
        }
    }
}