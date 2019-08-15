# Creating a Benchmark - Detailed

Below you will find more detailed notes for some of the more complex steps if you need them.

## Activity Steps

### Step 6 Detailed Intructions

Create a benchmark method which will benchmark the execution time and memory allocations of the 'GetDelimiterCount' method on the KeyParser.

> *NOTE: There are various ways that we can achieve this goal. This is just one option.*

1. We'll define a constant string which we'll use as our input. This can be a private field.

```csharp
private const string Input = "This:Is:A:Weirdly:Separated:String:Input:With:Many:Colons";
```

2. We'll also initialise a static field with an instance of KeyParser.

```csharp
private static readonly KeyParser Parser = new KeyParser();
```

3. We'll create a method called 'Original' and mark it with the `Benchmark` attribute.

4. Inside this method, we'll call the GetDelimiterCount, passing our constant string as the input argument.

*Final code for `KeyParserBenchmarks`*

```csharp
[MemoryDiagnoser]
public class KeyParserBenchmarks
{
    private const string Input = "This:Is:A:Weirdly:Separated:String:Input:With:Many:Colons";
    private static readonly KeyParser Parser = new KeyParser();

    [Benchmark]
    public void Original()
    {
        _ = Parser.GetDelimiterCount(Input);
    }
}
```

### Step 7 Detailed Steps

In the Main method, use the BenchmarkRunner to cause the benchmark class to be run.

1. Add a using directive `using BenchmarkDotNet.Running;`

2. Use the static `Run` method on the `BenchmarkRunner`, passing `KeyParserBenchmarks` as the generic type argument.

*Final code*

```csharp
static void Main(string[] args)
{
    BenchmarkRunner.Run<KeyParserBenchmarks>();
}
```

[Return to the main steps in 01-Create-Benchmark](../01-Create-Benchmark.md)