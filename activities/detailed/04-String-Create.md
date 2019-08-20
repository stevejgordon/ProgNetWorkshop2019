# Applying String.Create

Below you will find more detailed notes for some of the more complex steps if you need them.

## Activity Steps

### Step 6 Detailed Intructions

First calculate the final character length of the filename based on the properties on the `DataContext`.

1. Add the length of the date format, plus the length of the title on the 'DataContext', plus the dash separater, plus the length of the key on the 'DataContext', plus the length of the suffix.

### Step 7 Detailed Intructions

Use string.Create, passing in the `DataContext`, to populate the characters of the string.

1. 

*Final code for `BuildFilenameWithStringCreate`*

```csharp
private static ReadOnlySpan<char> DateFormatSpan => new[] { 'y', 'y', 'y', 'y', '-', 'M', 'M', '-', 'd', 'd', '-', 'H', 'H', '-' };
private static ReadOnlySpan<char> SuffixSpan => new[] { '.', 't', 'x', 't' };
private static char Separator = '-';

...

public string BuildFilenameWithStringCreate(DataContext dataContext)
{
    var length = DateFormat.Length +
                    dataContext.Title.Length + 1 + // includes separator
                    dataContext.Key.Length + 
                    Suffix.Length;

    return string.Create(length, dataContext, (span, state) =>
    {
        var position = 0;

        state.EventDateUtc.TryFormat(span, out var bytesWritten, DateFormatSpan, CultureInfo.InvariantCulture);
        position += bytesWritten;

        MemoryExtensions.ToUpperInvariant(state.Title, span.Slice(position));
        position += state.Title.Length;

        span[position++] = Separator;

        state.Key.AsSpan().CopyTo(span.Slice(position));
        position += state.Key.Length;

        SuffixSpan.CopyTo(span.Slice(position));
    });
}
```

[Return to the main steps in 04-String-Create](../04-String-Create.md)