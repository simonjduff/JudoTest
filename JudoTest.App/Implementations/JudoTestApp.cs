using System.Diagnostics;
using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class JudoTestApp : IJudoTestApp
    {
        private readonly IFileService _fileService;
        private readonly IWordSplitter _wordSplitter;
        private readonly IWordCounter _wordCounter;
        private readonly IConsole _console;

        public JudoTestApp(IFileService fileService, IWordSplitter wordSplitter, IWordCounter wordCounter, IConsole console)
        {
            _console = console;
            _wordCounter = wordCounter;
            _wordSplitter = wordSplitter;
            _fileService = fileService;
        }

        public void Run(string filename)
        {
            var text = _fileService.ReadAllText(filename);
            var words = _wordSplitter.Split(text);
            var counts = _wordCounter.Count(words);

            foreach (var count in counts.Keys)
            {
                _console.WriteLine("{0,15}{1,15}", count, counts[count]);
            }
        }
    }
}