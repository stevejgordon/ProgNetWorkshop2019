# Turbocharged: Writing Highly Performant C# and .NET Code Workshop

This is a 3 hour workshop run at ProgNET 2019.

## Pre-requisite Setup

1. Clone this repository locally
1. Ensure you have the [Prerequisites](prerequisites.md) installed and working.

## What We'll Be Learning

During this workshop, we will discuss and apply various modern C# and .NET techniques to optimise our codebases. We'll begin by learning how to measure the performance of existing code with benchmarks. We learn about Span<T> and apply it to optimise some simple code. We'll look at high-performance, string construction with String.Create. We'll learn about the shared ArrayPool with a practical excercise to measure the allocation reduction it can produce. We'll learn about the new high-performance JSON APIs from Microsoft.

This workshop is focused on introducing as many high-performance features as possible, with practical demos and excercises that help the audience to cement their understanding of the APIs and types we cover in this session.

## Is this course suitable for me?

This workshop covers some quite advanced topics so a level of C# and .NET experience is required. The high-performance topics themselves will be covered from a beginner level so there is no need for prior knowledge of benchmarking, Span<T> etc.

If you've previously seen my talk 'Turbocharged: Writing High-Performance C# and .NET Code' then the themes and some of the content overlap. This dives deeper into some of the topics and includes more demos and some practical activites.

## Repository Structure

**Activity** instructions are included in the folder 'activities'. You will need to follow these for each activity during the workshop. In some cases, more detailed notes are included in the sub-folder 'detailed'. These provide more granular steps if you get stuck with a particular activity. 

The repository also includes a folder called '**steps**' which provides solutions and/or examples for the end state of each activity. If you get stuck or left behind you can load one of these and continue from that step. Some activities may start from a new starting solution.

## Activities

| Activity | Topics |
| ----- | ---- |
| [Activity #1](/activities/01-Create-Benchmark.md) | Create a basic benchmark |
| [Activity #2](/activities/02-Span-Based.md) | Optimise some code with Span<T> |
| [Activity #3](/activities/03-Parameterised-Benchmarks.md) | Add parameters to the benchmarks |
| [Activity #4](/activities/04-String-Create.md) | Applying String.Create for rapid, low-allocation string construction |
| [Activity #5](/activities/05-ArrayPool.md) | Switching to ArrayPool to reduce array allocations |
| [Activity #6](/activities/06-Json.md) | Switch to the System.Text.Json high-level APIs |

ObjectPool<T>