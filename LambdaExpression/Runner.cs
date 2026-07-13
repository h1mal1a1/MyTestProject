using MyTestProject.LambdaExpression;

class Runner
{
    public static void RunTest1()
    {
        Task1 task = new();
        int a = 5;
        int b = 10;
        Console.WriteLine(task.Calculate(a, b, (x, y) => x + y));
        Console.WriteLine(task.Calculate(a, b, (x, y) => x - y));
        Console.WriteLine(task.Calculate(a, b, (x, y) => x * y));
        Console.WriteLine(task.Calculate(a, b, (x, y) => y / x));
    }
    public static void PrintTest2Products(string nameSort, IEnumerable<Task2.Product> products, Comparison<Task2.Product> sortFunc)
    {
        Console.WriteLine(nameSort);
        List<Task2.Product> sortList = [.. products];
        sortList.Sort(sortFunc);
        foreach (var product in sortList)
            Console.WriteLine($"{product.Name} - {product.Price} - {product.Stock}");
    }
    public static void RunTest2()
    {
        List<Task2.Product> products = [
            new Task2.Product("First", 100, 5),
            new Task2.Product("Second", 200, 4),
            new Task2.Product("Third", 300, 3),
            new Task2.Product("Fourth", 400, 2),
            new Task2.Product("Fifth", 600, 0),
            new Task2.Product("Fifth", 550, 0),
        ];

        PrintTest2Products("По цене по возрастанию.", products, (x, y) =>
            x.Price > y.Price ? 1 :
            y.Price > x.Price ? -1 :
            0
        );

        PrintTest2Products("По цене по убыванию.", products, (x, y) =>
            x.Price > y.Price ? -1 :
            y.Price > x.Price ? 1 :
            0
        );

        PrintTest2Products("По названию", products, (x, y) => x.Name.CompareTo(y.Name));
        PrintTest2Products("По количеству товара по возрастанию.", products, (x, y) => x.Stock.CompareTo(y.Stock));
        PrintTest2Products("Сначала товары в наличии, затем отсутствующие.", products, (x, y) => (y.Stock > 0).CompareTo(x.Stock > 0));
        PrintTest2Products("Сначала по наличию, а при одинаковом наличии — по цене", products, (x, y) =>
        {
            bool xInStock = x.Stock > 0;
            bool yInStock = y.Stock > 0;
            int availabilityInStock = yInStock.CompareTo(xInStock);
            return availabilityInStock != 0 ? availabilityInStock : x.Price.CompareTo(y.Price);
        });
    }
    public static void RunTest3()
    {
        IEnumerable<Task3.User> users = [
            new Task3.User("Name1", 20, true, "user"),
            new Task3.User("Name2", 18, false, "user"),
            new Task3.User("Name3", 16, true, "admin"),
            new Task3.User("Name4", 14, false, "user"),
            new Task3.User("Name5", 12, true, "admin"),
            new Task3.User("Name6", 10, false, "user"),
            new Task3.User("Name7", 8, true, "guest")
        ];
        var activeUsers = users.Where(x => x.IsActive);
        var adults = users.Where(x => x.Age > 17);
        var activeAdmins = users.Where(x => x.IsActive && string.Equals(x.Role, "admin"));
        var usersWithFirstAInName = users.Where(x => x.Name[0] == 'A');
        var lstFilter = users.Where(x => x.Age > 19 && x.Age < 30);
    }
    public static void RunTest4()
    {
        IEnumerable<Task3.User> users = [
            new Task3.User("Name1", 20, true, "user"),
            new Task3.User("Name2", 18, false, "user"),
            new Task3.User("Name3", 16, true, "admin"),
            new Task3.User("Name4", 14, false, "user"),
            new Task3.User("Name5", 12, true, "admin"),
            new Task3.User("Name6", 10, false, "user"),
            new Task3.User("Name7", 8, true, "guest")
        ];
        IEnumerable<string> usersInfo = users.Select(x => $"{x.Name}, {x.Age} лет, {x.Role}");
        IEnumerable<Task4.UserDto> usersDto = users.Select(x => new Task4.UserDto(x.Name, x.Age > 17));
    }
    public static void RunTest5()
    {
        Task5 task = new();
        Func<int> counter = task.CreateCounter();
        Console.WriteLine(counter());
        Console.WriteLine(counter());
        Console.WriteLine(counter());
    }
    public static void RunTest6()
    {
        Task5 task = new();
        Func<int> counter1 = task.CreateCounter();
        Func<int> counter2 = task.CreateCounter();
        Console.WriteLine(counter1());
        Console.WriteLine(counter1());
        Console.WriteLine(counter2());
        Console.WriteLine(counter1());
        Console.WriteLine(counter2());
        Console.WriteLine(counter2());
    }
    public static void RunTest7()
    {
        var actions = new List<Action>();
        for (int i = 0; i < 5; i++)
        {
            actions.Add(() => Console.WriteLine(i));
        }
        foreach (var action in actions)
            action.Invoke();
        var newActions = new List<Action>();
        for (int i = 0; i < 5; i++)
        {
            var counter = i;
            newActions.Add(() => Console.WriteLine(counter));
        }
        foreach (var action in newActions)
            action.Invoke();
    }
    public static void RunTest8()
    {
        Task8 task8 = new Task8();
        var validator = task8.CreateMinLemgthValidator(8);
        Console.WriteLine(validator.Invoke("hio"));
        var rangeValidator = task8.CreateRangeValidator(5, 10);
        Console.WriteLine(rangeValidator.Invoke(7));
    }
    public static void RunTest9()
    {
        Task9 task = new();
        Console.WriteLine(task.And<int>((x) => x > 0, (y) => y < 10).Invoke(5));
        Console.WriteLine(task.Or<int>((x) => x > 0, (y) => y < 10).Invoke(20));
        Console.WriteLine(task.Not<int>((x) => x > 0).Invoke(5));
    }
    public static void RunTest10()
    {
        List<Func<string, string>> processor = [
            (value) => value.Trim(),
            (value) => value.Replace("  ",""),
            (value) => value.ToUpper(),
            (value) => $"{DateTime.Now:yyyyMMdd}: {value}",
            (value) => $"MyPrefix: {value}"
        ];
        Func<string, string> result = processor.Aggregate((current, next) => value => next(current(value)));
        Console.WriteLine(result.Invoke("Hello WO  rld"));


    }
    //разобрать интерфейс ISorted
    public static void RunAllTests()
    {
        RunTest10();
    }
}