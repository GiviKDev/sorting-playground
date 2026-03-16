static class Visualizer
{
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
