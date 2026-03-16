using SortingPlayground.Algorithms;

namespace SortingPlayground.Runners;

abstract class Runner
{
    public abstract void Run(Sorter[] algorithms);

    protected static int[] GenerateArray(int size, int maxValue) =>
        [.. Enumerable.Range(0, size).Select(_ => Random.Shared.Next(1, maxValue + 1))];
}
