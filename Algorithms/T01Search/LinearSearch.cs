namespace MyTestProject.Algorithms.Topic01Search;

public class LinearSearch
{
    public int LinearSearchIndex(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
            if (numbers[i] == target)
                return i;
        return -1;
    }
}
