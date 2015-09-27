using System.Linq;
using System.Text.RegularExpressions;
using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class WordSplitter : IWordSplitter
    {
        private static readonly Regex WordRegex = new Regex(@"(?<word>\w+)", RegexOptions.Compiled);
        public string[] Split(string inputData)
        {
            var matches = WordRegex.Matches(inputData);

            return (from Match match in matches where match.Success && match.Groups["word"].Success select match.Groups["word"].Value).ToArray();
        }
    }
}