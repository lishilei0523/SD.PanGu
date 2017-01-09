using System.Collections.Generic;
using System.IO;
using System.Text;
using PanGu.Enums;
using PanGu.Match;
using PanGu.Setting;

namespace PanGu.Dictionaries
{
    /// <summary>
    /// 通配符词汇
    /// </summary>
    class Wildcard
    {
        internal class WildcardInfo
        {
            public string Key;

            public List<WordInfo> Segments = new List<WordInfo>();

            public WildcardInfo(string wildcard, Segment segment,
                MatchOptions options, MatchParameter parameter)
            {
                this.Key = wildcard.ToLower();

                this.Segments.Add(new WordInfo(wildcard, POS.POS_UNK, 0));

                foreach (WordInfo wordInfo in segment.DoSegment(wildcard, options, parameter))
                {
                    if (wordInfo.Word != wildcard)
                    {
                        this.Segments.Add(wordInfo);
                    }
                }
            }
        }

        object _LockObj = new object();

        bool _Init = false;
        MatchOptions _Options;
        MatchParameter _Parameter;

        List<WildcardInfo> _WildcardList = null; //通配符词汇列表

        private void LoadWildcard(string fileName)
        {
            lock (this._LockObj)
            {
                this._WildcardList = new List<WildcardInfo>();

                if (!File.Exists(fileName))
                {
                    return;
                }

                Segment segment = new Segment();

                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();

                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        this._WildcardList.Add(new WildcardInfo(line, segment, this._Options, this._Parameter));
                    }
                }

                this._Init = true;
            }
        }

        internal Wildcard(MatchOptions options, MatchParameter parameter)
        {
            this._Options = options.Clone();
            this._Options.SynonymOutput = false;
            this._Options.WildcardOutput = false;

            this._Parameter = parameter.Clone();
        }

        internal bool Inited
        {
            get
            {
                lock (this._LockObj)
                {
                    return this._Init;
                }
            }
        }

        public void Load(string dictPath)
        {
            this.LoadWildcard(dictPath + Constants.WildcardFileName);
        }

        private void Load()
        {
            lock (this._LockObj)
            {
                if (!this._Init)
                {
                    string dir = PanGuSettings.Config.GetDictionaryPath();
                    this.Load(dir);
                }
            }
        }

        internal List<WildcardInfo> GetWildcards(string word)
        {
            lock (this._LockObj)
            {
                if (!this._Init)
                {
                    this.Load();
                }
            }

            if (string.IsNullOrEmpty(word))
            {
                return null;
            }

            lock (this._LockObj)
            {
                word = word.ToLower().Trim();

                List<WildcardInfo> result = new List<WildcardInfo>();

                foreach (WildcardInfo wi in this._WildcardList)
                {
                    if (wi.Key.Contains(word))
                    {
                        result.Add(wi);
                    }
                }

                return result;
            }
        }
    }
}
