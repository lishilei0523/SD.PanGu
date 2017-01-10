using PanGu.Settings;
using System.IO;

namespace Lucene.Net.Analysis.PanGu
{
    public class PanGuAnalyzer : Analyzer
    {
        private bool _OriginalResult = false;
        private MatchOption _options;
        private MatchParameter _parameters;

        public PanGuAnalyzer()
        {
        }

        public PanGuAnalyzer(MatchOption options, MatchParameter parameters)
            : base()
        {
            _options = options;
            _parameters = parameters;
        }

        /// <summary>
        /// Return original string.
        /// Does not use only segment
        /// </summary>
        /// <param name="originalResult"></param>
        public PanGuAnalyzer(bool originalResult)
        {
            _OriginalResult = originalResult;
        }

        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            TokenStream result = new PanGuTokenizer(reader, _OriginalResult, _options, _parameters);
            result = new LowerCaseFilter(result);
            return result;
        }
    }


}
