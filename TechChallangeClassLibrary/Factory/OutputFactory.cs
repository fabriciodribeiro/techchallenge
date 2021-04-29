using TechChallangeClassLibrary.Models;
using TechChallangeClassLibrary.Enum;
using TechChallangeClassLibrary.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TechChallangeClassLibrary.Factory
{
    public class OutputFactory
    {
        /// <summary>
        /// Method that return a new object based on the Type
        /// to implement the Factory Pattern
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IOutput NewOutput(string name, OutputType type, string path, Dictionary<string, IEnumerable<string>> apiKeyDictionary)
        {
            if(type == OutputType.FileShare)
            {
                IEnumerable<string> parametersFileshare;
                apiKeyDictionary.TryGetValue(type.ToString(), out parametersFileshare);

                return NewFileshare(name, type, parametersFileshare);
            }
            else if (type == OutputType.WeTransfer)
            {
                IEnumerable<string> parametersWeTransfer;
                apiKeyDictionary.TryGetValue(type.ToString(), out parametersWeTransfer);

                return NewWeTransfer(name, type, parametersWeTransfer);
            }
            else
                return NewLocal(name, type, path);
        }

        /// <summary>
        /// Method that return a new object of Local
        /// to implement the Factory Pattern
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Local NewLocal(string name, OutputType type, string path)
        {
            return new Local(name, type, path);
        }

        /// <summary>
        /// Method that return a new object of FileShare
        /// to implement the Factory Pattern
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="keyParams"></param>
        /// <returns></returns>
        public static FileShare NewFileshare(string name, OutputType type, IEnumerable<string> keyParams)
        {
            string key = "";
            string url = "";
            
            if (keyParams != null)
            {
                url = keyParams.ElementAt(0);
                key = keyParams.ElementAt(1);
            }
            return new FileShare(name, type, url, key);
        }

        /// <summary>
        /// Method that return a new object of WeTransfer
        /// to implement the Factory Pattern
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="keyParams"></param>
        /// <returns></returns>
        public static WeTransfer NewWeTransfer(string name, OutputType type, IEnumerable<string> keyParams)
        {
            string key = "";
            string url = "";
            if (keyParams != null)
            {
                url = keyParams.ElementAt(0);
                key = keyParams.ElementAt(1);
            }
            return new WeTransfer(name, type, url, key);
        }
    }
}