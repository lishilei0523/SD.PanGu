
namespace PanGuConfig.Configurations
{
    public class MatchOption
    {
        public bool ChineseNameIdentify { get; set; }
        public bool FrequencyFirst { get; set; }
        public bool MultiDimensionality { get; set; }
        public bool EnglishMultiDimensionality { get; set; }
        public bool FilterStopWords { get; set; }
        public bool IgnoreSpace { get; set; }
        public bool ForceSingleWord { get; set; }
        public bool TraditionalChineseEnabled { get; set; }
        public bool OutputSimplifiedTraditional { get; set; }
        public bool UnknownWordIdentify { get; set; }
        public bool FilterEnglish { get; set; }
        public bool FilterNumeric { get; set; }
        public bool IgnoreCapital { get; set; }
        public bool EnglishSegment { get; set; }
        public bool SynonymOutput { get; set; }
        public bool WildcardOutput { get; set; }
        public bool WildcardSegment { get; set; }
        public bool CustomRule { get; set; }
    }
}
