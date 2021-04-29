using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using TechChallengeConsole.Extensions;
using TechChallangeClassLibrary.Enum;
using TechChallangeClassLibrary.Factory;
using CommandLine;
using System.Collections.Generic;

namespace TechChallengeConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter parameter values.");
                return;
            }
            else
            {
                CommandLine.Parser.Default.ParseArguments<Parameter>(args)
                    .WithParsed(Run)
                    .WithNotParsed(HandleParseError);
            }
        }

        public static void Run(Parameter param)
        {
            string tempStorage = $@"Resources";
            Dictionary<string, IEnumerable<string>> apiKeyDictionary = new Dictionary<string, IEnumerable<string>>();
            string[] fileEntries = Directory.GetFiles(param.Folder, "*.*", SearchOption.AllDirectories);

            OutputType outputType = OutputType.Local;
            if (param.Output == "fileshare")
                outputType = OutputType.FileShare;
            else if (param.Output == "wetransfer")
                outputType = OutputType.WeTransfer;
            apiKeyDictionary.Add(OutputType.FileShare.ToString(), param.Fileshare);
            apiKeyDictionary.Add(OutputType.WeTransfer.ToString(), param.Wetransfer);

            var output = OutputFactory.NewOutput(param.File, outputType, param.Folder, apiKeyDictionary);
            
            PrepareFolder(tempStorage, param.File);

            DirectoryInfo from = new DirectoryInfo(param.Folder);
            using (FileStream zipToOpen = new FileStream($@"{tempStorage}\{param.File}", FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (FileInfo file in from.AllFilesAndFolders().Where(o => o is FileInfo).Cast<FileInfo>())
                    {
                        if (param.Extensions != null && param.Extensions.Any(x => x.ToLowerInvariant() == file.Extension.ToLowerInvariant()))
                            continue;
                        if (param.Directories != null && param.Directories.Any(x => file.DirectoryName.ToLowerInvariant().EndsWith(x.ToLowerInvariant())))
                            continue;
                        if (param.Files != null && param.Files.Any(x => x.ToLowerInvariant() == file.Name.ToLowerInvariant()))
                            continue;
                        var relPath = file.FullName.Substring(from.FullName.Length + 1);
                        ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(file.FullName, relPath);
                    }
                }
            }

            output.Send();
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Please re-run the program with the proper parameter.");
            Console.WriteLine("--help to see the parameters.");
        }

        private static void PrepareFolder(string directory, string file)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (File.Exists($@"{directory}\{file}"))
                File.Delete($@"{directory}\{file}");
        }

    }
}
