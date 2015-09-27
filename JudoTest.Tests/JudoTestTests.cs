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

        [SetUp]
        public void Setup()
        {
            _fileService = new Mock<IFileService>();
            _wordSplitter = new Mock<IWordSplitter>();
            _judoTestApp = new JudoTestApp(_fileService.Object, _wordSplitter.Object);
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
    }
}
