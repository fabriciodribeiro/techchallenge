using System;
using Enum;

namespace Models
{
    public class Output
    {
        public string Name { get; private set; }
        public OutputType Type { get; private set; }
        public string Path { get; private set; }

        public Output(string name, OutputType type, string path)
        {
            Name = name;
            Type = type;
            Path = path;
        }
    }
}
