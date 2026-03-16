using Microsoft.Extensions.DependencyInjection;

ServiceProvider services = new ServiceCollection()
    .AddSingleton<Sorter, BogoSort>()
    .BuildServiceProvider();

IEnumerable<Sorter> algorithms = services.GetServices<Sorter>();
Sorter[] indexed = [.. algorithms];

Console.WriteLine("Select sorting algorithm:");
for (int i = 0; i < indexed.Length; i++)
{
    Console.WriteLine($"  {i + 1}. {indexed[i].Algorithm}");
}
Console.Write("Choice: ");

if (!int.TryParse(Console.ReadLine()!.Trim(), out int choice) || choice < 1 || choice > indexed.Length)
{
    Console.WriteLine("Invalid choice.");
    return;
}

Sorter selected = indexed[choice - 1];

Console.Write("How many numbers? ");
int n = int.Parse(Console.ReadLine()!);

Console.Write("Delay between frames ms [default: 100]: ");
string delayInput = Console.ReadLine()!;
int delay = string.IsNullOrWhiteSpace(delayInput) ? 100 : int.Parse(delayInput);

int[] array = [.. Enumerable.Range(1, n)];

Console.CursorVisible = false;
Console.Clear();

selected.Sort(array, (arr, attempts, done) =>
{
    Visualizer.Render(arr, attempts, done);
    Thread.Sleep(delay);
});

Console.CursorVisible = true;
