using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [SetUp]
        public void Setup()
        {
            _fileService = new Mock<IFileService>();
            _wordSplitter = new Mock<IWordSplitter>();
            _wordCounter = new Mock<IWordCounter>();
            _judoTestApp = new JudoTestApp(_fileService.Object, _wordSplitter.Object, _wordCounter.Object);
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
    }
}
