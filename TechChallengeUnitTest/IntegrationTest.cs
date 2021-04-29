using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechChallengeConsole.Extensions;

namespace TechChallengeUnitTest
{
    [TestClass]
    public class IntegrationTest
    {

        [TestMethod]
        [TestCategory("Integration")]
        public void given_parameters_send_ziped_file_to_local_output()
        {
            //Creates a parameter to test the Run method that sends the file to local path
            Parameter parameter = new Parameter();
            parameter.File = "Test.zip";
            parameter.Folder = "C:\\Temp";
            parameter.Output = "local";
            parameter.Directories = new string[] { "old", "backup" };
            parameter.Files = new string[] { "Main1.json"};
            
            TechChallengeConsole.Program.Run(parameter);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void given_parameters_send_ziped_file_to_filetransfer_output()
        {
            //Creates a parameter to test the Run method that sends the file to FileTransfer
            Parameter parameter = new Parameter();
            parameter.File = "TestFileTransfer.zip";
            parameter.Folder = "C:\\Temp";
            parameter.Output = "fileshare";
            parameter.Directories = new string[] { "backup" };
            parameter.Files = new string[] { "Main1.json" };
            //FileTransfer
            parameter.Fileshare = new string[] { "https://fileshare.nl/en/home/", "192BBE205ED6" };

            TechChallengeConsole.Program.Run(parameter);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void given_parameters_send_ziped_file_to_wetransfer_output()
        {
            //Creates a parameter to test the Run method that sends the file to FileTransfer
            Parameter parameter = new Parameter();
            parameter.File = "TestWeTransfer.zip";
            parameter.Folder = "C:\\Temp";
            parameter.Output = "wetransfer";
            parameter.Directories = new string[] { "old" };
            parameter.Files = new string[] { "Main2.json" };
            //WeTransfer
            parameter.Wetransfer = new string[] { "https://wetransfer.com/", "B4134479.7F7F" };

            TechChallengeConsole.Program.Run(parameter);
        }
    }
}