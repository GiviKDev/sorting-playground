Console.WriteLine("Select sorting algorithm:");
Console.WriteLine("  1. BogoSort");
Console.Write("Choice: ");

switch (Console.ReadLine()!.Trim())
{
    case "1":
        RunBogoSort();
        break;
    default:
        Console.WriteLine("Unknown choice.");
        break;
}

static void RunBogoSort()
{
    Console.Write("How many numbers? ");
    int n = int.Parse(Console.ReadLine()!);

    Console.Write("Delay between frames ms [default: 100]: ");
    string delayInput = Console.ReadLine()!;
    int delay = string.IsNullOrWhiteSpace(delayInput) ? 100 : int.Parse(delayInput);

    int[] array = [.. Enumerable.Range(1, n)];

    Console.CursorVisible = false;
    Console.Clear();

    new BogoSort().Sort(array, (arr, attempts, done) =>
    {
        Visualizer.Render(arr, attempts, done);
        Thread.Sleep(delay);
    });

    Console.CursorVisible = true;
}
