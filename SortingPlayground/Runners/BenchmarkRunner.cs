using System.Diagnostics;

class BenchmarkRunner : Runner
{
    public override void Run(Sorter[] algorithms)
    {
        Console.Write("Min array size: ");
        int minSize = int.Parse(Console.ReadLine()!);

        Console.Write("Max array size: ");
        int maxSize = int.Parse(Console.ReadLine()!);

        Console.Write("Max value: ");
        int maxValue = int.Parse(Console.ReadLine()!);

        Console.WriteLine();

        foreach (Sorter algorithm in algorithms)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{algorithm.Algorithm}");
            Console.ResetColor();

            Console.WriteLine($"  {"n",-6}  {"Max",-6}  {"Steps",-12}  {"Time"}");
            Console.WriteLine($"  {new string('-', 38)}");

            for (int size = minSize; size <= maxSize; size++)
            {
                int[] array = GenerateArray(size, maxValue);
                Stopwatch sw = Stopwatch.StartNew();
                int steps = algorithm.Sort(array, (_, _, _) => { });
                sw.Stop();

                Console.WriteLine($"  {size,-6}  {maxValue,-6}  {steps,-12}  {sw.ElapsedMilliseconds}ms");
            }

            Console.WriteLine();
        }
    }
}
