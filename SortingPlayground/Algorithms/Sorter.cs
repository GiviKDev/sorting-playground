abstract class Sorter
{
    public abstract SortingAlgorithm Algorithm { get; }

    public abstract int Sort(int[] array, Action<int[], int, bool> onStep);

    protected static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                return false;
            }
        }

        return true;
    }
}
