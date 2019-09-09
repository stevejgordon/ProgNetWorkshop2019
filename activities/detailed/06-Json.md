# Switching to System.Text.Json

Below you will find more detailed notes for some of the more complex steps if you need them.

## Activity Steps

### Steps 5 to 7 Detailed Intructions

Step 5 - Add a new method to the `JsonDataWorker` called 'DeserialiseAndSerialiseMicrosoft'.

1. Add a new method with the signature `public static string DeserialiseAndSerialiseMicrosoft(ReadOnlySpan<byte> json)` to the `JsonDataWorker` class.

Step 6 - Use the `JsonSerializer` from the 'System.Text.Json' namespace to deserialise the json from the source bytes into an instance of `FormulaOneDriverData`.

1. Deserialise using `var drivers = System.Text.Json.JsonSerializer.Deserialize<FormulaOneDriverData>(json);`

Step 7 - Use the `JsonSerializer` to serialise the `FormulaOneDriverData` back to a JSON string and return it from the method.

1. Serialise the message to text and return using `return System.Text.Json.JsonSerializer.Serialize(drivers);`

*Final code for the 'DeserialiseAndSerialiseMicrosoft' method in `JsonDataWorker`*

```csharp
public static string DeserialiseAndSerialiseMicrosoft(ReadOnlySpan<byte> json)
{
	var drivers = System.Text.Json.JsonSerializer.Deserialize<FormulaOneDriverData>(json);

	return System.Text.Json.JsonSerializer.Serialize(drivers);
}
```

[Return to the main steps in 06-Json](../06-Json.md)