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

        var test = rectangle.Width;
        Console.WriteLine($"area of rectangle: {rectangle.Area()}");

        // Traditional way to make new instance of a class
        //var person = new Person("John", 1981);
        // Object initializer. Dont have to use all fields. Will use a default if not included.
        var person2 = new Person
        {
            Name = "John",
            YearOfBirth = 1981,
        };

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
    // Called backing fields.
    private int _height;
    public Rectangle(int width, int height)
    {
        Width = DefaultIfNonPositive(width, nameof(Width));
        _height = DefaultIfNonPositive(height, nameof(_height));
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

    // Modern way that is shorter if dont need special validation
    public int Width { get; private set; }

    // Traditional way to make get/set accessors in property. This is a property, while the _width is a field.
    //public int Width
    //{
    //    get { return _width; }
    //    set
    //    {
    //        if (value <= 0)
    //        {
    //            Console.WriteLine("Value must be greater than 0.");
    //            _width = 1;
    //        } else
    //        {
    //            _width = value;
    //        }
    //    }
    //}

    // Can also do
    //private int _width;
    //public int Width
    //{
    //    get => _width;
    //    set => _width = value;
    //}

    public int Area()
    {
        return Width * _height;
    }
}

// Fields vs properties
// Fields are like variables and properties are method-like
// Fields have single access modifier, properties have seperate accessor modifiers for getter and setter.
//Fields have no separate getter and setter while properties getter or setter can be removed
// Fields cannot be overriden in derived classes while properties can.
// Fields should always be private, properties can safely be public.

class Person
{
    public required string Name { get; set; }
    // Init allows to set value only in obj initializer but not after.
    public int YearOfBirth { get; init; }

    // Dont need constructor with obj initializer
    //public Person(string name, int yearOfBirth)
    //{
    //    Name = name;
    //    YearOfBirth = yearOfBirth;
    //}

    // Constructor requires all required parameters while initializer does not. Constructors are more commonly used.
}