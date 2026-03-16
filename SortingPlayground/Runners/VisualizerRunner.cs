using SortingPlayground.Algorithms;

namespace SortingPlayground.Runners;

class VisualizerRunner : Runner
{
    private const int FrameDelayMs = 50;

    public override void Run(Sorter[] algorithms)
    {
        Console.WriteLine("Select algorithm:");
        for (int i = 0; i < algorithms.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {algorithms[i].Algorithm}");
        }
        Console.Write("Choice: ");

        if (!int.TryParse(Console.ReadLine()!.Trim(), out int choice) || choice < 1 || choice > algorithms.Length)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Sorter selected = algorithms[choice - 1];

        Console.Write("Array size (n): ");
        int n = int.Parse(Console.ReadLine()!);

        Console.Write("Max value: ");
        int maxValue = int.Parse(Console.ReadLine()!);

        int[] array = GenerateArray(n, maxValue);

        Console.CursorVisible = false;
        Console.Clear();

        selected.Sort(array, (arr, steps, done) =>
        {
            Render(arr, steps, done);
            Thread.Sleep(FrameDelayMs);
        });

        Console.CursorVisible = true;
    }

    public static void Render(int[] arr, int attempts, bool done)
    {
        Console.SetCursorPosition(0, 0);

        int max = arr.Max();

        for (int row = max; row >= 1; row--)
        {
            for (int col = 0; col < arr.Length; col++)
            {
                if (arr[col] >= row)
                {
                    Console.ForegroundColor = done ? ConsoleColor.Green : ConsoleColor.Cyan;
                    Console.Write(" █ ");
                }
                else
                {
                    Console.Write("   ");
                }
            }
            Console.WriteLine();
        }

        Console.ResetColor();

        for (int col = 0; col < arr.Length; col++)
        {
            Console.Write($" {arr[col],1} ");
        }

        Console.WriteLine();

        Console.WriteLine();
        Console.ForegroundColor = done ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.WriteLine(done
            ? $"  Sorted after {attempts} shuffles!   "
            : $"  Shuffle #{attempts}...              ");
        Console.ResetColor();
    }
}
