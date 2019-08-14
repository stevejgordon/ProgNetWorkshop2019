using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Core;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run<KeyParserBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class KeyParserBenchmarks
    {
        private const string Input = "This:Is:A:Weirdly:Separated:String:Input:With:Many:Colons";

        private KeyParser _parser;

        [GlobalSetup]
        public void Setup()
        {
            _parser = new KeyParser();
        }

        [Benchmark(Baseline = true)]
        public void CountColons()
        {
            var result = _parser.GetDelimiterCount(Input);
        }

        [Benchmark]
        public void CountColonsSpanBased()
        {
            var result = _parser.GetDelimiterCountSpanBased(Input);
        }
    }
}
