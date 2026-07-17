namespace MyTestProject.Algorithms.T02Sorting;

public class BubbleSort
{
    public static int[] Sort(int[] notSortNumbers)
    {
        for (int i = notSortNumbers.Length - 1; i > 0; i--)
            for (int j = 0; j < i; j++)
                if (notSortNumbers[j] > notSortNumbers[j + 1])
                    (notSortNumbers[j + 1], notSortNumbers[j]) = (notSortNumbers[j], notSortNumbers[j + 1]);
        return notSortNumbers;
    }

    public static int[] OptimizedSort(int[] notSortNumbers)
    {
        for (int i = notSortNumbers.Length - 1; i > 0; i--)
        {
            bool wasSwapped = false;
            for (int j = 0; j < i; j++)
            {
                if (notSortNumbers[j] > notSortNumbers[j + 1])
                {
                    (notSortNumbers[j + 1], notSortNumbers[j]) = (notSortNumbers[j], notSortNumbers[j + 1]);
                    wasSwapped = true;
                }
            }
            if (!wasSwapped)
                break;
        }

        return notSortNumbers;
    }
}