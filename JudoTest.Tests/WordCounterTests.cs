using System.CodeDom;
using JudoTest.App.Implementations;
using JudoTest.App.Interfaces;
using NUnit.Framework;

namespace JudoTest.Tests
{
    [TestFixture]
    public class WordCounterTests
    {
        [Test]
        public void WordCounter_CountsBasicWords()
        {
            string[] inputData = new[] {"one", "two", "three", "one"};
            IWordCounter counter = new WordCounter();
            var result = counter.Count(inputData);

            Assert.AreEqual(3, result.Keys.Count);

            Assert.AreEqual(2, result["one"]);
            Assert.AreEqual(1, result["two"]);
            Assert.AreEqual(1, result["three"]);
        }

        [Test]
        public void WordCounter_IgnoresCase()
        {
            string[] inputData = new[] { "one", "two", "three", "One" };
            IWordCounter counter = new WordCounter();
            var result = counter.Count(inputData);

            Assert.AreEqual(3, result.Keys.Count);

            Assert.AreEqual(2, result["one"]);
            Assert.AreEqual(1, result["two"]);
            Assert.AreEqual(1, result["three"]);
        }
    }
}