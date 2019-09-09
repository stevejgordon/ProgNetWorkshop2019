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
            var result = BenchmarkRunner.Run<JsonBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class JsonBenchmarks
    {
        private byte[] _bytes;
 
        [GlobalSetup]
        public void Setup()
        {
            const string json = @"{""Drivers"":[{""GivenName"":""Carlo"",""FamilyName"":""Abate"",""DateOfBirth"":""1932-07-10"",""Nationality"":""Italian""},{""GivenName"":""George"",""FamilyName"":""Abecassis"",""DateOfBirth"":""1913-03-21"",""Nationality"":""British""},{""GivenName"":""Kenny"",""FamilyName"":""Acheson"",""DateOfBirth"":""1957-11-27"",""Nationality"":""British""},{""GivenName"":""Philippe"",""FamilyName"":""Adams"",""DateOfBirth"":""1969-11-19"",""Nationality"":""Belgian""},{""GivenName"":""Walt"",""FamilyName"":""Ader"",""DateOfBirth"":""1913-12-15"",""Nationality"":""American""},{""GivenName"":""Kurt"",""FamilyName"":""Adolff"",""DateOfBirth"":""1921-11-05"",""Nationality"":""German""},{""GivenName"":""Fred"",""FamilyName"":""Agabashian"",""DateOfBirth"":""1913-08-21"",""Nationality"":""American""},{""GivenName"":""Kurt"",""FamilyName"":""Ahrens"",""DateOfBirth"":""1940-04-19"",""Nationality"":""German""}]}";

            _bytes = Encoding.UTF8.GetBytes(json);
        }
       
        [Benchmark(Baseline = true)]
        public void Newtonsoft()
        {
            _ = JsonDataWorker.DeserialiseAndSerialiseNewtonsoft(_bytes);
        }


        [Benchmark]
        public void Microsoft()
        {
            _ = JsonDataWorker.DeserialiseAndSerialiseMicrosoft(_bytes);
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
