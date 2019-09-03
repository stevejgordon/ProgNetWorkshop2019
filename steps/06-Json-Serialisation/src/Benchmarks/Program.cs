using System;
using System.Buffers;
using System.IO;
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
            var result = BenchmarkRunner.Run<JsonBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class JsonBenchmarks
    {
        public byte[] _bytes;
 
        [GlobalSetup]
        public void Setup()
        {
            var json = @"{""Drivers"":[{""givenName"":""Carlo"",""familyName"":""Abate"",""dateOfBirth"":""1932-07-10"",""nationality"":""Italian""},{""givenName"":""George"",""familyName"":""Abecassis"",""dateOfBirth"":""1913-03-21"",""nationality"":""British""},{""givenName"":""Kenny"",""familyName"":""Acheson"",""dateOfBirth"":""1957-11-27"",""nationality"":""British""},{""givenName"":""Philippe"",""familyName"":""Adams"",""dateOfBirth"":""1969-11-19"",""nationality"":""Belgian""},{""givenName"":""Walt"",""familyName"":""Ader"",""dateOfBirth"":""1913-12-15"",""nationality"":""American""},{""givenName"":""Kurt"",""familyName"":""Adolff"",""dateOfBirth"":""1921-11-05"",""nationality"":""German""},{""givenName"":""Fred"",""familyName"":""Agabashian"",""dateOfBirth"":""1913-08-21"",""nationality"":""American""},{""givenName"":""Kurt"",""familyName"":""Ahrens"",""dateOfBirth"":""1940-04-19"",""nationality"":""German""}]}";

            _bytes = Encoding.UTF8.GetBytes(json);
        }

        [Benchmark(Baseline = true)]
        public void Newtonsoft()
        {
            var json = JsonDataWorker.DeserialiseAndSerialiseNewtonsoft(_bytes);
        }

        [Benchmark]
        public void Microsoft()
        {
            var json = JsonDataWorker.DeserialiseAndSerialiseMicrosoft(_bytes);
        }
    }

    [MemoryDiagnoser]
    public class MultiplierBenchmarks
    {
        public static int _size = 1000;

        [Benchmark(Baseline = true)]
        public void Original()
        {
            var array = new int[_size];
            Multiplier.CalculateMultiplesOfTwo(array, _size);
            // do something with the data
        }

        [Benchmark]
        public void ArrayPool()
        {
            var array = ArrayPool<int>.Shared.Rent(_size);

            try
            {
                Multiplier.CalculateMultiplesOfTwo(array, _size);
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
