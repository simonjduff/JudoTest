using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class JudoTestApp : IJudoTestApp
    {
        private readonly IFileService _fileService;
        private IWordSplitter _wordSplitter;

        public JudoTestApp(IFileService fileService, IWordSplitter wordSplitter)
        {
            _wordSplitter = wordSplitter;
            _fileService = fileService;
        }

        public void Run(string filename)
        {
            var text = _fileService.ReadAllText(filename);
            var words = _wordSplitter.Split(text);
        }
    }
}