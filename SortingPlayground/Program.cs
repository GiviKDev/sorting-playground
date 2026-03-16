using Microsoft.Extensions.DependencyInjection;
using SortingPlayground.Algorithms;
using SortingPlayground.Runners;

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

ServiceProvider services = new ServiceCollection()
    .AddSingleton<Sorter, BogoSort>()
    .BuildServiceProvider();

Sorter[] algorithms = [.. services.GetServices<Sorter>()];

Runner runner = modeChoice switch
{
    RunMode.Visualizer => new VisualizerRunner(),
    RunMode.Benchmark => new BenchmarkRunner(),
    _ => throw new InvalidOperationException(),
};

runner.Run(algorithms);
