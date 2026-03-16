using SortingPlayground.Algorithms;

namespace SortingPlayground.Runners;

class VisualizerRunner : Runner
{
    private const int FrameDelayMs = 150;

    public override void Run(Sorter[] algorithms)
    {
        Console.WriteLine("Select algorithm:");
        for (int i = 0; i < algorithms.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {algorithms[i].Name}");
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

        foreach (SortStep step in selected.Sort(array))
        {
            Render(step);
            Thread.Sleep(FrameDelayMs);
        }

        Console.CursorVisible = true;
    }

    public static void Render(SortStep step)
    {
        Console.SetCursorPosition(0, 0);

        int max = step.Array.Max();
        int cellWidth = max.ToString().Length + 2;
        string block = new('█', cellWidth - 2);
        string empty = new(' ', cellWidth);

        for (int row = max; row >= 1; row--)
        {
            for (int col = 0; col < step.Array.Length; col++)
            {
                if (step.Array[col] >= row)
                {
                    Console.ForegroundColor = step.IsDone ? ConsoleColor.Green : ConsoleColor.Cyan;
                    Console.Write($" {block} ");
                }
                else
                {
                    Console.Write(empty);
                }
            }
            Console.WriteLine();
        }

        Console.ResetColor();

        for (int col = 0; col < step.Array.Length; col++)
        {
            Console.Write($" {step.Array[col].ToString().PadLeft(cellWidth - 2)} ");
        }

        Console.WriteLine();

        Console.WriteLine();
        Console.ForegroundColor = step.IsDone ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.WriteLine(step.IsDone
            ? $"  Sorted after {step.StepCount} steps!   "
            : $"  Step #{step.StepCount}...              ");
        Console.ResetColor();
    }
}
