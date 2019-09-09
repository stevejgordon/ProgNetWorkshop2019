# Utilising an ArrayPool

Below you will find more detailed notes for some of the more complex steps if you need them.

## Activity Steps

### Step 3 Detailed Intructions

Add a new overload for the PopulateMultiplesOfTwo method in the 'Multiplier' class of the 'Core' project to support working with arrays from the pool. You may want to refactor the Multiple class to keep it clean and reduce code repetiion.

1. Add a new method with the signature `public static void PopulateMultiplesOfTwo(int[] data, int size)` to the 'Multiplier' class.

2. Move the existing logic to that method, using the size parameter to control the for loop iterations.

3. In the original method with the signature `public static void PopulateMultiplesOfTwo(int[] data)`, call the new method, passing the Length property of the 'data' array.

4. Validate that the existing test still passes.

*Final code for `Multiplier`*

```csharp
public static class Multiplier
{
	public static void PopulateMultiplesOfTwo(int[] data)
	{
		PopulateMultiplesOfTwo(data, data.Length);
	}

	public static void PopulateMultiplesOfTwo(int[] data, int size)
	{
		data[0] = 2;

		for (var i = 1; i < size; ++i)
		{
			data[i] = (i + 1) * 2;
		}
	}
}
```

### Step 7 Detailed Intructions

Consider the requirement to return the array to the pool and implement that appropriately.

1. Ensure that you call the 'PopulateMultiplesOfTwo' method within a Try block.

2. Include a Finally block and ensure you return the rented array to the pool. This ensures that regardless of any exceptions being thrown, we properly return the array when we are finished with it.

*Final code for the `ArrayPool` benchmark*

```csharp
[Benchmark]
public void ArrayPool()
{
	var array = ArrayPool<int>.Shared.Rent(Size);

	try
	{
		Multiplier.PopulateMultiplesOfTwo(array, Size);
		// do something with the data
	}
	finally
	{
		ArrayPool<int>.Shared.Return(array);
	}
}
```

[Return to the main steps in 05-ArrayPool](../05-ArrayPool.md)