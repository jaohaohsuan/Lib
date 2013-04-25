using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class SearchAlgorithmTests
    {
        [Test]
        public void IsolateShuoldBeFindAssertTrueTest()
        {
            var source = new Dictionary<int, bool>();

            source[-4] = true;
            source[-3] = false;
            source[-2] = false;
            source[-1] = true;
            source[0] = false; //*
            source[1] = false;  //*
            source[2] = false;  //*
            source[3] = true;
            source[4] = true;
            source[5] = true;
            source[6] = true;

            Func<int,bool> getValue = i => source.ContainsKey(i) ? source[i] : false;

            var result = SearchAlgorithm.HasIsolate(getValue, 0);
            Assert.IsTrue(result);

            result = SearchAlgorithm.HasIsolate(getValue, 1);
            Assert.IsTrue(result);

            result = SearchAlgorithm.HasIsolate(getValue, -1);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsolateShuoldBeFindAssertFalseTest()
        {
            var source = new Dictionary<int, bool>();

            source[-4] = true;
            source[-3] = false;
            source[-2] = false;
            source[-1] = true;
            source[0] = false; //*
            source[1] = false;  //*
            source[2] = false;  //*
            source[3] = true;
            source[4] = true;
            source[5] = true;
            source[6] = true;

            var result = SearchAlgorithm.HasIsolate(i => source[i], 2);
            Assert.IsFalse(result);
        }

        [Test]
        public void ReportIsolatePostionIsMinus1AssertTrueTest()
        {
            var source = new Dictionary<int, bool>();

            source[-4] = true;
            source[-3] = false;
            source[-2] = false;
            source[-1] = true;
            source[0] = false; //*
            source[1] = false;  //*
            source[2] = false;  //*
            source[3] = true;
            source[4] = true;
            source[5] = true;
            source[6] = true;

            var result = SearchAlgorithm.ReportIsolate(i => source[i], 1);
            Assert.IsTrue(result.Contains(-1));
        }
    }
}
