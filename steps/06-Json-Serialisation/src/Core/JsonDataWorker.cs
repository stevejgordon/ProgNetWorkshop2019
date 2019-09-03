using Newtonsoft.Json;
using System;
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

        public static string DeserialiseAndSerialiseMicrosoft(ReadOnlySpan<byte> json)
        {
            var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var drivers = System.Text.Json.JsonSerializer.Deserialize<FormulaOneDriverData>(json, options);

            return System.Text.Json.JsonSerializer.Serialize(drivers);
        }


        //public static void DeserialiseAndSerialiseNewtonsoft(Stream data)
        //{
        //    using StreamReader sr = new StreamReader(data, Encoding.UTF8, false, 1024, leaveOpen: true);
        //    using JsonReader reader = new JsonTextReader(sr);

        //    JsonSerializer serializer = new JsonSerializer();

        //    var drivers = serializer.Deserialize<FormulaOneDriversData>(reader);

        //    var stringJson = JsonConvert.SerializeObject(drivers);
        //}

        //public static async Task DeserialiseAndSerialiseMicrosoft(Stream data)
        //{
        //    var options = new System.Text.Json.JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };

        //    var drivers = await System.Text.Json.JsonSerializer.DeserializeAsync<FormulaOneDriversData>(data, options);

        //    var stringJson = System.Text.Json.JsonSerializer.Serialize(drivers);
        //}

        private class FormulaOneDriverData
        {
            public Driver[] Drivers { get; set; }
        }

        private class Driver
        {
            public string GivenName { get; set; }
            public string FamilyName { get; set; }
            public string DateOfBirth { get; set; }
            public string Nationality { get; set; }
        }
    }
}
