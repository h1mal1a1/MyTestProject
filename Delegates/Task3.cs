namespace MyTestProject.Delegates;
public class Task3
{
    public class User
    {
        public string Name {get;set;}
        public User(string name)
        {
            Name = name;
        }
    }

    public class UserDto
    {
        public string Name {get;set;}
        public UserDto(string name)
        {
            Name = name;
        }
    }

    public delegate TResult Converter<TSource, TResult>(TSource source);

    public TResult ConvertTo<TSource,TResult>(TSource value, Converter<TSource,TResult> conv) => conv(value);

}