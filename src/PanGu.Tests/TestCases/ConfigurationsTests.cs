using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PanGu.Tests.TestCases
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
            PanGuSection setting = PanGuSection.Setting;

            Assert.AreEqual(setting.DictionaryPathElement.Value, "Content/PanGu");
        }

        /// <summary>
        /// 测试匹配选项
        /// </summary>
        [TestMethod]
        public void TestMatchOptions()
        {
            PanGuSection setting = PanGuSection.Setting;

            Assert.AreEqual(setting.MatchOptionsElement.ChineseNameIdentifyElement.Value, true);
            Assert.AreEqual(setting.MatchOptionsElement.FrequencyFirstElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.MultiDimensionalityElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.EnglishMultiDimensionalityElement.Value, true);
            Assert.AreEqual(setting.MatchOptionsElement.FilterStopWordsElement.Value, true);
            Assert.AreEqual(setting.MatchOptionsElement.IgnoreSpaceElement.Value, true);
            Assert.AreEqual(setting.MatchOptionsElement.ForceSingleWordElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.TraditionalChineseEnabledElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.OutputSimplifiedTraditionalElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.UnknownWordIdentifyElement.Value, true);
            Assert.AreEqual(setting.MatchOptionsElement.FilterEnglishElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.FilterNumericElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.IgnoreCapitalElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.EnglishSegmentElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.SynonymOutputElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.WildcardOutputElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.WildcardSegmentElement.Value, false);
            Assert.AreEqual(setting.MatchOptionsElement.CustomRuleElement.Value, false);
        }

        /// <summary>
        /// 测试匹配参数
        /// </summary>
        [TestMethod]
        public void TestMatchParameters()
        {
            PanGuSection setting = PanGuSection.Setting;

            Assert.AreEqual(setting.MatchParametersElement.UnknowRankElement.Value, 1);
            Assert.AreEqual(setting.MatchParametersElement.BestRankElement.Value, 5);
            Assert.AreEqual(setting.MatchParametersElement.SecRankElement.Value, 3);
            Assert.AreEqual(setting.MatchParametersElement.ThirdRankElement.Value, 2);
            Assert.AreEqual(setting.MatchParametersElement.SingleRankElement.Value, 1);
            Assert.AreEqual(setting.MatchParametersElement.NumericRankElement.Value, 1);
            Assert.AreEqual(setting.MatchParametersElement.EnglishRankElement.Value, 5);
            Assert.AreEqual(setting.MatchParametersElement.EnglishLowerRankElement.Value, 3);
            Assert.AreEqual(setting.MatchParametersElement.EnglishStemRankElement.Value, 2);
            Assert.AreEqual(setting.MatchParametersElement.SymbolRankElement.Value, 1);
            Assert.AreEqual(setting.MatchParametersElement.SimplifiedTraditionalRankElement.Value, 1);
            Assert.AreEqual(setting.MatchParametersElement.SynonymRankElement.Value, 1);
            Assert.AreEqual(setting.MatchParametersElement.WildcardRankElement.Value, 1);
            Assert.AreEqual(setting.MatchParametersElement.FilterEnglishLengthElement.Value, 0);
            Assert.AreEqual(setting.MatchParametersElement.FilterNumericLengthElement.Value, 0);
            Assert.AreEqual(setting.MatchParametersElement.CustomRuleAssemblyFileNameElement.Value, "CustomRuleExample.dll");
            Assert.AreEqual(setting.MatchParametersElement.CustomRuleFullClassNameElement.Value, "CustomRuleExample.PickupVersion");
            Assert.AreEqual(setting.MatchParametersElement.RedundancyElement.Value, 0);
        }
    }
}
