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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PanGu;

namespace PosDisplayCtrl
{
    public partial class PosCtrl : UserControl
    {
        const int POS_PER_LINE = 4;
        const int POS_TOP = 0;
        const int POS_LEFT = 0;
        const int POS_WIDTH = 120;
        const int POS_HIGHT = 30;

        Hashtable m_PosTable = new Hashtable();
        int m_Pos = 0;

        public int Pos
        {
            get
            {
                RefreshPos();
                return m_Pos;
            }

            set
            {
                m_Pos = value;
                Display();
            }
        }

        static public String GetChsPos(POS pos)
        {
            switch (pos)
            {
                case POS.POS_D_A:   //  形容詞 形語素
                    return "形容詞 形語素";

                case POS.POS_D_B:   //  區別詞 區別語素
                    return "區別詞 區別語素";

                case POS.POS_D_C:   //  連詞 連語素
                    return "連詞 連語素";

                case POS.POS_D_D:   //  副詞 副語素
                    return "副詞 副語素";

                case POS.POS_D_E:   //  嘆詞 嘆語素
                    return "嘆詞 嘆語素";

                case POS.POS_D_F:   //  方位詞 方位語素
                    return "方位詞 方位語素";

                case POS.POS_D_I:   //  成語
                    return "成語";

                case POS.POS_D_L:   //  習語
                    return "習語";

                case POS.POS_A_M:   //  數詞 數語素
                    return "數詞 數語素";

                case POS.POS_D_MQ:   // 數量詞
                    return "數量詞";

                case POS.POS_D_N:   //  名詞 名語素
                    return "名詞 名語素";

                case POS.POS_D_O:   //  擬聲詞
                    return "擬聲詞";

                case POS.POS_D_P:   //  介詞
                    return "介詞";

                case POS.POS_A_Q:   //  量詞 量語素
                    return "量詞 量語素";

                case POS.POS_D_R:   //  代詞 代語素
                    return "代詞 代語素";

                case POS.POS_D_S:   //  處所詞
                    return "處所詞";

                case POS.POS_D_T:   //  時間詞
                    return "時間詞";

                case POS.POS_D_U:   //  助詞 助語素
                    return "助詞 助語素";

                case POS.POS_D_V:   //  動詞 動語素
                    return "動詞 動語素";

                case POS.POS_D_W:   //  標點符號
                    return "標點符號";

                case POS.POS_D_X:   //  非語素字
                    return "非語素字";

                case POS.POS_D_Y:   //  語氣詞 語氣語素
                    return "語氣詞 語氣語素";

                case POS.POS_D_Z:   //  狀態詞
                    return "狀態詞";

                case POS.POS_A_NR://    人名
                    return "人名";

                case POS.POS_A_NS://    地名
                    return "地名";

                case POS.POS_A_NT://    機構團體
                    return "機構團體";

                case POS.POS_A_NX://    外文字符
                    return "外文字符";

                case POS.POS_A_NZ://    其他專名
                    return "其他專名";

                case POS.POS_D_H:   //  前接成分
                    return "前接成分";

                case POS.POS_D_K:   //  後接成分
                    return "後接成分";

                case POS.POS_UNK://  未知詞性
                    return "未知詞性";

                default:
                    return "未知詞性";

            }
        }


        private void CreatePosCheckBox()
        {
            int pos = 0x40000000;
            this.Width = POS_PER_LINE * POS_WIDTH;
            this.Height = POS_HIGHT * (32 / POS_PER_LINE + 1);

            int j = POS_TOP;
            for (int i = 0; i < 31; i++)
            {
                if (i % POS_PER_LINE == 0)
                {
                    j += POS_HIGHT;
                }

                if (pos == 1)
                {
                    pos = 0;
                }

                POS tPos = (POS)pos;
                CheckBox checkBoxPos = new CheckBox();
                checkBoxPos.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
                m_PosTable[tPos] = checkBoxPos;
                checkBoxPos.Tag = tPos;
                checkBoxPos.Parent = this;
                checkBoxPos.Name = tPos.ToString();
                checkBoxPos.Text = GetChsPos(tPos);

                checkBoxPos.Top = j;
                checkBoxPos.Width = POS_WIDTH;
                checkBoxPos.Left = POS_LEFT + POS_WIDTH * (i % POS_PER_LINE);
                pos >>= 1;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                checkBox.ForeColor = Color.Red;

                CheckBox posCheckBox = (CheckBox)m_PosTable[(POS)0];

                if ((POS)checkBox.Tag == POS.POS_UNK)
                {
                    foreach (object key in m_PosTable.Keys)
                    {
                        posCheckBox = (CheckBox)m_PosTable[key];

                        if ((POS)posCheckBox.Tag == POS.POS_UNK)
                        {
                            continue;
                        }

                        posCheckBox.Checked = false;
                    }
                }
                else
                {
                    posCheckBox.Checked = false;
                }
            }
            else
            {
                checkBox.ForeColor = Color.Black;
            }

        }

        private void RefreshPos()
        {
            CheckBox posCheckBox;

            posCheckBox = (CheckBox)m_PosTable[(POS)0];
            m_Pos = 0;

            int pos = 0x40000000;

            for (int i = 0; i < 30; i++)
            {
                POS tPos = (POS)pos;
                posCheckBox = (CheckBox)m_PosTable[tPos];

                if (posCheckBox.Checked)
                {
                    m_Pos |= pos;
                }

                pos >>= 1;
            }
        }

        private void Display()
        {
            CheckBox posCheckBox;

            posCheckBox = (CheckBox)m_PosTable[(POS)0];

            if (m_Pos == 0)
            {
                foreach(object key in m_PosTable.Keys)
                {
                    ((CheckBox)m_PosTable[key]).Checked = false;
                }

                posCheckBox = (CheckBox)m_PosTable[(POS)0];
                posCheckBox.Checked = true;
                return;
            }
            else
            {
                posCheckBox.Checked = false;
            }

            int pos = 0x40000000;

            for (int i = 0; i < 30; i++)
            {
                POS tPos = (POS)pos;
                posCheckBox = (CheckBox)m_PosTable[tPos];

                if ((m_Pos & pos) != 0)
                {
                    posCheckBox.Checked = true;
                }
                else
                {
                    posCheckBox.Checked = false;
                }

                pos >>= 1;
            }
        }

        public PosCtrl()
        {
            InitializeComponent();

            CreatePosCheckBox();

            Display();
        }
    }
}