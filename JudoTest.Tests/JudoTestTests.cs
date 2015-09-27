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
        [Test]
        public void JudoTestApp_LoadsFile()
        {
            var fileService = new Mock<IFileService>();
            IJudoTestApp judoTestApp = new JudoTestApp(fileService.Object);
            var filename = "fakeFilename.txt";
            judoTestApp.Run(filename);
            fileService.Verify(q => q.ReadAllText(filename));
        }
    }
}
