using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class JudoTestApp : IJudoTestApp
    {
        private readonly IFileService _fileService;
        private readonly IWordSplitter _wordSplitter;
        private IWordCounter _wordCounter;

        public JudoTestApp(IFileService fileService, IWordSplitter wordSplitter, IWordCounter wordCounter)
        {
            _wordCounter = wordCounter;
            _wordSplitter = wordSplitter;
            _fileService = fileService;
        }

        public void Run(string filename)
        {
            var text = _fileService.ReadAllText(filename);
            var words = _wordSplitter.Split(text);
            var counts = _wordCounter.Count(words);
        }
    }
}