# Optimising Code With `Span<T>` - Detailed

Below you will find more detailed notes for some of the more complex steps if you need them.

## Activity Steps

### Step 2 Detailed Intructions

Provide an implementation for 'GetDelimiterCountSpanBased' which uses a `ReadOnlySpan<char>` and it's features to attempt to optimise the delimiter counting.

1. Your method should accept a `ReadOnlySpan<char>` as it's input parameter.

> *NOTE: A `string` can be implicitly cast to `ReadOnlySpan<char>`.*

2. Create two local `int` variables for 'count', 'position' and 'index'. 

> 'Count' will hold the count of the delimiters in the input.
> 'Position' will hold the current position that we've inspected from the input.
> 'Index' will hold the current index of a delimiter as we slice through the `ReadOnlySpan<char>` input.

3. Create a while loop which updates the 'index' variable with the index of the `':'` character. You will need to slice into the input using the value of the 'position' variable. If the index is greater than -1 (which indicates the character was not found) we should do the following...

* Increment the 'count'.
* Update the position so that it holds the value to start from in the next loop iteration.

4. Once the while loop has completed, return the 'count'.

*Final code for `GetDelimiterCountSpanBased`*

```csharp
public int GetDelimiterCountSpanBased(ReadOnlySpan<char> input)
{
    var count = 0;
    var position = 0;

    int index;
    while ((index = input.Slice(position).IndexOf(':')) > -1)
    {
        count++;
        position += index + 1;
    }

    return count;
}
```

[Return to the main steps in 02-Span-Based](../02-Span-Based.md)
