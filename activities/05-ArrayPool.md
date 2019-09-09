# Utilising an ArrayPool

## What's the plan?

We're going to switch the use of a standard array to one provided from an ArrayPool and measure the performance impact.

## Activity Steps

1. Open the solution in [steps/05-Start](../steps/05-Start) folder.

2. The Benchmarks project has been setup to benchmark methods in the 'MultiplierBenchmarks' class. Currently, there is a single benchmark which calls the 'PopulateMultiplesOfTwo' on the 'Multiplier'. This method accepts an array and populates it with some values. You can optionally run this benchmark from the command line if you want to see the result before we proceed.

3. Add a new overload for the PopulateMultiplesOfTwo method in the 'Multiplier' class of the 'Core' project to support working with arrays from the pool. You may want to refactor the Multiple class to keep it clean and reduce code repetiion.

> *HINT: Since the array from the array pool may be larger than you request, you need to handle this in your code.*

> *If you get stuck you can follow the more [detailed steps](detailed/05-ArrayPool.md).*

4. Add a new benchmark method named 'ArrayPool'.

5. Rent an array from the shared ArrayPool.

6. Call the Multiplier.CalculateMultiplesOfTwo method, passing in the array which you rented.

7. Consider the requirement to return the array to the pool and implement that appropriately.

> *If you get stuck you can follow the more [detailed steps](detailed/05-ArrayPool.md).*

## End of Activity

An example of the end result after this activity can be found in [steps/05-ArrayPool](../steps/05-ArrayPool).

## Extension

Experiment with making this benchmark parameterised to test some arrays of different lengths and compare the results.

[Return to README and activity links](../README.md)