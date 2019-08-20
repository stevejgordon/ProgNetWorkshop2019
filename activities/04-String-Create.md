# Applying String.Create

## What's the plan?

We're going to apply string.Create to build up some a string value in an highly optimised way. In this scenario we need to build a filename using some properties on an object. We want to avoid unneccesary allocations whilst also being fast.

## Activity Steps

1. Open the solution in [steps/04-Start](../steps/04-Start) folder.

2. The benchmark project is set up to run two benchmarks against two existing approaches which create the filename. Run the existing benchmarks and review the output.

3. Create a private static `ReadOnlySpan<char>` field, called 'DateFormatSpan'. Populate it with the characters needed to format the date.

> *HINT: Use the same format as supplied on the 'DateFormat' string already defined in this class.*

4. Create a private static `ReadOnlySpan<char>` field, called 'SuffixSpan'. Populate it with the characters needed for the filename suffix.

> *HINT: Use the same format as supplied on the 'Suffix' string already defined in this class.*

5. Create a new method on the FilenameBuilder called 'BuildFilenameWithStringCreate'.

6. First calculate the final character length of the filename based on the properties on the `DataContext`.

7. Use string.Create, passing in the `DataContext`, to populate the characters of the string.

> *If you get stuck you can follow the more [detailed steps](detailed/04-String-Create.md).*

## End of Activity

An example of the end result after this activity can be found in [steps/04-String-Create](../steps/04-String-Create).

[Return to README and activity links](../README.md)