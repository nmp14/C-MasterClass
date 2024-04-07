internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(new DateTime(2024, 3, 31));
        Console.WriteLine(DateTime.Now.ToUniversalTime());
        Console.WriteLine("\n");

        DateTime internationalPizzaDay2023 = new DateTime(2023, 3, 31);

        Console.WriteLine("Year is " + internationalPizzaDay2023.Year);
        Console.WriteLine("Month is " + internationalPizzaDay2023.Month);
        Console.WriteLine("Day is " + internationalPizzaDay2023.Day);
        Console.WriteLine("Day of the week is " + internationalPizzaDay2023.DayOfWeek);
        Console.WriteLine("\n");

        DateTime internationalPizzaDay2024 = internationalPizzaDay2023.AddYears(1);

        Console.WriteLine("Year is " + internationalPizzaDay2024.Year);
        Console.WriteLine("Month is " + internationalPizzaDay2024.Month);
        Console.WriteLine("Day is " + internationalPizzaDay2024.Day);
        Console.WriteLine("Day of the week is " + internationalPizzaDay2024.DayOfWeek);
        Console.WriteLine("\n");

        Rectangle rectangle = new Rectangle(5, 6);

        Console.WriteLine($"area of rectangle: {rectangle.Area()}");

        Console.ReadKey();
    }
}

class Rectangle
{
    // Has to be assigned value here, cant in constructor.
    // Cant be assigned result of method due to needing to know value at compile time, not run time.
    const int NumberOfSides = 4;
    // Can be assigned in constructor so does not need value here necessarily.
    readonly int NumberOfSidesReadOnly = 4;
    private readonly int _width;
    private readonly int _height;
    public Rectangle(int width, int height)
    {
        this._width = DefaultIfNonPositive(width, nameof(_width));
        this._height = DefaultIfNonPositive(height, nameof(_height));
    }

    private int DefaultIfNonPositive(int value, string name)
    {
        const int defaultValue = 1;

        if (value <= 0)
        {
            Console.WriteLine($"{name} cannot be non positive.");
            return defaultValue;
        }
        return value;
    }

    public int Area()
    {
        return this._width * this._height;
    }
}