using JudoTest.App.Implementations;
using JudoTest.App.Interfaces;
using NUnit.Framework;

namespace JudoTest.Tests
{
    [TestFixture]
    public class CompoundFilterTests
    {
        [Test]
        public void CompoundFilter_FindsCompounds()
        {
            var inputData = new[] {"al", "albums", "aver", "bar", "barely", "be", "befoul", "bums", "by", "cat", "con", "convex", "ely",
                    "foul", "here", "hereby", "jig", "jigsaw", "or", "saw", "tail", "tailor", "vex", "we", "weaver"};
            ICompoundFilter filter = new CompoundFilter();
            var results = filter.Filter(inputData);

            Assert.AreEqual("albums", results[0]);
            Assert.AreEqual("barely", results[1]);
            Assert.AreEqual("befoul", results[2]);
            Assert.AreEqual("convex", results[3]);
            Assert.AreEqual("hereby", results[4]);
            Assert.AreEqual("jigsaw", results[5]);
            Assert.AreEqual("tailor", results[6]);
            Assert.AreEqual("weaver", results[7]);
        }

        [Test]
        public void CompoundFilter_IgnoresCase()
        {
            var inputData = new[] {"al", "alBums", "aver", "bar", "barely", "be", "befoul", "bums", "by", "cat", "con", "convex", "ely",
                    "foul", "here", "hereby", "jig", "jigsaw", "or", "sAw", "tail", "tailor", "vex", "we", "weaver"};
            ICompoundFilter filter = new CompoundFilter();
            var results = filter.Filter(inputData);

            Assert.AreEqual("albums", results[0]);
            Assert.AreEqual("barely", results[1]);
            Assert.AreEqual("befoul", results[2]);
            Assert.AreEqual("convex", results[3]);
            Assert.AreEqual("hereby", results[4]);
            Assert.AreEqual("jigsaw", results[5]);
            Assert.AreEqual("tailor", results[6]);
            Assert.AreEqual("weaver", results[7]);
        }
    }
}