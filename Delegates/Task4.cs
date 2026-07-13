namespace MyTestProject.Delegates;

public class Task4
{
    public List<int> Filter(List<int> numbers, Predicate<int> condition)
    {
        List<int> result = [];
        foreach(var numb in numbers) 
            if(condition(numb))
                result.Add(numb);
        return result;
    }
}