# Creating a Benchmark

## What's the plan?

We're going to add a benchmark project to our solution and benchmark the existing GetDelimiterCount method on the KeyParser.

We want to benchmark the execution time and the memory allocations.

## Activity Steps

1. Load the starting solution from [steps/00-Start](../steps/00-Start).

2. Add a new console application project called 'Benchmarks' to the solution.

*I prefer to create a solution folder called 'benchmarks' to organise these*

3. Add a reference to the Core project from the Benchmarks project.

4. Add a package reference to the latest 'BenchmarkDotNet' NuGet package.

5. Create a public class called, KeyParserBenchmarks to hold your benchmarks.

> *Hint: Ensure your class is attributed correctly to include the `MemoryDiagnoser`*

6. Create a benchmark method which will benchmark the 'GetDelimiterCount' method on the KeyParser.

> *Hint: Be careful to avoid measuring the allocation of the KeyParser instance itself*

> *If you get stuck you can follow the more [detailed steps](detailed/01-Create-Benchmark.md).*

7. In the Main method, use the BenchmarkRunner to cause the benchmark class to be run.

> *If you get stuck you can follow the more detailed steps in [detailed steps](detailed/01-Create-Benchmark.md).*

8. Open a command prompt (or terminal of your choosing) at the location of the Benchmarks project.

9. Run the benchmark project in release mode using the following command: dotnet run -c Release

10. Make a note of the mean execution time and the allocated bytes.

## End of Activity

An example of the end result after this activity can be found in [steps/01-Create-Benchmark](../steps/01-Create-Benchmark).

[Return to README and activity links](../README.md)