using System.Reflection;
using SortingPlayground.Algorithms;
using SortingPlayground.Runners;

Sorter[] algorithms = [.. Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => t.IsSubclassOf(typeof(Sorter)) && !t.IsAbstract)
    .Select(t => (Sorter)Activator.CreateInstance(t)!)
    .OrderBy(s => s.Name)];

Console.WriteLine("Select mode:");
foreach (RunMode mode in Enum.GetValues<RunMode>())
{
    Console.WriteLine($"  {(int)mode}. {mode}");
}
Console.Write("Choice: ");

if (!Enum.TryParse(Console.ReadLine()!.Trim(), out RunMode modeChoice) || !Enum.IsDefined(modeChoice))
{
    Console.WriteLine("Invalid choice.");
    return;
}

Runner runner = modeChoice switch
{
    RunMode.Visualizer => new VisualizerRunner(),
    RunMode.Benchmark => new BenchmarkRunner(),
    _ => throw new InvalidOperationException(),
};

runner.Run(algorithms);
