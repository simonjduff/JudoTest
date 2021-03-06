﻿using System.Collections.Generic;
using JudoTest.App.Implementations;
using JudoTest.App.Interfaces;
using Moq;
using NUnit.Framework;

namespace JudoTest.Tests
{
    [TestFixture]
    public class JudoTestTests
    {
        private Mock<IFileService> _fileService;
        private IJudoTestApp _judoTestApp;
        private Mock<IWordSplitter> _wordSplitter;
        private string _filename;
        private Mock<IWordCounter> _wordCounter;
        private FakeConsole _console;
        private Mock<ICompoundFilter> _compoundFilter;

        [SetUp]
        public void Setup()
        {
            _fileService = new Mock<IFileService>();
            _wordSplitter = new Mock<IWordSplitter>();
            _wordCounter = new Mock<IWordCounter>();
            _wordCounter.Setup(q => q.Count(It.IsAny<string[]>())).Returns(new Dictionary<string, int>());
            _console = new FakeConsole();
            _compoundFilter = new Mock<ICompoundFilter>();
            _judoTestApp = new JudoTestApp(_fileService.Object, _wordSplitter.Object, _wordCounter.Object, _console, _compoundFilter.Object);
        }

        [Test]
        public void JudoTestApp_LoadsFile()
        {
            _filename = "fakeFilename.txt";
            _judoTestApp.Run(_filename);
            _fileService.Verify(q => q.ReadAllText(_filename));
        }

        [Test]
        public void JudoTestApp_SplitsData()
        {
            var inputData = "one two three one";
            _fileService.Setup(q => q.ReadAllText(It.IsAny<string>())).Returns(inputData);
            _judoTestApp.Run(_filename);

            _wordSplitter.Verify(q => q.Split(inputData));
        }

        [Test]
        public void JudoTestApp_CountsWords()
        {
            var inputData = new[] {"one", "two", "three", "one"};
            _wordSplitter.Setup(q => q.Split(It.IsAny<string>())).Returns(inputData);
            _judoTestApp.Run(_filename);
            
            _wordCounter.Verify(q => q.Count(inputData));
        }

        [Test]
        public void JudoTestApp_PrintsCounts()
        {
            var inputData = new Dictionary<string, int>();
            inputData.Add("one", 2);
            inputData.Add("two", 3);
            inputData.Add("three", 5);

            _wordCounter.Setup(q => q.Count(It.IsAny<string[]>())).Returns(inputData);

            _judoTestApp.Run(_filename);

            Assert.AreEqual("            one              2", _console.OutputLines[0]);
            Assert.AreEqual("          three              5", _console.OutputLines[1]);
            Assert.AreEqual("            two              3", _console.OutputLines[2]);
        }

        [Test]
        public void JudoTestApp_FiltersCompounds()
        {
            var inputData =
                new[] {"al", "albums", "aver", "bar", "barely", "be", "befoul", "bums", "by", "cat", "con", "convex", "ely",
                    "foul", "here", "hereby", "jig", "jigsaw", "or", "saw", "tail", "tailor", "vex", "we", "weaver"};
            _wordSplitter.Setup(q => q.Split(It.IsAny<string>())).Returns(inputData);
            _judoTestApp.Run(_filename);

            _compoundFilter.Verify(q => q.Filter(inputData));
        }

        [Test]
        public void JudoTestApp_PrintsCompounds()
        {
            var inputData = new[] {"one", "two", "three"};
            _compoundFilter.Setup(q => q.Filter(It.IsAny<string[]>())).Returns(inputData);
            _judoTestApp.Run(_filename);

            Assert.AreEqual("one", _console.OutputLines[0]);
            Assert.AreEqual("three", _console.OutputLines[1]);
            Assert.AreEqual("two", _console.OutputLines[2]);
        }

        public class FakeConsole : IConsole
        {
            public FakeConsole()
            {
                OutputLines = new List<string>();
            }
            public List<string> OutputLines { get; set; }
            public void WriteLine(string message, params object[] formatterStrings)
            {
                OutputLines.Add(string.Format(message, formatterStrings));
            }
        }
    }
}
