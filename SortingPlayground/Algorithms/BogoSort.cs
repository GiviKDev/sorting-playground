namespace SortingPlayground.Algorithms;

class BogoSort : Sorter
{
    public override IEnumerable<SortStep> Sort(int[] array)
    {
        Shuffle(array);
        int attempts = 0;
        yield return new SortStep(array, attempts, false);

        while (!IsSorted(array))
        {
            Shuffle(array);
            attempts++;
            yield return new SortStep(array, attempts, false);
        }

        yield return new SortStep(array, attempts, true);
    }

    private static void Shuffle(int[] arr)
    {
        var random = Random.Shared;
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
}
