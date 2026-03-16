namespace SortingPlayground.Algorithms;

abstract class Sorter
{
    public virtual string Name => GetType().Name;

    public abstract IEnumerable<SortStep> Sort(int[] array);

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
