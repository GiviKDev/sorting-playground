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
            Visualizer.Render(arr, steps, done);
            Thread.Sleep(FrameDelayMs);
        });

        Console.CursorVisible = true;
    }
}
