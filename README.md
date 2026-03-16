# Sorting Playground

A .NET 10 console app for visualizing and benchmarking sorting algorithms.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- `make`

## Usage

```sh
make run
```

On startup, select a mode:

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
Choice: 1
Array size (n): 6
Max value: 10
```

### Benchmark

Runs all registered algorithms against the same arrays for every size from 1 to the specified max, and prints a comparison table.

```
Max array size: 8
Max value: 100

BogoSort          Steps             Time
n       BogoSort Steps    Time
----------------------------------------------
1       2                 0ms
2       14               0ms
...
```

## Project Structure

```
SortingPlayground/
├── Algorithms/          # Sorting algorithm implementations
│   ├── Sorter.cs        # Abstract base class
│   ├── SortingAlgorithm.cs  # Enum of available algorithms
│   └── BogoSort.cs
├── Runners/             # Execution modes
│   ├── Runner.cs        # Abstract base class
│   ├── RunMode.cs       # Enum of available modes
│   ├── VisualizerRunner.cs
│   └── BenchmarkRunner.cs
├── Program.cs           # Entry point, DI setup
└── Visualizer.cs        # Terminal rendering (used by VisualizerRunner)
```

## Adding a New Algorithm

1. Create `Algorithms/YourSort.cs` implementing `Sorter`:
   ```csharp
   namespace SortingPlayground.Algorithms;

   class YourSort : Sorter
   {
       public override SortingAlgorithm Algorithm => SortingAlgorithm.YourSort;

       public override int Sort(int[] array, Action<int[], int, bool> onStep)
       {
           // ...
       }
   }
   ```

2. Add the value to the enum in `SortingAlgorithm.cs`:
   ```csharp
   enum SortingAlgorithm
   {
       BogoSort,
       YourSort,
   }
   ```

3. Register it in `Program.cs`:
   ```csharp
   new ServiceCollection()
       .AddSingleton<Sorter, BogoSort>()
       .AddSingleton<Sorter, YourSort>()
   ```

That's it — both Visualizer and Benchmark will pick it up automatically.

## Makefile Targets

| Target | Description |
|--------|-------------|
| `make run` | Build and run the app |
| `make build` | Build the solution |
| `make clean` | Clean build artifacts |
| `make rebuild` | Clean then build |
| `make format` | Format code with `dotnet format --severity info` |
