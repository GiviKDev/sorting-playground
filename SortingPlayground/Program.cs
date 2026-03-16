Console.Write("How many numbers? ");
int n = int.Parse(Console.ReadLine()!);

int[] array = [.. Enumerable.Range(1, n)];

Console.CursorVisible = false;
Console.Clear();

int shuffles = BogoSort.Sort(array, (arr, attempts, done) =>
{
    Visualizer.Render(arr, attempts, done);
    Thread.Sleep(100);
});

Console.CursorVisible = true;
