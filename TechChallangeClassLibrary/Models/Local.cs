using System;
using System.IO;
using TechChallangeClassLibrary.Enum;

namespace TechChallangeClassLibrary.Models
{
    public class Local : Output
    {
        public string Path { get; private set; }

        public Local(string name, OutputType type, string path) : base(name, type)
        {
            Path = path;
        }

        public override bool Send()
        {
            try
            {
                string sourcePath = $@"Resources";
                string targetPath = Path;

                string sourceFile = System.IO.Path.Combine(sourcePath, Name);
                string destFile = System.IO.Path.Combine(targetPath, Name);

                File.Copy(sourceFile, destFile, true);

                Console.WriteLine($"Saving file { Name } to Local path { Path }");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}