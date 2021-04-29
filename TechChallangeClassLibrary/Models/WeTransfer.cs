using System;
using TechChallangeClassLibrary.Enum;

namespace TechChallangeClassLibrary.Models
{
    public class WeTransfer : Output
    {
        public string URL { get; private set; }
        public string ApiKey { get; private set; }

        public WeTransfer(string name, OutputType type, string url, string apiKey) : base(name, type)
        {
            URL = url;
            ApiKey = apiKey;
        }

        public override bool Send()
        {
            //TODO: To be implemented the method to send the file to WeTransfer
            Console.WriteLine($"Sending the file { Name } to WeTransfer { URL }");
            return true;
        }
    }
}