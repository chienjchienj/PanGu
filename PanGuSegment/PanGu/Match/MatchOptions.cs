using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;

namespace PanGu.Match
{
    [Serializable]
    public class MatchOptions
    {
        /// <summary>
        /// 中文人名識別
        /// </summary>
        public bool ChineseNameIdentify = false;

        /// <summary>
        /// 詞頻優先
        /// </summary>
        public bool FrequencyFirst = false;

        /// <summary>
        /// 多元分詞
        /// </summary>
        public bool MultiDimensionality = true;

        /// <summary>
        /// 英文多元分詞，這個開關，會將英文中的字母和數字分開。
        /// </summary>
        public bool EnglishMultiDimensionality = false;

        /// <summary>
        /// 過濾停用詞
        /// </summary>
        public bool FilterStopWords = true;

        /// <summary>
        /// 忽略空格、回車、Tab
        /// </summary>
        public bool IgnoreSpace = true;

        /// <summary>
        /// 強制一元分詞
        /// </summary>
        public bool ForceSingleWord = false;

        /// <summary>
        /// 繁體中文開關
        /// </summary>
        public bool TraditionalChineseEnabled = false;

        /// <summary>
        /// 同時輸出簡體和繁體
        /// </summary>
        public bool OutputSimplifiedTraditional = false;

        /// <summary>
        /// 未登錄詞識別
        /// </summary>
        public bool UnknownWordIdentify = true;

        /// <summary>
        /// 過濾英文，這個選項只有在過濾停用詞選項生效時才有效
        /// </summary>
        public bool FilterEnglish = false;

        /// <summary>
        /// 過濾數字，這個選項只有在過濾停用詞選項生效時才有效
        /// </summary>
        public bool FilterNumeric = false;


        /// <summary>
        /// 忽略英文大小寫
        /// </summary>
        public bool IgnoreCapital = false;

        /// <summary>
        /// 英文分詞
        /// </summary>
        public bool EnglishSegment = false;

        /// <summary>
        /// 同義詞輸出
        /// </summary>
        /// <remarks>
        /// 同義詞輸出功能一般用於對搜索字符串的分詞，不建議在索引時使用
        /// </remarks>
        public bool SynonymOutput = false;

        /// <summary>
        /// 通配符匹配輸出
        /// </summary>
        /// <remarks>
        /// 同義詞輸出功能一般用於對搜索字符串的分詞，不建議在索引時使用
        /// </remarks>
        public bool WildcardOutput = false;

        /// <summary>
        /// 對通配符匹配的結果分詞
        /// </summary>
        public bool WildcardSegment = false;

        /// <summary>
        /// 是否進行用戶自定義規則匹配
        /// </summary>
        public bool CustomRule = false;

        public MatchOptions Clone()
        {
            MatchOptions result = new MatchOptions();

            foreach (FieldInfo fi in this.GetType().GetFields())
            {
                object value = fi.GetValue(this);
                fi.SetValue(result, value);
            }

            return result;
        }
    }
}
