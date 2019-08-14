using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Core;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<KeyParserBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class KeyParserBenchmarks
    {
        private const string Input = "This:Is:A:Weirdly:Separated:String:Input:With:Many:Colons";
        private static readonly KeyParser Parser = new KeyParser();

        [Benchmark]
        public void Original()
        {
            _ = Parser.GetDelimiterCount(Input);
        }
    }
}
