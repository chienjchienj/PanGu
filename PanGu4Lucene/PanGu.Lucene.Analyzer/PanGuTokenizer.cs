using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Lucene.Net.Analysis;
using PanGu;

namespace Lucene.Net.Analysis.PanGu
{
    public class PanGuTokenizer : Tokenizer
    {
        private static object _LockObj = new object();
        private static bool _Inited = false;

        private WordInfo[] _WordList;
        private int _Position = -1; //䊻㔚뺳喐載떃.
        private bool _OriginalResult = false;
        string _InputText;

        static private void InitPanGuSegment()
        {
            //Init PanGu Segment.
            if (!_Inited)
            {
                global::PanGu.Segment.Init();
                _Inited = true;
            }
        }

        /// <summary>
        /// Init PanGu Segment
        /// </summary>
        /// <param name="fileName">PanGu.xml file path</param>
        static public void InitPanGuSegment(string fileName)
        {
            lock (_LockObj)
            {
                //Init PanGu Segment.
                if (!_Inited)
                {
                    global::PanGu.Segment.Init(fileName);
                    _Inited = true;
                }
            }
        }

        public PanGuTokenizer(System.IO.TextReader input, bool originalResult):this(input)
        {
            _OriginalResult = originalResult;
        }

        public PanGuTokenizer()
        {
            lock (_LockObj)
            {
                InitPanGuSegment();
            }
        }

        public PanGuTokenizer(System.IO.TextReader input)
            : base(input) 
        {
            lock (_LockObj)
            {
                InitPanGuSegment();
            }

            _InputText = base.input.ReadToEnd();

            if (string.IsNullOrEmpty(_InputText))
            {
                char[] readBuf = new char[1024];

                int relCount = base.input.Read(readBuf, 0, readBuf.Length);

                StringBuilder inputStr = new StringBuilder(readBuf.Length);


                while (relCount > 0)
                {
                    inputStr.Append(readBuf, 0, relCount);

                    relCount = input.Read(readBuf, 0, readBuf.Length);
                }

                if (inputStr.Length > 0)
                {
                    _InputText = inputStr.ToString();
                }
            }

            if (string.IsNullOrEmpty(_InputText))
            {
                _WordList = new WordInfo[0];
            }
            else
            {
                global::PanGu.Segment segment = new Segment();
                ICollection<WordInfo> wordInfos = segment.DoSegment(_InputText);
                _WordList = new WordInfo[wordInfos.Count];
                wordInfos.CopyTo(_WordList, 0);
            }
        }

        //DotLucene儷ִʆ繰奀䋵㬾͊Ǌ取Tokenizer載ext罷裬ѷֽ⳶4儃趴ʹ錟Ϊһ趔oken㬒⎪TokenʇDotLucene痾ʵĻ鱾奎롣
        public override Token Next()
        {
            if (_OriginalResult)
            {
                string retStr = _InputText;
                
                _InputText = null;

                if (retStr == null)
                {
                    return null;
                }

                return new Token(retStr, 0, retStr.Length);
            }

            int length = 0;    //䊻㵄㤶Ȯ
            int start = 0;     //慠솫҆.

            while (true)
            {
                _Position++;
                if (_Position < _WordList.Length)
                {
                    if (_WordList[_Position] != null)
                    {
                        length = _WordList[_Position].Word.Length;
                        start = _WordList[_Position].Position;
                        return new Token(_WordList[_Position].Word, start, start + length);
                    }
                }
                else
                {
                    break;
                }
            }

            _InputText = null;
            return null;
        }

        public ICollection<WordInfo> SegmentToWordInfos(String str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new LinkedList<WordInfo>();
            }

            global::PanGu.Segment segment = new Segment();
            return segment.DoSegment(str);
        }
    }

}
