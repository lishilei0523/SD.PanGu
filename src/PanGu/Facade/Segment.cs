﻿using Microsoft.VisualBasic;
using PanGu.Dictionaries;
using PanGu.Enums;
using PanGu.Framework;
using PanGu.Match;
using PanGu.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PanGu
{
    /// <summary>
    /// 分词器
    /// </summary>
    public class Segment
    {
        #region Constants and Fields

        //const string PATTERNS = @"[０-９\d]+\%|[０-９\d]{1,2}月|[０-９\d]{1,2}日|[０-９\d]{1,4}年|" +
        //@"[０-９\d]{1,4}-[０-９\d]{1,2}-[０-９\d]{1,2}|" +
        //@"\s+|" +
        //@"[０-９\d]+|[^ａ-ｚＡ-Ｚa-zA-Z0-9０-９\u4e00-\u9fa5]|[ａ-ｚＡ-Ｚa-zA-Z]+|[\u4e00-\u9fa5]+";
        const string PATTERNS = @"([０-９\d]+)|([ａ-ｚＡ-Ｚa-zA-Z_]+)";

        private static object _LockObj = new object();
        private static bool _Inited = false;
        private static DictionaryLoader _DictLoader;
        private static Dictionary<string, string> _InfinitiveVerbTable = null;
        internal static WordDictionary _WordDictionary = null;
        internal static ChsName _ChsName = null;
        internal static StopWord _StopWord = null;
        internal static Synonym _Synonym = null;
        internal static Wildcard _Wildcard = null;
        private MatchOption _Options;
        private MatchParameter _Parameters;

        #endregion

        #region Initialization

        public static void Init()
        {
            Init(null);
        }

        public static void Init(string fileName)
        {
            lock (_LockObj)
            {
                if (_Inited)
                {
                    return;
                }

                InitInfinitiveVerbTable();

                LoadDictionary();

                _Inited = true;
            }
        }

        private static void LoadDictionary()
        {
            _WordDictionary = new WordDictionary();
            string dir = PanGuSettings.CurrentDictionaryPath;
            _WordDictionary.Load(string.Format(@"{0}\{1}", dir, Constants.DictionaryFileName));

            _ChsName = new ChsName();
            _ChsName.LoadChsName(PanGuSettings.CurrentDictionaryPath);


            _WordDictionary.ChineseName = _ChsName;

            _StopWord = new StopWord();
            _StopWord.LoadStopwordsDict(string.Format(@"{0}\{1}", dir, Constants.StopwordFileName));

            _Synonym = new Synonym();

            if (PanGuSettings.CurrentMatchOption.SynonymOutput)
            {
                _Synonym.Load(dir);
            }

            _Wildcard = new Wildcard(PanGuSettings.CurrentMatchOption,
                PanGuSettings.CurrentMatchParameter);

            if (PanGuSettings.CurrentMatchOption.WildcardOutput)
            {
                _Wildcard.Load(dir);
            }

            _DictLoader = new DictionaryLoader(PanGuSettings.CurrentDictionaryPath);
        }

        private static void InitInfinitiveVerbTable()
        {
            if (_InfinitiveVerbTable != null)
            {
                return;
            }

            _InfinitiveVerbTable = new Dictionary<string, string>();

            using (StringReader sr = new StringReader(AnalyzerResource.INFINITIVE))
            {

                string line = sr.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    string[] strs = Regex.Split(line, "\t+");

                    if (strs.Length != 3)
                    {
                        continue;
                    }

                    for (int i = 1; i < 3; i++)
                    {
                        string key = strs[i].ToLower().Trim();

                        if (!_InfinitiveVerbTable.ContainsKey(key))
                        {
                            _InfinitiveVerbTable.Add(key, strs[0].Trim().ToLower());
                        }
                    }

                    line = sr.ReadLine();
                }
            }

        }

        #endregion

        #region Public methods

        public static ICollection<string> Resolve(string text, MatchOption options = null, MatchParameter parameters = null)
        {
            Segment segment = new Segment();
            ICollection<WordInfo> wordInfos = segment.DoSegment(text, options, parameters);
            ICollection<string> words = new HashSet<string>();
            foreach (WordInfo wordInfo in wordInfos)
            {
                words.Add(wordInfo.Word);
            }

            return words;
        }

        public static ICollection<WordInfo> ResolveRaw(string text, MatchOption options = null, MatchParameter parameters = null)
        {
            Segment segment = new Segment();
            ICollection<WordInfo> wordInfos = segment.DoSegment(text, options, parameters);

            return wordInfos;
        }

        public ICollection<WordInfo> DoSegment(string text, MatchOption options = null, MatchParameter parameters = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new SuperLinkedList<WordInfo>();
            }

            try
            {
                DictionaryLoader.Lock.Enter(Mode.Share);
                _Options = options;
                _Parameters = parameters;

                Init();

                if (_Options == null)
                {
                    _Options = PanGuSettings.CurrentMatchOption;
                }

                if (_Parameters == null)
                {
                    _Parameters = PanGuSettings.CurrentMatchParameter;
                }

                SuperLinkedList<WordInfo> result = PreSegment(text);

                if (_Options.FilterStopWords)
                {
                    FilterStopWord(result);
                }

                ProcessAfterSegment(text, result);

                return result;
            }
            finally
            {
                DictionaryLoader.Lock.Leave();
            }
        }

        #endregion

        #region Private methods

        private SuperLinkedList<WordInfo> GetInitSegment(string text)
        {
            SuperLinkedList<WordInfo> result = new SuperLinkedList<WordInfo>();

            Lexical lexical = new Lexical(text);

            DFAResult dfaResult;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                dfaResult = lexical.Input(c, i);

                switch (dfaResult)
                {
                    case DFAResult.Continue:
                        continue;
                    case DFAResult.Quit:
                        result.AddLast(lexical.OutputToken);
                        break;
                    case DFAResult.ElseQuit:
                        result.AddLast(lexical.OutputToken);
                        if (lexical.OldState != 255)
                        {
                            i--;
                        }

                        break;
                }

            }

            dfaResult = lexical.Input(0, text.Length);

            switch (dfaResult)
            {
                case DFAResult.Continue:
                    break;
                case DFAResult.Quit:
                    result.AddLast(lexical.OutputToken);
                    break;
                case DFAResult.ElseQuit:
                    result.AddLast(lexical.OutputToken);
                    break;
            }

            return result;
        }

        private string ConvertChineseCapitalToAsiic(string text)
        {
            StringBuilder sb = null;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                bool needReplace = false;

                //[０-９\d]+)|([ａ-ｚＡ-Ｚa-zA-Z_]+)";
                if (c >= '０' && text[i] <= '９')
                {
                    c -= '０';
                    c += '0';
                    needReplace = true;
                }
                else if (c >= 'ａ' && text[i] <= 'ｚ')
                {
                    c -= 'ａ';
                    c += 'a';
                    needReplace = true;
                }
                else if (c >= 'Ａ' && text[i] <= 'Ｚ')
                {
                    c -= 'Ａ';
                    c += 'A';
                    needReplace = true;
                }

                if (needReplace)
                {
                    if (sb == null)
                    {
                        sb = new StringBuilder();
                        sb.Append(text.Substring(0, i));
                    }
                }

                if (sb != null)
                {
                    sb.Append(c);
                }

            }

            if (sb == null)
            {
                return text;
            }
            else
            {
                return sb.ToString();
            }
        }

        private string GetStem(string word)
        {
            string stem;
            if (_InfinitiveVerbTable.TryGetValue(word, out stem))
            {
                return stem;
            }

            Stemmer s = new Stemmer();

            foreach (char ch in word)
            {
                if (char.IsLetter((char)ch))
                {
                    s.add(ch);
                }
            }

            s.stem();

            return s.ToString();

        }

        private SuperLinkedList<WordInfo> PreSegment(String text)
        {
            SuperLinkedList<WordInfo> result = GetInitSegment(text);

            SuperLinkedListNode<WordInfo> cur = result.First;

            while (cur != null)
            {
                if (_Options.IgnoreSpace)
                {
                    if (cur.Value.WordType == WordType.Space)
                    {
                        SuperLinkedListNode<WordInfo> lst = cur;
                        cur = cur.Next;
                        result.Remove(lst);
                        continue;
                    }
                }

                switch (cur.Value.WordType)
                {
                    case WordType.SimplifiedChinese:

                        string inputText = cur.Value.Word;

                        WordType originalWordType = WordType.SimplifiedChinese;

                        if (_Options.TraditionalChineseEnabled)
                        {
                            string simplified = Strings.StrConv(cur.Value.Word, VbStrConv.SimplifiedChinese, 0);

                            if (simplified != cur.Value.Word)
                            {
                                originalWordType = WordType.TraditionalChinese;
                                inputText = simplified;
                            }
                        }

                        AppendList<PositionLength> pls = _WordDictionary.GetAllMatchs(inputText, _Options.ChineseNameIdentify);
                        ChsFullTextMatch chsMatch = new ChsFullTextMatch(_WordDictionary);
                        chsMatch.Options = _Options;
                        chsMatch.Parameters = _Parameters;
                        SuperLinkedList<WordInfo> chsMatchWords = chsMatch.Match(pls.Items, cur.Value.Word, pls.Count);

                        SuperLinkedListNode<WordInfo> curChsMatch = chsMatchWords.First;
                        while (curChsMatch != null)
                        {
                            WordInfo wi = curChsMatch.Value;

                            wi.Position += cur.Value.Position;
                            wi.OriginalWordType = originalWordType;
                            wi.WordType = originalWordType;

                            if (_Options.OutputSimplifiedTraditional)
                            {
                                if (_Options.TraditionalChineseEnabled)
                                {
                                    string newWord;
                                    WordType wt;

                                    if (originalWordType == WordType.SimplifiedChinese)
                                    {
                                        newWord = Strings.StrConv(wi.Word,
                                            VbStrConv.TraditionalChinese, 0);
                                        wt = WordType.TraditionalChinese;
                                    }
                                    else
                                    {
                                        newWord = Strings.StrConv(wi.Word,
                                            VbStrConv.SimplifiedChinese, 0);
                                        wt = WordType.SimplifiedChinese;
                                    }

                                    if (newWord != wi.Word)
                                    {
                                        WordInfo newWordInfo = new WordInfo(wi);
                                        newWordInfo.Word = newWord;
                                        newWordInfo.OriginalWordType = originalWordType;
                                        newWordInfo.WordType = wt;
                                        newWordInfo.Rank = _Parameters.SimplifiedTraditionalRank;
                                        newWordInfo.Position = wi.Position;
                                        chsMatchWords.AddBefore(curChsMatch, newWordInfo);
                                    }
                                }
                            }

                            curChsMatch = curChsMatch.Next;
                        }

                        SuperLinkedListNode<WordInfo> lst = result.AddAfter(cur, chsMatchWords);
                        SuperLinkedListNode<WordInfo> removeItem = cur;
                        cur = lst.Next;
                        result.Remove(removeItem);
                        break;
                    case WordType.English:
                        cur.Value.Rank = _Parameters.EnglishRank;
                        List<string> output;
                        cur.Value.Word = ConvertChineseCapitalToAsiic(cur.Value.Word);

                        if (_Options.IgnoreCapital)
                        {
                            cur.Value.Word = cur.Value.Word.ToLower();
                        }

                        if (_Options.EnglishSegment)
                        {
                            string lower = cur.Value.Word.ToLower();

                            if (lower != cur.Value.Word)
                            {
                                result.AddBefore(cur, new WordInfo(lower, cur.Value.Position, POS.POS_A_NX, 1,
                                    _Parameters.EnglishLowerRank, WordType.English, WordType.English));
                            }

                            string stem = GetStem(lower);

                            if (!string.IsNullOrEmpty(stem))
                            {
                                if (lower != stem)
                                {
                                    result.AddBefore(cur, new WordInfo(stem, cur.Value.Position, POS.POS_A_NX, 1,
                                        _Parameters.EnglishStemRank, WordType.English, WordType.English));
                                }
                            }
                        }

                        if (_Options.EnglishMultiDimensionality)
                        {
                            bool needSplit = false;

                            foreach (char c in cur.Value.Word)
                            {
                                if ((c >= '0' && c <= '9') || (c == '_'))
                                {
                                    needSplit = true;
                                    break;
                                }
                            }

                            if (needSplit)
                            {
                                if (Regex.GetMatchStrings(cur.Value.Word, PATTERNS, true, out output))
                                {
                                    int outputCount = 0;

                                    foreach (string str in output)
                                    {
                                        if (!string.IsNullOrEmpty(str))
                                        {
                                            outputCount++;

                                            if (outputCount > 1)
                                            {
                                                break;
                                            }
                                        }
                                    }


                                    if (outputCount > 1)
                                    {
                                        int position = cur.Value.Position;

                                        foreach (string splitWord in output)
                                        {
                                            if (string.IsNullOrEmpty(splitWord))
                                            {
                                                continue;
                                            }

                                            WordInfo wi;

                                            if (splitWord[0] >= '0' && splitWord[0] <= '9')
                                            {
                                                wi = new WordInfo(splitWord, POS.POS_A_M, 1);
                                                wi.Position = position;
                                                wi.Rank = _Parameters.NumericRank;
                                                wi.OriginalWordType = WordType.English;
                                                wi.WordType = WordType.Numeric;
                                            }
                                            else
                                            {
                                                wi = new WordInfo(splitWord, POS.POS_A_NX, 1);
                                                wi.Position = position;
                                                wi.Rank = _Parameters.EnglishRank;
                                                wi.OriginalWordType = WordType.English;
                                                wi.WordType = WordType.English;
                                            }

                                            result.AddBefore(cur, wi);
                                            position += splitWord.Length;
                                        }
                                    }
                                }
                            }
                        }

                        if (!MergeEnglishSpecialWord(text, result, ref cur))
                        {
                            cur = cur.Next;
                        }

                        break;
                    case WordType.Numeric:
                        cur.Value.Word = ConvertChineseCapitalToAsiic(cur.Value.Word);
                        cur.Value.Rank = _Parameters.NumericRank;

                        if (!MergeEnglishSpecialWord(text, result, ref cur))
                        {
                            cur = cur.Next;
                        }

                        //cur = cur.Next;
                        break;
                    case WordType.Symbol:
                        cur.Value.Rank = _Parameters.SymbolRank;
                        cur = cur.Next;
                        break;
                    default:
                        cur = cur.Next;
                        break;
                }

            }


            return result;

        }

        private void FilterStopWord(SuperLinkedList<WordInfo> wordInfoList)
        {
            if (wordInfoList == null)
            {
                return;
            }

            SuperLinkedListNode<WordInfo> cur = wordInfoList.First;

            while (cur != null)
            {
                if (_StopWord.IsStopWord(cur.Value.Word,
                    _Options.FilterEnglish, _Parameters.FilterEnglishLength,
                    _Options.FilterNumeric, _Parameters.FilterNumericLength))
                {
                    SuperLinkedListNode<WordInfo> removeItem = cur;
                    cur = cur.Next;
                    wordInfoList.Remove(removeItem);
                }
                else
                {
                    cur = cur.Next;
                }
            }
        }

        private void ProcessAfterSegment(string orginalText, SuperLinkedList<WordInfo> result)
        {
            //匹配同义词
            if (_Options.SynonymOutput)
            {
                SuperLinkedListNode<WordInfo> node = result.First;

                while (node != null)
                {
                    List<string> synonyms = _Synonym.GetSynonyms(node.Value.Word);

                    if (synonyms != null)
                    {
                        foreach (string word in synonyms)
                        {
                            node = result.AddAfter(node, new WordInfo(word, node.Value.Position,
                                node.Value.Pos, node.Value.Frequency, _Parameters.SymbolRank,
                                WordType.Synonym, node.Value.WordType));
                        }
                    }

                    node = node.Next;
                }
            }

            //通配符匹配
            if (_Options.WildcardOutput)
            {
                SuperLinkedListNode<WordInfo> node = result.First;

                while (node != null)
                {
                    List<Wildcard.WildcardInfo> wildcards =
                        _Wildcard.GetWildcards(node.Value.Word);

                    if (wildcards.Count > 0)
                    {
                        for (int i = 0; i < wildcards.Count; i++)
                        {
                            Wildcard.WildcardInfo wildcardInfo = wildcards[i];

                            int count = wildcardInfo.Segments.Count;
                            if (!_Options.WildcardSegment)
                            {
                                count = 1;
                            }

                            for (int j = 0; j < count; j++)
                            {
                                WordInfo wi = wildcardInfo.Segments[j];

                                if (wi.Word == node.Value.Word)
                                {
                                    continue;
                                }

                                wi.Rank = _Parameters.WildcardRank;
                                wi.Position += node.Value.Position;
                                result.AddBefore(node, wi);
                            }
                        }

                    }

                    node = node.Next;

                    if (node != null)
                    {
                        //过滤英文分词时多元分词重复输出的问题
                        if (node.Previous.Value.Word.ToLower() == node.Value.Word.ToLower())
                        {
                            node = node.Next;
                        }
                    }

                }
            }

            //用户自定义规则
            if (_Options.CustomRule)
            {
                ICustomRule rule = CustomRule.GetCustomRule(_Parameters.CustomRuleAssemblyFileName,
                    _Parameters.CustomRuleFullClassName);

                if (rule != null)
                {
                    rule.Text = orginalText;
                    rule.AfterSegment(result);
                }

            }
        }

        #endregion

        #region Merge functions

        /// <summary>
        /// 合并英文专用词。
        /// 如果字典中有英文专用词如U.S.A, C++.C#等
        /// 需要对初步分词后的英文和字母进行合并
        /// </summary>
        /// <param name="words"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        //private String MergeEnglishSpecialWord(CExtractWords extractWords, ArrayList words, int start, ref int end)
        //{
        //    StringBuilder str = new StringBuilder();

        //    int i;

        //    for (i = start; i < words.Count; i++)
        //    {
        //        string word = (string)words[i];

        //        //word 为空或者为空格回车换行等分割符号，中断扫描
        //        if (word.Trim() == "")
        //        {
        //            break;
        //        }

        //        //如果遇到中文，中断扫描
        //        if (word[0] >= 0x4e00 && word[0] <= 0x9fa5)
        //        {
        //            break;
        //        }

        //        str.Append(word);
        //    }

        //    String mergeString = str.ToString();
        //    List<T_WordInfo> exWords = extractWords.ExtractFullText(mergeString);

        //    if (exWords.Count == 1)
        //    {
        //        T_WordInfo info = (T_WordInfo)exWords[0];
        //        if (info.Word.Length == mergeString.Length)
        //        {
        //            end = i;
        //            return mergeString;
        //        }
        //    }

        //    return null;

        //}

        private bool MergeEnglishSpecialWord(string orginalText, SuperLinkedList<WordInfo> wordInfoList, ref SuperLinkedListNode<WordInfo> current)
        {
            SuperLinkedListNode<WordInfo> cur = current;

            cur = cur.Next;

            int last = -1;

            while (cur != null)
            {
                if (cur.Value.WordType == WordType.Symbol || cur.Value.WordType == WordType.English)
                {
                    last = cur.Value.Position + cur.Value.Word.Length;
                    cur = cur.Next;
                }
                else
                {
                    break;
                }
            }


            if (last >= 0)
            {
                int first = current.Value.Position;

                string newWord = orginalText.Substring(first, last - first);

                WordAttribute wa = _WordDictionary.GetWordAttr(newWord);

                if (wa == null)
                {
                    return false;
                }

                while (current != cur)
                {
                    SuperLinkedListNode<WordInfo> removeItem = current;
                    current = current.Next;
                    wordInfoList.Remove(removeItem);
                }

                WordInfo newWordInfo = new WordInfo(new PositionLength(first, last - first,
                    wa), orginalText, _Parameters);

                newWordInfo.WordType = WordType.English;
                newWordInfo.Rank = _Parameters.EnglishRank;

                if (current == null)
                {
                    wordInfoList.AddLast(newWordInfo);
                }
                else
                {
                    wordInfoList.AddBefore(current, newWordInfo);
                }

                return true;
            }


            return false;

        }

        #endregion
    }
}
