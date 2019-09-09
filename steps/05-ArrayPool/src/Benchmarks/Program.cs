using System;
using System.Buffers;
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
            var result = BenchmarkRunner.Run<MultiplierBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class MultiplierBenchmarks
    {
        private const int Size = 1000;

        [Benchmark(Baseline = true)]
        public void Original()
        {
            var array = new int[Size];
            Multiplier.PopulateMultiplesOfTwo(array);
            // do something with the data
        }

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
    }

    [MemoryDiagnoser]
    public class FileNameBuilderBenchmarks
    {
        private FilenameBuilder _filenameBuilder;
        private DataContext _dataContext;

        [GlobalSetup]
        public void Setup()
        {
            _filenameBuilder = new FilenameBuilder();

            _dataContext = new DataContext
            {
                EventDateUtc = new DateTime(2019, 09, 13, 10, 00, 00, DateTimeKind.Utc),
                Title = "ProgNet2019",
                Key = "WS"
            };
        }

        private string result;

        [Benchmark(Baseline = true)]
        public void Original()
        {
            result = _filenameBuilder.BuildFilename(_dataContext);
        }

        [Benchmark]
        public void StringBuilder()
        {
            result = _filenameBuilder.BuildFilenameWithStringBuilder(_dataContext);
        }

        [Benchmark]
        public void StringCreateOptimised()
        {
            result = _filenameBuilder.BuildFilenameWithStringCreate(_dataContext);
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
