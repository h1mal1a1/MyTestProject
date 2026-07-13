namespace MyTestProject.Delegates;

public class Task5
{
    public class User
    {
        public int Age { get; private set; }        
        public void SetAge(int age)
        {
            if(age < 0)
                throw new ArgumentException("Age cannot be less 0");
            else if(age > 100)
                throw new ArgumentException("Age cannot be more 100");
            else
                Age = age;
        }
        public User(int age)
        {
            SetAge(age);
        }
    }

    public class Product
    {        
        public bool InStock { get; set; }
        private static int _nextId;
        public int Id {get;}
        public Product(bool inStock)
        {
           InStock = inStock; 
           Id=Interlocked.Increment(ref _nextId);
        }
    }

    public class Order
    {
        public string Status { get; private set; } = "Created";

        public void SetStatus(string status)
        {
            if(string.IsNullOrWhiteSpace(status))
                throw new Exception("string is null or white space");
            Status = status;
        }
        public Order(string status)
        {
            try
            {
                SetStatus(status);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error: ", ex);
            }
        }

    }

    public List<T> Filter<T>(IEnumerable<T> numbers, Predicate<T> condition)
    {
        List<T> result = [];
        foreach(var numb in numbers) 
            if(condition(numb))
                result.Add(numb);
        return result;
    }
}