using System.IO;

namespace PayloadParsing
{
    public class ResponseParser
    {
        public ResponseParserResult ParseStream(Stream stream)
        {

        }
    }

    public class ResponseParserResult
    {
        public string Id { get; set; } 
        public string[] Errors { get; set; }
    }

    public class Payload
    {
        public int Took { get; set; }
        public bool Errors { get; set; }
    }

    public class PayloadItem
    {

    }
}
