namespace SortingPlayground.Algorithms;

class BubbleSort : Sorter
{
    public override IEnumerable<SortStep> Sort(int[] array)
    {
        int steps = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    swapped = true;
                    steps++;
                    yield return new SortStep(array, steps, false);
                }
            }

            if (!swapped)
            {
                break;
            }
        }

        yield return new SortStep(array, steps, true);
    }
}
