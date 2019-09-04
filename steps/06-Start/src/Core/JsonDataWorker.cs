using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Core
{
    public static class JsonDataWorker
    {
        public static string DeserialiseAndSerialiseNewtonsoft(byte[] json)
        {
            using var stream = new MemoryStream(json);
            using var reader = new StreamReader(stream, Encoding.UTF8);
                       
            var drivers = JsonSerializer.Create().Deserialize(reader, typeof(FormulaOneDriverData)) as FormulaOneDriverData;

            return JsonConvert.SerializeObject(drivers);
        }

        public class FormulaOneDriverData
        {
            public Driver[] Drivers { get; set; }
        }

        public class Driver
        {
            public string GivenName { get; set; }
            public string FamilyName { get; set; }
            public string DateOfBirth { get; set; }
            public string Nationality { get; set; }
        }
    }
}
