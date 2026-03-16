namespace SortingPlayground.Algorithms;

class InsertionSort : Sorter
{
    public override IEnumerable<SortStep> Sort(int[] array)
    {
        int steps = 0;

        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
            steps++;
            yield return new SortStep(array, steps, false);
        }

        yield return new SortStep(array, steps, true);
    }
}
