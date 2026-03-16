var random = new Random();

Console.Write("How many numbers? ");
int n = int.Parse(Console.ReadLine()!);

int[] array = [.. Enumerable.Range(1, n)];
Shuffle(array);

Console.CursorVisible = false;
Console.Clear();

int attempts = 0;
Render(array, attempts);

while (!IsSorted(array))
{
    Shuffle(array);
    attempts++;
    Render(array, attempts);
    Thread.Sleep(100);
}

Render(array, attempts, done: true);
Console.CursorVisible = true;

void Render(int[] arr, int attempts, bool done = false)
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

    // number labels
    for (int col = 0; col < arr.Length; col++)
        Console.Write($" {arr[col],1} ");
    Console.WriteLine();

    Console.WriteLine();
    Console.ForegroundColor = done ? ConsoleColor.Green : ConsoleColor.Yellow;
    Console.WriteLine(done
        ? $"  Sorted after {attempts} shuffles!   "
        : $"  Shuffle #{attempts}...              ");
    Console.ResetColor();
}

bool IsSorted(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
        if (arr[i] < arr[i - 1])
            return false;
    return true;
}

void Shuffle(int[] arr)
{
    for (int i = arr.Length - 1; i > 0; i--)
    {
        int j = random.Next(i + 1);
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}
