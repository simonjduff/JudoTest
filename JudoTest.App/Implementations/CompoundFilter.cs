using System.Collections.Generic;
using System.Linq;
using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class CompoundFilter : ICompoundFilter
    {
        public string[] Filter(string[] inputData)
        {
            List<string> sortedData = inputData.OrderBy(q => q).Select(q => q.ToLowerInvariant()).ToList();

            var compounds = new List<string>();

            foreach (var word in sortedData)
            {
                for (int i = 1; i < word.Length; i++)
                {
                    var left = word.Substring(0, i);
                    var right = word.Substring(i);

                    if (!compounds.Contains(word) && sortedData.BinarySearch(left) >= 0 &&
                        sortedData.BinarySearch(right) >= 0)
                    {
                        compounds.Add(word);
                    }
                }
            }

            return compounds.ToArray();
        }
    }
}