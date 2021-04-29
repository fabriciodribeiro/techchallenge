using System;
using System.Collections.Generic;
using System.Text;
using TechChallangeClassLibrary.Enum;

namespace TechChallangeClassLibrary.Models
{
    public class FileShare : Output
    {
        public string URL { get; private set; }
        public string ApiKey { get; private set; }

        public FileShare(string name, OutputType type, string url, string apiKey) : base(name, type)
        {
            URL = url;
            ApiKey = apiKey;
        }

        public override bool Send()
        {
            //TODO: To be implemented the method to send the file to FileShare
            Console.WriteLine($"Sending the file { Name } to FileShare { URL }");
            return true;
        }
    }
}