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
    private int width;
    private int height;
    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int Area()
    {
        return this.width * this.height;
    }
}