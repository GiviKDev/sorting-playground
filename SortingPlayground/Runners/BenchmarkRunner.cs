using System.Diagnostics;

class BenchmarkRunner : Runner
{
    public override void Run(Sorter[] algorithms)
    {
        Console.Write("Max array size: ");
        int maxSize = int.Parse(Console.ReadLine()!);

        Console.Write("Max value: ");
        int maxValue = int.Parse(Console.ReadLine()!);

        Console.WriteLine();

        // Header: n | Algorithm1 Steps | Algorithm1 Time | Algorithm2 Steps | ...
        Console.Write($"  {"n",-6}");
        foreach (Sorter algorithm in algorithms)
        {
            Console.Write($"  {algorithm.Algorithm + " Steps",-16}  {"Time",-10}");
        }
        Console.WriteLine();
        Console.WriteLine($"  {new string('-', 6 + algorithms.Length * 30)}");

        for (int size = 1; size <= maxSize; size++)
        {
            int[] original = GenerateArray(size, maxValue);

            Console.Write($"  {size,-6}");

            foreach (Sorter algorithm in algorithms)
            {
                int[] array = [.. original];
                Stopwatch sw = Stopwatch.StartNew();
                int steps = algorithm.Sort(array, (_, _, _) => { });
                sw.Stop();

                Console.Write($"  {steps,-16}  {sw.ElapsedMilliseconds + "ms",-10}");
            }

            Console.WriteLine();
        }
    }
}
