using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace PanGu.Match
{
    [Serializable]
    public class MatchParameter
    {
 
        private int _Redundancy;

        /// <summary>
        /// 多元分詞冗余度
        /// </summary>
        public int Redundancy
        {
            get
            {
                return _Redundancy;
            }

            set
            {
                if (value < 0)
                {
                    _Redundancy = 0;
                }
                else if (value >= 3)
                {
                    _Redundancy = 2;
                }
                else
                {
                    _Redundancy = value;
                }
            }
        }

        /// <summary>
        /// 未登錄詞權值
        /// </summary>
        public int UnknowRank = 1;

        /// <summary>
        /// 最匹配詞權值
        /// </summary>
        public int BestRank = 5;

        /// <summary>
        /// 次匹配詞權值
        /// </summary>
        public int SecRank = 3;

        /// <summary>
        /// 再次匹配詞權值
        /// </summary>
        public int ThirdRank = 2;

        /// <summary>
        /// 強行輸出的單字的權值
        /// </summary>
        public int SingleRank = 1;

        /// <summary>
        /// 數字的權值
        /// </summary>
        public int NumericRank = 1;

        /// <summary>
        /// 英文詞彙權值
        /// </summary>
        public int EnglishRank = 5;

        /// <summary>
        /// 英文詞彙小寫的權值
        /// </summary>
        public int EnglishLowerRank = 3;

        /// <summary>
        /// 英文詞彙詞根的權值
        /// </summary>
        public int EnglishStemRank = 2;


        /// <summary>
        /// 符號的權值
        /// </summary>
        public int SymbolRank = 1;

        /// <summary>
        /// 強制同時輸出簡繁漢字時，非原來文本的漢字輸出權值。
        /// 比如原來文本是簡體，這裡就是輸出的繁體字的權值，反之亦然。
        /// </summary>
        public int SimplifiedTraditionalRank = 1;

        /// <summary>
        /// 同義詞權值
        /// </summary>
        public int SynonymRank = 1;

        /// <summary>
        /// 通配符匹配結果的權值
        /// </summary>
        public int WildcardRank = 1;

        /// <summary>
        /// 過濾英文選項生效時，過濾大於這個長度的英文。
        /// </summary>
        public int FilterEnglishLength = 0;

        /// <summary>
        /// 過濾數字選項生效時，過濾大於這個長度的數字。
        /// </summary>
        public int FilterNumericLength = 0;

        /// <summary>
        /// 用戶自定義規則的配件文件名
        /// </summary>
        public string CustomRuleAssemblyFileName = "";

        /// <summary>
        /// 用戶自定義規則的類的完整名，即帶名字空間的名稱
        /// </summary>
        public string CustomRuleFullClassName = "";

        public MatchParameter Clone()
        {
            MatchParameter result = new MatchParameter();

            foreach (FieldInfo fi in this.GetType().GetFields())
            {
                object value = fi.GetValue(this);
                fi.SetValue(result, value);
            }

            return result;
        }
    }
}
