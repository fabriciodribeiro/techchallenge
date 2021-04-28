using Enum;
using Factory;
using System;

namespace TechChallengeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = OutputFactory.NewOutPut("LocalFile", OutputType.Local, "C:\\temp");
                        
            Console.WriteLine("Hello World!");
            Console.WriteLine($"Caminho {output.Path}");
            Console.ReadKey();
        }
    }
}
