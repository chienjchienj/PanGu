using System;
using System.Collections.Generic;
using System.Text;
using PanGu;

namespace CustomRuleExample
{
    /// <summary>
    /// 這個規則用於將文章中的版本號單獨提出來
    /// V1.2.3.4 分詞結果為
    /// v/1.2/1.2.3/1.2.3.4
    /// 這個規則要工作正常，需要將 EnglishMultiDimensionality 開關打開
    /// </summary>
    public class PickupVersion : ICustomRule
    {
        private string _Text;

        #region ICustomRule Members

        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        /// <summary>
        /// 提取版本號
        /// </summary>
        /// <param name="result">盤古分詞的結果</param>
        /// <param name="vWordNode">V 這個字符的第一個出現位置</param>
        /// <param name="lastNode">版本號的最後一個詞</param>
        /// <param name="versionBeginPosition">版本號第一個詞的起始位置</param>
        private void Pickup(SuperLinkedList<WordInfo> result, SuperLinkedListNode<WordInfo> vWordNode,
            SuperLinkedListNode<WordInfo> lastNode, int versionBeginPosition)
        {
            SuperLinkedListNode<WordInfo> node = vWordNode.Next;
            int lastPosition = lastNode.Value.Position + lastNode.Value.Word.Length;

            SuperLinkedListNode<WordInfo> end = lastNode.Next;

            while (node != end)
            {
                result.Remove(node);
                node = vWordNode.Next;
            }

            if (vWordNode.Value.Word == "V")
            {
                vWordNode.Value.Word = "v";
            }

            string version = _Text.Substring(versionBeginPosition, lastPosition - versionBeginPosition);

            int dotPosition = 0;
            int dotCount = 0;

            WordInfo verWord = null;
            dotPosition = version.IndexOf('.', dotPosition);

            while (dotPosition > 0)
            {
                verWord = null;

                if (dotCount > 0) //第一個點之前的版本號不提取
                {
                    //提取前n個子版本號
                    verWord = new WordInfo(version.Substring(0, dotPosition), POS.POS_D_K, 0);
                    verWord.Rank = 1; //這裡設置子版本號的權重
                    verWord.Position = versionBeginPosition;
                    verWord.WordType = WordType.None;
                }

                dotCount++;

                dotPosition = version.IndexOf('.', dotPosition + 1);

                if (verWord != null)
                {
                    result.AddAfter(vWordNode, verWord);
                }
            }

            //提取完整版本號
            verWord = new WordInfo(version, POS.POS_D_K, 0);
            verWord.Rank = 5; //這裡設置完整版本號的權重
            verWord.Position = versionBeginPosition;
            verWord.WordType = WordType.None;
            result.AddAfter(vWordNode, verWord);

        }

        public void AfterSegment(SuperLinkedList<WordInfo> result)
        {
            SuperLinkedListNode<WordInfo> node = result.First;

            SuperLinkedListNode<WordInfo> vWordNode = null;
            SuperLinkedListNode<WordInfo> lastNode = null;
            bool isVersion = false;
            int versionBeginPosition = -1;

            while (node != null)
            {
                if (vWordNode == null)
                {
                    if (node.Value.WordType == WordType.English)
                    {
                        //匹配 V 這個字符，作為版本號的開始
                        if (node.Value.Word.Length == 1)
                        {
                            if (node.Value.Word[0] == 'v' || node.Value.Word[0] == 'V')
                            {
                                vWordNode = node;
                                lastNode = node;
                            }
                        }
                    }
                }
                else if (vWordNode != null)
                {
                    //如果V有多元分詞情況，忽略，跳到下一個
                    if (node.Value.Position == vWordNode.Value.Position)
                    {
                        node = node.Next;
                        continue;
                    }

                    //匹配數字或點
                    if (node.Value.WordType == WordType.Numeric ||
                        node.Value.Word == ".")
                    {
                        if (node.Value.Position - (lastNode.Value.Position + lastNode.Value.Word.Length) <= 1)
                        {
                            if (versionBeginPosition < 0)
                            {
                                versionBeginPosition = node.Value.Position;
                            }

                            isVersion = true;
                            lastNode = node;

                            node = node.Next;
                            continue;
                        }
                    }

                    if (isVersion)
                    {
                        //如果是版本號，提取版本號
                        Pickup(result, vWordNode, lastNode, versionBeginPosition);
                        vWordNode = null;
                        lastNode = null;
                        versionBeginPosition = -1;
                        isVersion = false;
                        continue;
                    }
                }

                node = node.Next;
            }

            if (isVersion)
            {
                //如果是版本號，提取版本號
                Pickup(result, vWordNode, lastNode, versionBeginPosition);
            }
        }

        #endregion

    }
}
