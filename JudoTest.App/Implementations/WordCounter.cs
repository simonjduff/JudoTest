using System.Collections.Generic;
using System.Linq;
using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class WordCounter : IWordCounter
    {
        public IDictionary<string, int> Count(string[] inputData)
        {
            var result = new Dictionary<string, int>();

            foreach (var word in inputData.Select(q => q.ToLowerInvariant()))
            {
                if (!result.ContainsKey(word))
                {
                    result.Add(word, 0);
                }

                result[word]++;
            }

            return result;
        }
    }
}