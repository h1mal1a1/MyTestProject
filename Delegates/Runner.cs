namespace MyTestProject.Delegates;

public class Runner
{
    private static void RunTask1()
    {
        Task1 task1 = new();
        Console.WriteLine("Addition: " + task1.Calculate(10, 5, task1.Add));
        Console.WriteLine("Subtraction: " + task1.Calculate(10, 5, task1.Subtract));
        Console.WriteLine("Multiplication: " + task1.Calculate(10, 5, task1.Multiply));
        Console.WriteLine("Division: " + task1.Calculate(10, 5, task1.Divide));
    }
    private static void RunTask2()
    {
        Task2 task2 = new();
        Console.WriteLine("Upper Case: " + task2.ProcessString("hello world", value => value.ToUpper()));
        Console.WriteLine("Upper Case: " + task2.ProcessString("HELLO WORLD", value => value.ToLower()));
        Console.WriteLine("Upper Case: " + task2.ProcessString(" hello world ", value => value.Replace(" ", "")));
        Console.WriteLine("Upper Case: " + task2.ProcessString("hello world", value => $"Processed: {value}"));
    }
    private static void RunTask3()
    {
        Task3 task3 = new();
        task3.ConvertTo("124", value =>
        {
            if(int.TryParse(value, out int result))
                return result;
            throw new FormatException($"Строка '{value}' не является числом.");
        });

        task3.ConvertTo(245, value => Convert.ToString(value));
        task3.ConvertTo(new Task3.User("Alex"), value => new Task3.UserDto(value.Name));
        task3.ConvertTo<IEnumerable<string>, IEnumerable<int>>(["str1", "str11", "str111"], strings => strings.Select(str=> str.Length));
    }
    private static void RunTask4()
    {
        Task4 task = new();
        List<int> lstNumbers = [1,2,3,4,5,-10,-2,-3,-6,89,1234,-34,-52];
        IEnumerable<int> result;
        result = task.Filter(lstNumbers, number => number > 0);
        result = task.Filter(lstNumbers, number => number % 2 == 0);
        result = task.Filter(lstNumbers, number => number > 100);
        result = task.Filter(lstNumbers, number => number % 3 == 0 && number % 5 == 0);
    }
    private static void RunTask5()
    {
        Task5 task = new();
        List<Task5.User> users = [new Task5.User(15), new Task5.User(20), new Task5.User(19)];
        List<Task5.Product> products = [new Task5.Product(true), new Task5.Product(false)];
        List<Task5.Order> orders = [new Task5.Order("Completed"), new Task5.Order("Created")];

        var adults = task.Filter(users, user => user.Age >= 18);
        var availableProducts = task.Filter(products, product => product.InStock);
        var completedOrders = task.Filter(orders, order => string.Equals(order.Status, "Completed"));
    }

    private static void RunTask6()
    {
        Task6 task6 = new();
        IEnumerable<int> numbs = [1,2,3,4,5];
        task6.ForEach(numbs, Console.WriteLine);
        task6.ForEach(numbs, numb =>
        {
            string path = Path.Combine(AppContext.BaseDirectory, "test.txt");
            File.WriteAllText(path, Convert.ToString(numb));
        });
        int counter = 0;
        task6.ForEach(numbs, _ => counter++);
        List<string> newLst = [];
        task6.ForEach(numbs, numb => newLst.Add(Convert.ToString(numb)));
    }

    private static void RunTask7(string message)
    {
        Task7 task7 = new();
        
        task7.logger += task7.LogToConsole;
        task7.logger += task7.LogToFile;
        task7.logger += task7.LogToMemory;
        task7.logger.Invoke(message);
        task7.logger -= task7.LogToFile;
        task7.logger!.Invoke(message);
    }

    private static void RunTask8()
    {
        Task8 task = new();
        task.operation += task.AddOne;
        task.operation += task.MultiplyByTwo;
        task.operation += task.Square;
        int value = 5;
        Console.WriteLine($"Result func delegate: {task.operation.Invoke(value)}");
        foreach(Delegate vv in task.operation.GetInvocationList())
        {
            var oper = (Func<int,int>)vv;

            var result = oper(value);
            Console.WriteLine($"result: {result}");
        }

        foreach(Func<int,int> operation in task.operation.GetInvocationList())
        {
            var result = operation(value);
            Console.WriteLine($"result: {result}");
        }
    }

    private static void RunTask9()
    {
        Task9 task = new();
        IEnumerable<Func<string, string>> lstTasks =
        [
            str => str.Trim(),
            str => str.ToLower(),
            str => str.Replace(" ","-")
            //str => $"processed:{str}"
        ];
        Func<string, string> lastTask = value => $"processed:{value}";
        lstTasks = lstTasks.Append(lastTask);

        var result = task.ExecutePipeline("  Hello World  ", lstTasks);
        Console.WriteLine(result);
    }
    private static void RunTask10()
    {
        Action ac = () => 
        {
            Console.WriteLine("Check divide by zero");
            List<int> numbs = [1,0];
            int result  = 1;
            foreach(var numb in numbs)
                result = 5 / numb;
            
        };
        IEnumerable<Action> lstActions = [
            () => { 
                Console.WriteLine("Check read does exist file");
                FileInfo f = new FileInfo("e.txt");   
                File.ReadAllText(f.FullName);
            },
            () => {
                Console.WriteLine("Check a non-exist index");
                int[] array = new int[5];
                array[6]=5;
            }
        ];
        lstActions = lstActions.Append(ac);
        Action<Exception> errorHandler = (err) =>
        {
            Console.WriteLine(err.Message);
        };

        Task10 ts = new();
        foreach(var action in lstActions)
        {
            
            ts.ExecuteSafely(action, errorHandler);
        }
        
    }

    public static void RunAllTests()
    {
        RunTask10();
    }
}