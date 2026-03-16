static class BogoSort
{
    public static int Sort(int[] array, Action<int[], int, bool> onShuffle)
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

    private static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] < arr[i - 1])
                return false;
        return true;
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
