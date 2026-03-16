class BogoSort : Sorter
{
    public override int Sort(int[] array, Action<int[], int, bool> onShuffle)
    {
        Shuffle(array);
        int attempts = 0;
        onShuffle(array, attempts, false);

        while (!IsSorted(array))
        {
            Shuffle(array);
            attempts++;
            onShuffle(array, attempts, false);
        }

        onShuffle(array, attempts, true);
        return attempts;
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
