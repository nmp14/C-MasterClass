internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        Calculator calc = new Calculator();

        try
        {
            Console.WriteLine("Please input first number: ");
            calc.FirstNum = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Please input second number: ");
            calc.SecondNum = int.Parse(Console.ReadLine()!);
        } catch (Exception ex)
        {
            if (ex is FormatException)
            {
                Console.WriteLine("Only numbers are valid!\r\n\n");
                Program.Exit(1);
            }
        }

        Console.WriteLine("What do you want to do with those numbers?\r\n[A]dd\r\n[S]ubtract\r\n[M]ultiply\r\n");
        string response = Console.ReadLine()!;

        // TODO: Division
        switch (response.ToLower())
        {
            case "a":
                calc.Add();
                break;
            case "m":
                calc.Multiply();
                break;
            case "s":
                calc.Subtract();
                break;
            default:
                Console.WriteLine("Invalid options.");
                break;
        }

        Program.Exit(2);
    }

    private static void Exit(int exitCode)
    {
        Console.WriteLine("Press any key to exit\r\n");
        Console.ReadKey();
        Environment.Exit(exitCode);
    }
}

public class Calculator
{
    private int firstNum = 0;
    private int secondNum = 0;

    public int FirstNum
    {
        set => firstNum = value;
    }

    public int SecondNum
    {
        set => secondNum = value;
    }

    public void Add()
    {
        int result = this.firstNum + this.secondNum;
        Console.WriteLine($"{this.firstNum} + {this.secondNum} = {result}");
    }

    public void Multiply()
    {
        int result = this.firstNum * this.secondNum;
        Console.WriteLine($"{this.firstNum} * {this.secondNum} = {result}");
    }

    public void Subtract()
    {
        int result = this.firstNum - this.secondNum;
        Console.WriteLine($"{this.firstNum} - {this.secondNum} = {result}");
    }
}