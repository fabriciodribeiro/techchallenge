using System;
using TechChallangeClassLibrary.Enum;
using TechChallangeClassLibrary.Interfaces;

namespace TechChallangeClassLibrary.Models
{
    public abstract class Output : IOutput, IDisposable
    {
        public string Name { get;  }
        public OutputType Type { get; }

        private bool _disposed = false;

        public Output(string name, OutputType type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Implementing Dispose Pattern to release managed resources
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //libera recursos gerenciados pela CLR
            }

            //else: libera recursos não gerenciados pela CLR

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract bool Send();
    }
}