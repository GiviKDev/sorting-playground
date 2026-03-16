using Microsoft.Extensions.DependencyInjection;

ServiceProvider services = new ServiceCollection()
    .AddSingleton<Sorter, BogoSort>()
    .BuildServiceProvider();

Sorter[] algorithms = [.. services.GetServices<Sorter>()];

Console.WriteLine("Select mode:");
foreach (RunMode mode in Enum.GetValues<RunMode>())
{
    Console.WriteLine($"  {(int)mode}. {mode}");
}
Console.Write("Choice: ");

if (!int.TryParse(Console.ReadLine()!.Trim(), out int modeChoice) || !Enum.IsDefined((RunMode)modeChoice))
{
    Console.WriteLine("Invalid choice.");
    return;
}

Runner runner = (RunMode)modeChoice switch
{
    RunMode.Visualizer => new VisualizerRunner(),
    RunMode.Benchmark => new BenchmarkRunner(),
    _ => throw new InvalidOperationException(),
};

runner.Run(algorithms);
