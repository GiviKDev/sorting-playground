# Sorting Playground

A fun .NET 10 console app to play with sorting algorithms — visualize them step-by-step in the terminal or compare them side by side. Not a serious benchmarking tool, just a playground for learning and experimentation.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- `make`

## Usage

```sh
make run
```

Select a mode on startup:

```
Select mode:
  1. Visualizer
  2. Benchmark
```

### Visualizer

Animates the selected algorithm sorting an array in the terminal.

```
Select algorithm:
  1. BogoSort
  2. BubbleSort
  3. InsertionSort
  4. SelectionSort
Choice: 2
Array size (n): 6
Max value: 10
```

### Benchmark

Runs all algorithms against the same arrays for every size from 1 to max, and prints a comparison table with step counts and elapsed time.

## Project Structure

```
SortingPlayground/
├── Algorithms/
│   ├── Sorter.cs           # Abstract base class
│   ├── SortStep.cs         # Step record yielded by algorithms
│   ├── BogoSort.cs
│   ├── BubbleSort.cs
│   ├── InsertionSort.cs
│   └── SelectionSort.cs
├── Runners/
│   ├── Runner.cs           # Abstract base class
│   ├── RunMode.cs
│   ├── VisualizerRunner.cs
│   └── BenchmarkRunner.cs
└── Program.cs              # Entry point, auto-discovers algorithms
```

## Adding a New Algorithm

Create a single file in `Algorithms/` — that's it. It will be auto-discovered at startup.

```csharp
namespace SortingPlayground.Algorithms;

class YourSort : Sorter
{
    public override IEnumerable<SortStep> Sort(int[] array)
    {
        int steps = 0;

        // your sorting logic here...
        // yield a step whenever you want to report progress:
        steps++;
        yield return new SortStep(array, steps, false);

        // final step:
        yield return new SortStep(array, steps, true);
    }
}
```

No other files need to be modified.

That's it — both Visualizer and Benchmark will pick it up automatically.

## Makefile Targets

| Target | Description |
|--------|-------------|
| `make run` | Build and run the app |
| `make build` | Build the solution |
| `make clean` | Clean build artifacts |
| `make rebuild` | Clean then build |
| `make format` | Format code with `dotnet format --severity info` |
