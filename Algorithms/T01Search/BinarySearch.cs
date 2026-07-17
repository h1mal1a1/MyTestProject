namespace MyTestProject.Algorithms.Topic01Search;

public class BinarySearch
{
    public static int BinarySearchIndex(int[] sortedNumbers, int target)
    {
        int leftIndex = 0;
        int rightIndex = sortedNumbers.Length - 1;

        while (leftIndex <= rightIndex)
        {
            int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
            int middleValue = sortedNumbers[middleIndex];
            if (middleValue == target)
                return middleIndex;
            if (target < middleValue)
                rightIndex = middleIndex - 1;
            else
                leftIndex = middleIndex + 1;
        }
        return -1;
    }
}