# Optimising Code With `Span<T>`

## What's the plan?

We're going to add create a Span<T> based version of GetDelimiterCount and benchmark it against the original version.

## Activity Steps

1. Add a new method to the 'KeyParser' named 'GetDelimiterCountSpanBased'.

2. Provide an implementation for 'GetDelimiterCountSpanBased' which uses a `ReadOnlySpan<char>` and it's features to attempt to optimise the delimiter counting.

> *HINT: You may need to use the `Slice` and `IndexOf` methods.*

> *If you get stuck you can follow the more [detailed steps](detailed/02-Span-Based-Delimiter-Count.md).*

3. Update the 'Core.Tests' to validate that your new method passes the same tests as used for 'GetDelimiterCount'.

4. Add a benchmark method named 'SpanBased' to excercise your new method to compare it against the original.

> *HINT: You might want to set the 'Original' benchmark method as the baseline to get a ratio of the difference between both versions in the results.*

5. Compare the results and hopefully celebrate your optimisation!

## End of Activity

An example of the end result after this activity can be found in [steps/03-Parameterised-Benchmark](../steps/03-Parameterised-Benchmark).

[Return to README and activity links](../README.md)