using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PanGu.Tests
{
    /// <summary>
    /// 配置测试
    /// </summary>
    [TestClass]
    public class ConfigurationsTests
    {
        /// <summary>
        /// 测试字典路径
        /// </summary>
        [TestMethod]
        public void TestDictionaryPath()
        {
            PanGuConfiguration setting = PanGuConfiguration.Setting;

            Assert.AreEqual(setting.DictionaryPathElement.Path, @"DictionaryFiles");
        }

        /// <summary>
        /// 测试匹配选项
        /// </summary>
        [TestMethod]
        public void TestMatchOptions()
        {
            PanGuConfiguration setting = PanGuConfiguration.Setting;

            Assert.AreEqual(setting.MatchOptionsElement.ChineseNameIdentifyElement.Enabled, true);
            Assert.AreEqual(setting.MatchOptionsElement.FrequencyFirstElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.MultiDimensionalityElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.EnglishMultiDimensionalityElement.Enabled, true);
            Assert.AreEqual(setting.MatchOptionsElement.FilterStopWordsElement.Enabled, true);
            Assert.AreEqual(setting.MatchOptionsElement.IgnoreSpaceElement.Enabled, true);
            Assert.AreEqual(setting.MatchOptionsElement.ForceSingleWordElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.TraditionalChineseEnabledElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.OutputSimplifiedTraditionalElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.UnknownWordIdentifyElement.Enabled, true);
            Assert.AreEqual(setting.MatchOptionsElement.FilterEnglishElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.FilterNumericElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.IgnoreCapitalElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.EnglishSegmentElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.SynonymOutputElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.WildcardOutputElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.WildcardSegmentElement.Enabled, false);
            Assert.AreEqual(setting.MatchOptionsElement.CustomRuleElement.Enabled, false);
        }

        /// <summary>
        /// 测试匹配参数
        /// </summary>
        [TestMethod]
        public void TestMatchParameters()
        {
            PanGuConfiguration setting = PanGuConfiguration.Setting;

            Assert.AreEqual(setting.MatchParametersElement.UnknowRankElement.Rank, 1);
            Assert.AreEqual(setting.MatchParametersElement.BestRankElement.Rank, 5);
            Assert.AreEqual(setting.MatchParametersElement.SecRankElement.Rank, 3);
            Assert.AreEqual(setting.MatchParametersElement.ThirdRankElement.Rank, 2);
            Assert.AreEqual(setting.MatchParametersElement.SingleRankElement.Rank, 1);
            Assert.AreEqual(setting.MatchParametersElement.NumericRankElement.Rank, 1);
            Assert.AreEqual(setting.MatchParametersElement.EnglishRankElement.Rank, 5);
            Assert.AreEqual(setting.MatchParametersElement.EnglishLowerRankElement.Rank, 3);
            Assert.AreEqual(setting.MatchParametersElement.EnglishStemRankElement.Rank, 2);
            Assert.AreEqual(setting.MatchParametersElement.SymbolRankElement.Rank, 1);
            Assert.AreEqual(setting.MatchParametersElement.SimplifiedTraditionalRankElement.Rank, 1);
            Assert.AreEqual(setting.MatchParametersElement.SynonymRankElement.Rank, 1);
            Assert.AreEqual(setting.MatchParametersElement.WildcardRankElement.Rank, 1);
            Assert.AreEqual(setting.MatchParametersElement.FilterEnglishLengthElement.Length, 0);
            Assert.AreEqual(setting.MatchParametersElement.FilterNumericLengthElement.Length, 0);
            Assert.AreEqual(setting.MatchParametersElement.CustomRuleAssemblyFileNameElement.Name, "CustomRuleExample.dll");
            Assert.AreEqual(setting.MatchParametersElement.CustomRuleFullClassNameElement.Name, "CustomRuleExample.PickupVersion");
            Assert.AreEqual(setting.MatchParametersElement.RedundancyElement.Value, 0);
        }
    }
}
