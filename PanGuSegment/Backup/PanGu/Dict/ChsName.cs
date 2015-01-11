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


using System;
using System.Collections.Generic;
using System.Text;

namespace PanGu.Dict
{
    /// <summary>
    /// 匹配中文人名
    /// </summary>
    class ChsName
    {
        /// <summary>
        /// 沒有明顯歧異的姓氏
        /// </summary>
        readonly static string[] FAMILY_NAMES = {
            //有明顯歧異的姓氏
            "王","張","黃","周","徐",
            "胡","高","林","馬","於",
            "程","傅","曾","葉","余",
            "夏","鍾","田","任","方",
            "石","熊","白","毛","江",
            "史","候","龍","萬","段",
            "雷","錢","湯","易","常",
            "武","賴","文", "查",

            //沒有明顯歧異的姓氏
            "趙", "肖", "孫", "李",
            "吳", "鄭", "馮", "陳", 
            "褚", "衛", "蔣", "沈", 
            "韓", "楊", "朱", "秦", 
            "尤", "許", "何", "呂", 
            "施", "桓", "孔", "曹",
            "嚴", "華", "金", "魏",
            "陶", "姜", "戚", "謝",
            "鄒", "喻", "柏", "竇",
            "蘇", "潘", "葛", "奚",
            "范", "彭", "魯", "韋",
            "昌", "俞", "袁", "酆", 
            "鮑", "唐", "費", "廉",
            "岑", "薛", "賀", "倪",
            "滕", "殷", "羅", "畢",
            "郝", "鄔", "卞", "康",
            "卜", "顧", "孟", "穆",
            "蕭", "尹", "姚", "邵",
            "湛", "汪", "祁", "禹",
            "狄", "貝", "臧", "伏",
            "戴", "宋", "茅", "龐",
            "紀", "舒", "屈", "祝",
            "董", "梁", "杜", "阮",
            "閔", "賈", "婁", "顏",
            "郭", "邱", "駱", "蔡",
            "樊", "凌", "霍", "虞",
            "柯", "昝", "盧", "柯",
            "繆", "宗", "丁", "賁",
            "鄧", "郁", "杭", "洪",
            "崔", "龔", "嵇", "邢",
            "滑", "裴", "陸", "榮",
            "荀", "惠", "甄", "芮",
            "羿", "儲", "靳", "汲", 
            "邴", "糜", "隗", "侯",
            "宓", "蓬", "郗", "仲",
            "欒", "鈄", "歷", "戎",
            "劉", "詹", "幸", "韶",
            "郜", "黎", "薊", "溥",
            "蒲", "邰", "鄂", "鹹",
            "卓", "藺", "屠", "喬",
            "郁", "胥", "蒼", "莘",
            "翟", "譚", "貢", "勞",
            "冉", "酈", "雍", "璩",
            "桑", "桂", "濮", "扈",
            "冀", "浦", "莊", "晏",
            "瞿", "閻", "慕", "茹",
            "習", "宦", "艾", "容",
            "慎", "戈", "廖", "庾",
            "衡", "耿", "弘", "匡",
            "闕", "殳", "沃", "蔚",
            "夔", "隆", "鞏", "聶",
            "晁", "敖", "融", "訾",
            "辛", "闞", "毋", "乜",
            "鞠", "豐", "蒯", "荊",
            "竺", "盍", "單", "歐",

            //複姓必須在單姓後面
            "司馬", "上官", "歐陽",
            "夏侯", "諸葛", "聞人",
            "東方", "赫連", "皇甫",
            "尉遲", "公羊", "澹台",
            "公冶", "宗政", "濮陽",
            "淳於", "單于", "太叔",
            "申屠", "公孫", "仲孫",
            "軒轅", "令狐", "徐離",
            "宇文", "長孫", "慕容",
            "司徒", "司空", "萬俟"};

        Dictionary<char, List<char>> _FamilyNameDict = new Dictionary<char, List<char>>();
        Dictionary<char, char> _SingleNameDict = new Dictionary<char, char>();
        Dictionary<char, char> _DoubleName1Dict = new Dictionary<char, char>();
        Dictionary<char, char> _DoubleName2Dict = new Dictionary<char, char>();

        public const string ChsSingleNameFileName = "ChsSingleName.txt";
        public const string ChsDoubleName1FileName = "ChsDoubleName1.txt";
        public const string ChsDoubleName2FileName = "ChsDoubleName2.txt";



        public ChsName()
        {
            foreach (string familyName in FAMILY_NAMES)
            {
                if (familyName.Length == 1)
                {
                    if (!_FamilyNameDict.ContainsKey(familyName[0]))
                    {
                        _FamilyNameDict.Add(familyName[0], null);
                    }
                }
                else
                {
                    List<char> sec = new List<char>();
                    if (_FamilyNameDict.ContainsKey(familyName[0]))
                    {
                        if (_FamilyNameDict[familyName[0]] == null)
                        {
                            sec.Add((char)0);
                            _FamilyNameDict[familyName[0]] = sec;
                        }

                        _FamilyNameDict[familyName[0]].Add(familyName[1]);
                    }
                    else
                    {
                        sec.Add(familyName[1]);
                        _FamilyNameDict[familyName[0]] = sec;
                    }
                }
            }
        }

        private void LoadNameDict(string filePath, ref Dictionary<char, char> dict)
        {
            dict = new Dictionary<char, char>();

            string content = Framework.File.ReadFileToString(filePath, Encoding.UTF8);

            foreach (string name in Framework.Regex.Split(content, @"\r\n"))
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
            dictPath = Framework.Path.AppendDivision(dictPath, '\\');

            LoadNameDict(dictPath + ChsSingleNameFileName, ref _SingleNameDict);
            LoadNameDict(dictPath + ChsDoubleName1FileName, ref _DoubleName1Dict);
            LoadNameDict(dictPath + ChsDoubleName2FileName, ref _DoubleName2Dict);
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
            if (!_FamilyNameDict.TryGetValue(f1, out f2List))
            {
                return null;
            }

            if (f2List != null)
            {
                bool find = false;
                bool hasZero = false;
                foreach(char c in f2List)
                {
                    if (c == f2)
                    {
                        //複姓
                        cur++;
                        find = true;
                        break;
                    }
                    else if (c == 0)
                    {
                        //單姓，首字和某個複姓的首字相同
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

            if (_SingleNameDict.ContainsKey(name1))
            {
                result = new List<string>();
                result.Add(text.Substring(start, cur - start + 1));
            }

            if (_DoubleName1Dict.ContainsKey(name1))
            {
                cur++;

                if (cur >= text.Length)
                {
                    return result;
                }

                char name2 = text[cur];
                if (_DoubleName2Dict.ContainsKey(name2))
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
