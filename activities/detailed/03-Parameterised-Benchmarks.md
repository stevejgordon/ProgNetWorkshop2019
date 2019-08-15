# Adding Parameters To Benchmarks

Below you will find more detailed notes for some of the more complex steps if you need them.

## Activity Steps

### Step 4 Detailed Intructions

Add code to this method to support building a variable length string, with the appropriate number of colons.

1. Create a private const `string` for the class called 'Word' and provide a value.

2. Create a private `string` field called '_input'.

3. Within the 'Setup' method, create a `StringBuilder`.

4. Add a for loop which uses the 'Colons' property to determine the number of iterations to run.

5. Append the 'Word' value and a colon character within the loop so that the correct number of colons are included in the final string.

6. At the end of the loop, append a final 'Word' to the end of the string.

7. Set the '_input' value from the `StringBuilder`.

*Final code for `KeyParserBenchmarks`*

```csharp
[MemoryDiagnoser]
public class KeyParserBenchmarks
{
    private const string Word = "something";

    private string _input;
    private KeyParser _parser;

    [GlobalSetup]
    public void Setup()
    {
        _parser = new KeyParser();

        var sb = new StringBuilder();

        for (var i = 0; i < Colons; i++)
        {
            sb.Append(Word).Append(':');
        }

        sb.Append(Word);

        _input = sb.ToString();
    }

    [Params(0, 5, 10)]
    public int Colons { get; set; }

    [Benchmark(Baseline = true)]
    public void Original()
    {
        var result = _parser.GetDelimiterCount(_input);
    }

    [Benchmark]
    public void SpanBased()
    {
        var result = _parser.GetDelimiterCountSpanBased(_input);
    }
}
```

[Return to the main steps in 03-Parameterised-Benchmarks](../03-Parameterised-Benchmarks.md)