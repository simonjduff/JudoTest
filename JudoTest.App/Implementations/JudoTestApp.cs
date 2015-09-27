using System.Diagnostics;
using System.Linq;
using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class JudoTestApp : IJudoTestApp
    {
        private readonly IFileService _fileService;
        private readonly IWordSplitter _wordSplitter;
        private readonly IWordCounter _wordCounter;
        private readonly IConsole _console;
        private ICompoundFilter _compoundFilter;

        public JudoTestApp(IFileService fileService, IWordSplitter wordSplitter, IWordCounter wordCounter, IConsole console, ICompoundFilter compoundFilter)
        {
            _compoundFilter = compoundFilter;
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

            foreach (var count in counts.Keys.OrderBy(q => q))
            {
                _console.WriteLine("{0,15}{1,15}", count, counts[count]);
            }

            var compounds = _compoundFilter.Filter(words);

            foreach (var word in compounds.OrderBy(q => q))
            {
                _console.WriteLine(word);
            }
        }
    }
}