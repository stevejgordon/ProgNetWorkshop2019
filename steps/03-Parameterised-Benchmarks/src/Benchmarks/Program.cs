using System.Text;
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
        private const string Word = "something";

        private string _input;
        private KeyParser _parser;

        [GlobalSetup]
        public void Setup()
        {
            _parser = new KeyParser();

            var sb = new StringBuilder();

            for (var i = 0; i < Colons; i++)
            {
                sb.Append(Word).Append(':');
            }

            sb.Append(Word);

            _input = sb.ToString();
        }

        [Params(0, 5, 10)]
        public int Colons { get; set; }

        [Benchmark(Baseline = true)]
        public void Original()
        {
            var result = _parser.GetDelimiterCount(_input);
        }

        [Benchmark]
        public void SpanBased()
        {
            var result = _parser.GetDelimiterCountSpanBased(_input);
        }
    }
}
