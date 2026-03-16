namespace SortingPlayground.Algorithms;

class SelectionSort : Sorter
{
    public override IEnumerable<SortStep> Sort(int[] array)
    {
        int steps = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }

            steps++;
            yield return new SortStep(array, steps, false);
        }

        yield return new SortStep(array, steps, true);
    }
}
