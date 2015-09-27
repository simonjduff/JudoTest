using System.IO;
using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class FileService : IFileService
    {
        public string ReadAllText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}