namespace MyTestProject.LambdaExpression;

public class Task9
{
    public Predicate<T> And<T>(Predicate<T> first, Predicate<T> second) => value => first(value) && second(value);

    public Predicate<T> Or<T>(Predicate<T> first, Predicate<T> second) => value => first(value) || second(value);

    public Predicate<T> Not<T>(Predicate<T> predicate) => value => !predicate(value);
}