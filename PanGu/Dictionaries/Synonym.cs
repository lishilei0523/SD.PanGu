using PanGu.Settings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PanGu.Dictionaries
{
    /// <summary>
    /// 同义词
    /// </summary>
    class Synonym
    {
        object _LockObj = new object();

        bool _Init = false;

        List<string[]> _GroupList = null;//同义词组，文件中一行为一组，一组同义词以 “,” 分割

        Dictionary<string, List<int>> _WordToGroupId = null; //单词到同义词组的对应关系，一个单词可能对于多个同义词组

        private void LoadSynonym(string fileName)
        {
            this._GroupList = new List<string[]>();
            this._WordToGroupId = new Dictionary<string, List<int>>();

            if (!File.Exists(fileName))
            {
                return;
            }

            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim().ToLower();

                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    string[] words = line.Split(new char[] { ',' });
                    this._GroupList.Add(words);
                    int groupId = this._GroupList.Count - 1;

                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] = words[i].Trim();

                        List<int> idList;
                        if (this._WordToGroupId.TryGetValue(words[i], out idList))
                        {
                            if (idList[idList.Count - 1] == groupId)
                            {
                                continue;
                            }

                            idList.Add(groupId);
                        }
                        else
                        {
                            idList = new List<int>(1);
                            idList.Add(groupId);
                            this._WordToGroupId.Add(words[i], idList);
                        }
                    }
                }
            }

            this._Init = true;
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
            this.LoadSynonym(dictPath + Constants.SynonymFileName);
        }

        private void Load()
        {
            lock (this._LockObj)
            {
                if (!this._Init)
                {
                    string dir = PanGuSettings.CurrentDictionaryPath;
                    this.Load(dir);
                }
            }
        }

        public List<string> GetSynonyms(string word)
        {
            lock (this._LockObj)
            {
                if (!this._Init)
                {
                    this.Load();
                }
            }

            word = word.Trim().ToLower();

            List<int> idList;
            if (this._WordToGroupId.TryGetValue(word, out idList))
            {
                List<string> result = new List<string>();

                foreach (int groupId in idList)
                {
                    foreach (string w in this._GroupList[groupId])
                    {
                        if (w == word)
                        {
                            continue;
                        }

                        if (result.Contains(w))
                        {
                            continue;
                        }

                        result.Add(w);
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
