using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechChallangeClassLibrary.Enum;
using TechChallangeClassLibrary.Factory;

namespace TechChallengeUnitTest
{
    [TestClass]
    public class OutputUnitTest
    {
        [TestMethod]
        [TestCategory("Output")]
        public void given_parametes_create_a_local_output()
        {
            //simulate params passed as argument in console
            string paramFile = "ZipFile.zip";
            OutputType outputType = OutputType.Local;
            string paramFolder = "C:\\Temp";
            Dictionary<string, IEnumerable<string>> apiKeyDictionary = new Dictionary<string, IEnumerable<string>>();

            //using the factory it must return a new Local output object
            var output = OutputFactory.NewOutput(paramFile, outputType, paramFolder, apiKeyDictionary);

            Assert.AreEqual(output.Type, OutputType.Local);
        }

        [TestMethod]
        [TestCategory("Output")]
        public void given_parametes_create_a_fileshare_output()
        {
            //simulate params passed as argument in console
            string paramFile = "ZipFile.zip";
            OutputType outputType = OutputType.FileShare;
            string paramFolder = "C:\\Temp";
            Dictionary<string, IEnumerable<string>> apiKeyDictionary = new Dictionary<string, IEnumerable<string>>();
            apiKeyDictionary.Add(OutputType.FileShare.ToString(), new string[] { "https://fileshare.nl/en/home/", "192BBE205ED6" });

            //using the factory it must return a new FileShare output object
            var output = OutputFactory.NewOutput(paramFile, outputType, paramFolder, apiKeyDictionary);

            Assert.AreEqual(output.Type, OutputType.FileShare);
        }

        [TestMethod]
        [TestCategory("Output")]
        public void given_parametes_create_a_wetransfer_output()
        {
            //simulate params passed as argument in console
            string paramFile = "ZipFile.zip";
            OutputType outputType = OutputType.WeTransfer;
            string paramFolder = "C:\\Temp";
            Dictionary<string, IEnumerable<string>> apiKeyDictionary = new Dictionary<string, IEnumerable<string>>();
            apiKeyDictionary.Add(OutputType.FileShare.ToString(), new string[] { "https://wetransfer.com/", "B4134479.7F7F" });

            //using the factory it must return a new WeTransfer output object
            var output = OutputFactory.NewOutput(paramFile, outputType, paramFolder, apiKeyDictionary);

            Assert.AreEqual(output.Type, OutputType.WeTransfer);
        }
        
    }
}