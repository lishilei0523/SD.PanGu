using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace PanGu.Tests
{
    /// <summary>
    /// 分词测试
    /// </summary>
    [TestClass]
    public class SegmentTests
    {
        /// <summary>
        /// 测试默认分词
        /// </summary>
        [TestMethod]
        public void TestDefaultSegment()
        {
            string text = "盘古分词简介: 盘古分词是由eaglet开发的一款基于字典的中英文分词组件";

            Segment segment = new Segment();
            ICollection<WordInfo> words = segment.DoSegment(text);

            foreach (WordInfo word in words)
            {
                Trace.WriteLine(word.Word);
            }

            Assert.AreEqual(words.Count, 17);
        }
    }
}
