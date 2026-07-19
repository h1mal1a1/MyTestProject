namespace MyTestProject.Algorithms.T02Sorting;

public class SelectionSort
{
    public static int[] Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[minIndex] > array[j])
                {
                    minIndex = j;
                }
            }
            if (array[minIndex] != array[i])
            {
                (array[minIndex], array[i]) = (array[i], array[minIndex]);
            }
        }
        return array;
    }
}