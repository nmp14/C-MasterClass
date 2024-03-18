internal class Program
{
    private static void Main(string[] args)
    {
        bool shouldExit = false;
        TodoManager todoManager = new TodoManager();

        do
        {
            string userInput = todoManager.PromptTodoChoices();

            switch(userInput.ToUpper())
            {
                case "S":
                    todoManager.ListAllTodos();
                    break;
                case "A":
                    todoManager.AddTodo();
                    break;
                case "R":
                    todoManager.RemoveTodo();
                    break;
                case "E":
                    shouldExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option! Try again.\n");
                    break;
            }


        } while (!shouldExit);
    }
}

public class TodoManager
{
    private List<string> TodoList = new List<string>();

    public string PromptTodoChoices()
    {
        Console.WriteLine("Hello!");
        Console.WriteLine("What would you like to do? :)");
        Console.WriteLine("[S]ee all TODOs");
        Console.WriteLine("[A]dd a TODO");
        Console.WriteLine("[R]emove a TODO");
        Console.WriteLine("[E]xit\n");

        string userInput = Console.ReadLine()!;

        return userInput;
    }

    public void AddTodo()
    {
        string todo;
        bool isUnique = true;

        do
        {
            Console.WriteLine("Please enter unique description");
            todo = Console.ReadLine();

            if (todo.Length == 0)
            {
                Console.WriteLine("\nThe description cannot be empty.\n");
                continue;
            }

            if (this.TodoList.Contains(todo))
            {
                Console.WriteLine("The description must be unique.\n");
                isUnique = false;
                continue;
            }

            break;
        } while (todo.Length == 0 || !isUnique);

        this.TodoList.Add(todo);
        Console.WriteLine($"TODO successfully added: {todo}\n");
    }

    public void RemoveTodo()
    {
        this.ListAllTodos();

        int count = this.TodoList.Count;

        if (count == 0) return;

        bool shouldRepeat = false;
        do
        {
            Console.WriteLine("Enter number of TODO you wish to remove");

            string idx = Console.ReadLine();

            if (idx.Length == 0)
            {
                Console.WriteLine("Selected index cannot be empty.");
                shouldRepeat = true;
                continue;
            }

            bool successfullyParsed = int.TryParse(idx, out int parsedIdx);

            if (!successfullyParsed)
            {
                Console.WriteLine("The given index is not valid.");
                shouldRepeat = true;
                continue;
            }

            if (parsedIdx > count || parsedIdx < 1)
            {
                Console.WriteLine("The given index is not valid. Out of range.");
                shouldRepeat = true;
                continue;
            }

            string todo = this.TodoList[parsedIdx - 1];
            this.TodoList.RemoveAt(parsedIdx - 1);

            Console.WriteLine($"TODO removed: {todo}\n");

            shouldRepeat = false;
        } while (shouldRepeat);
    }

    public void ListAllTodos()
    {
        int count = this.TodoList.Count;

        if (count < 1)
        {
            Console.WriteLine("\nNo TODOs have been added yet.\n");
            return;
        }

        Console.WriteLine("");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1}. {this.TodoList[i]}");
        }

        Console.WriteLine("");
    }
}