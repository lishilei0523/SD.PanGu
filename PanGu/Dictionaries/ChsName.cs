/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System.Collections.Generic;
using System.Text;
using PanGu.Framework;

namespace PanGu.Dictionaries
{
    /// <summary>
    /// 匹配中文人名
    /// </summary>
    class ChsName
    {
        /// <summary>
        /// 没有明显歧异的姓氏
        /// </summary>
        readonly static string[] FAMILY_NAMES = {
            //有明显歧异的姓氏
            "王","张","黄","周","徐",
            "胡","高","林","马","于",
            "程","傅","曾","叶","余",
            "夏","钟","田","任","方",
            "石","熊","白","毛","江",
            "史","候","龙","万","段",
            "雷","钱","汤","易","常",
            "武","赖","文", "查",

            //没有明显歧异的姓氏
            "赵", "肖", "孙", "李",
            "吴", "郑", "冯", "陈", 
            "褚", "卫", "蒋", "沈", 
            "韩", "杨", "朱", "秦", 
            "尤", "许", "何", "吕", 
            "施", "桓", "孔", "曹",
            "严", "华", "金", "魏",
            "陶", "姜", "戚", "谢",
            "邹", "喻", "柏", "窦",
            "苏", "潘", "葛", "奚",
            "范", "彭", "鲁", "韦",
            "昌", "俞", "袁", "酆", 
            "鲍", "唐", "费", "廉",
            "岑", "薛", "贺", "倪",
            "滕", "殷", "罗", "毕",
            "郝", "邬", "卞", "康",
            "卜", "顾", "孟", "穆",
            "萧", "尹", "姚", "邵",
            "湛", "汪", "祁", "禹",
            "狄", "贝", "臧", "伏",
            "戴", "宋", "茅", "庞",
            "纪", "舒", "屈", "祝",
            "董", "梁", "杜", "阮",
            "闵", "贾", "娄", "颜",
            "郭", "邱", "骆", "蔡",
            "樊", "凌", "霍", "虞",
            "柯", "昝", "卢", "柯",
            "缪", "宗", "丁", "贲",
            "邓", "郁", "杭", "洪",
            "崔", "龚", "嵇", "邢",
            "滑", "裴", "陆", "荣",
            "荀", "惠", "甄", "芮",
            "羿", "储", "靳", "汲", 
            "邴", "糜", "隗", "侯",
            "宓", "蓬", "郗", "仲",
            "栾", "钭", "历", "戎",
            "刘", "詹", "幸", "韶",
            "郜", "黎", "蓟", "溥",
            "蒲", "邰", "鄂", "咸",
            "卓", "蔺", "屠", "乔",
            "郁", "胥", "苍", "莘",
            "翟", "谭", "贡", "劳",
            "冉", "郦", "雍", "璩",
            "桑", "桂", "濮", "扈",
            "冀", "浦", "庄", "晏",
            "瞿", "阎", "慕", "茹",
            "习", "宦", "艾", "容",
            "慎", "戈", "廖", "庾",
            "衡", "耿", "弘", "匡",
            "阙", "殳", "沃", "蔚",
            "夔", "隆", "巩", "聂",
            "晁", "敖", "融", "訾",
            "辛", "阚", "毋", "乜",
            "鞠", "丰", "蒯", "荆",
            "竺", "盍", "单", "欧",

            //复姓必须在单姓后面
            "司马", "上官", "欧阳",
            "夏侯", "诸葛", "闻人",
            "东方", "赫连", "皇甫",
            "尉迟", "公羊", "澹台",
            "公冶", "宗政", "濮阳",
            "淳于", "单于", "太叔",
            "申屠", "公孙", "仲孙",
            "轩辕", "令狐", "徐离",
            "宇文", "长孙", "慕容",
            "司徒", "司空", "万俟"};

        Dictionary<char, List<char>> _FamilyNameDict = new Dictionary<char, List<char>>();
        Dictionary<char, char> _SingleNameDict = new Dictionary<char, char>();
        Dictionary<char, char> _DoubleName1Dict = new Dictionary<char, char>();
        Dictionary<char, char> _DoubleName2Dict = new Dictionary<char, char>();

        public ChsName()
        {
            foreach (string familyName in FAMILY_NAMES)
            {
                if (familyName.Length == 1)
                {
                    if (!this._FamilyNameDict.ContainsKey(familyName[0]))
                    {
                        this._FamilyNameDict.Add(familyName[0], null);
                    }
                }
                else
                {
                    List<char> sec = new List<char>();
                    if (this._FamilyNameDict.ContainsKey(familyName[0]))
                    {
                        if (this._FamilyNameDict[familyName[0]] == null)
                        {
                            sec.Add((char)0);
                            this._FamilyNameDict[familyName[0]] = sec;
                        }

                        this._FamilyNameDict[familyName[0]].Add(familyName[1]);
                    }
                    else
                    {
                        sec.Add(familyName[1]);
                        this._FamilyNameDict[familyName[0]] = sec;
                    }
                }
            }
        }

        private void LoadNameDict(string filePath, ref Dictionary<char, char> dict)
        {
            dict = new Dictionary<char, char>();

            string content = File.ReadFileToString(filePath, Encoding.UTF8);

            foreach (string name in Regex.Split(content, @"\r\n"))
            {
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                char n = name[0];

                if (!dict.ContainsKey(n))
                {
                    dict.Add(n, n);
                }
            }
        }

        public void LoadChsName(string dictPath)
        {
            dictPath = Path.AppendDivision(dictPath, '\\');

            this.LoadNameDict(dictPath + Constants.ChsSingleNameFileName, ref this._SingleNameDict);
            this.LoadNameDict(dictPath + Constants.ChsDoubleName1FileName, ref this._DoubleName1Dict);
            this.LoadNameDict(dictPath + Constants.ChsDoubleName2FileName, ref this._DoubleName2Dict);
        }

        public List<string> Match(string text, int start)
        {
            List<string> result = null;

            int cur = start;

            if (cur > text.Length - 2)
            {
                return null;
            }

            char f1 = text[cur];

            cur++;
            char f2 = text[cur];

            List<char> f2List;
            if (!this._FamilyNameDict.TryGetValue(f1, out f2List))
            {
                return null;
            }

            if (f2List != null)
            {
                bool find = false;
                bool hasZero = false;
                foreach (char c in f2List)
                {
                    if (c == f2)
                    {
                        //复姓
                        cur++;
                        find = true;
                        break;
                    }
                    else if (c == 0)
                    {
                        //单姓，首字和某个复姓的首字相同
                        hasZero = true;
                    }
                }

                if (!find && !hasZero)
                {
                    return null;
                }
            }

            if (cur >= text.Length)
            {
                return null;
            }

            char name1 = text[cur];

            if (this._SingleNameDict.ContainsKey(name1))
            {
                result = new List<string>();
                result.Add(text.Substring(start, cur - start + 1));
            }

            if (this._DoubleName1Dict.ContainsKey(name1))
            {
                cur++;

                if (cur >= text.Length)
                {
                    return result;
                }

                char name2 = text[cur];
                if (this._DoubleName2Dict.ContainsKey(name2))
                {
                    if (result == null)
                    {
                        result = new List<string>();
                    }

                    result.Add(text.Substring(start, cur - start + 1));
                }
            }

            return result;
        }
    }
}
