# Adding Parameters To Benchmarks

## What's the plan?

We're going to update our benchmarks to include a parameter to control the number of colons in the input.

## Activity Steps

1. Add a `int` property to the 'KeyParserBenchmarks' class called 'Colons'.

2. Mark the property with the appropriate BenchMarkDotNet attribute to apply three parameter values (0, 5, 10).

3. Update the benchmark to include a method named 'Setup' marked with the `GlobalSetup` attribute. 

4. Add code to this method to support building a variable length string, with the appropriate number of colons.

> *If you get stuck you can follow the more [detailed steps](detailed/03-Parameterised-Benchmarks.md).*

5. Run your updated benchmarks which should now include parameterised results.

## End of Activity

An example of the end result after this activity can be found in [steps/02-Span-Based](../steps/02-Span-Based).

[Return to README and activity links](../README.md)