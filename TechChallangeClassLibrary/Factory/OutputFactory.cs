using Models;
using Enum;

namespace Factory
{
    public class OutputFactory
    {
        public static Output NewOutPut(string name, OutputType type, string path)
        {
            return new Output(name, type, path);
        }
    }
}