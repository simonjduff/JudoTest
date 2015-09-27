using JudoTest.App.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using JudoTest.App.Implementations;

namespace JudoTest.Tests
{
    [TestFixture]
    public class WordSplitterTests
    {
        private IWordSplitter _wordSplitter;

        [SetUp]
        public void Setup()
        {
            _wordSplitter = new WordSplitter();
        }

        [Test]
        public void WordSplitter_SplitsWordsSeparatedBySpaces()
        {
            var words = "one two three one";
            var result = _wordSplitter.Split(words);
            Assert.AreEqual(new[] { "one", "two", "three", "one" }, result);
        }

        [Test]
        public void WordSplitter_WhenEmptyInput_ReturnsEmptyArray()
        {
            var words = string.Empty;
            var result = _wordSplitter.Split(words);
            Assert.AreEqual(new string[0], result);
        }

        [Test]
        public void WordSplitter_IgnoresSpecialCharacters()
        {
            var words = "one 'two' three! one:";
            var result = _wordSplitter.Split(words);
            Assert.AreEqual(new[] { "one", "two", "three", "one" }, result);
        }

        [Test]
        public void WordSplitter_ChecksAcrossNewlines()
        {
            var words = "one two\r\nthree one";
            var result = _wordSplitter.Split(words);
            Assert.AreEqual(new[] { "one", "two", "three", "one" }, result);
        }
    }
}