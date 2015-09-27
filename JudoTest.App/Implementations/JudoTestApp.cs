using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class JudoTestApp : IJudoTestApp
    {
        private readonly IFileService _fileService;

        public JudoTestApp(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Run(string filename)
        {
            _fileService.ReadAllText(filename);
        }
    }
}