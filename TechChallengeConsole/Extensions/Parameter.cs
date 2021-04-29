using CommandLine;
using System.Collections.Generic;

namespace TechChallengeConsole.Extensions
{
    public class Parameter
    {
        [Option('f', "folder", Required = true, HelpText = "Indicates the folder to be ziped.")]
        public string Folder { get; set; }

        [Option('d', "destination", Required = true, HelpText = "Destination ZIP file to be created with the folder content.")]
        public string File { get; set; }

        [Option('o', "output", Required = true, Default = "local", HelpText = "Indicates where the destination zip file will be stored (e.g. Local, FileShare, WeTransfer).")]
        public string Output { get; set; }

        [Option("extensions", Required = false, Separator = ',', HelpText = "Comma separeted File Extensions to be excluded from the destination ZIP file. e.g. --extensions .bmp,.jpg,.txt")]
        public IEnumerable<string> Extensions { get; set; }

        [Option("directories", Required = false, Separator = ',', HelpText = "Directories to be excluded from the destination ZIP file. e.g. --directories old,git")]
        public IEnumerable<string> Directories { get; set; }

        [Option("files", Required = false, Separator = ',', HelpText = "Files to be excluded from the destination ZIP file. e.g. --files ficheiro1.doc,filcheiro2.txt")]
        public IEnumerable<string> Files { get; set; }

        [Option("fileshare", Required = false, Separator = ',', HelpText = "Fileshare's information like API Key. e.g. --fileshare FILE_SHARE_KEY")]
        public IEnumerable<string> Fileshare { get; set; }

        [Option("wetransfer", Required = false, Separator = ',', HelpText = "WeTransfer's information like API Key. e.g. --wetransfer WE_TRANSFER_KEY")]
        public IEnumerable<string> Wetransfer { get; set; }
    }
}