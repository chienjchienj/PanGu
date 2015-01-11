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

namespace PanGu
{
    [Flags]
    public enum POS
    {
        /// <summary>
        /// 形容詞 形語素
        /// </summary>
        POS_D_A = 0x40000000,	//	形容詞 形語素

        /// <summary>
        /// 區別詞 區別語素
        /// </summary>
        POS_D_B = 0x20000000,	//	區別詞 區別語素

        /// <summary>
        /// 連詞 連語素
        /// </summary>
        POS_D_C = 0x10000000,	//	連詞 連語素

        /// <summary>
        /// 副詞 副語素
        /// </summary>
        POS_D_D = 0x08000000,	//	副詞 副語素

        /// <summary>
        /// 歎詞 歎語素
        /// </summary>
        POS_D_E = 0x04000000,	//	歎詞 歎語素

        /// <summary>
        /// 方位詞 方位語素
        /// </summary>
        POS_D_F = 0x02000000,	//	方位詞 方位語素

        /// <summary>
        /// 成語
        /// </summary>
        POS_D_I = 0x01000000,	//	成語

        /// <summary>
        /// 習語
        /// </summary>
        POS_D_L = 0x00800000,	//	習語

        /// <summary>
        /// 數詞 數語素
        /// </summary>
        POS_A_M = 0x00400000,	//	數詞 數語素

        /// <summary>
        /// 數量詞
        /// </summary>
        POS_D_MQ = 0x00200000,	//	數量詞

        /// <summary>
        /// 名詞 名語素
        /// </summary>
        POS_D_N = 0x00100000,	//	名詞 名語素

        /// <summary>
        /// 擬聲詞
        /// </summary>
        POS_D_O = 0x00080000,	//	擬聲詞

        /// <summary>
        /// 介詞
        /// </summary>
        POS_D_P = 0x00040000,	//	介詞

        /// <summary>
        /// 量詞 量語素
        /// </summary>
        POS_A_Q = 0x00020000,	//	量詞 量語素

        /// <summary>
        /// 代詞 代語素
        /// </summary>
        POS_D_R = 0x00010000,	//	代詞 代語素

        /// <summary>
        /// 處所詞
        /// </summary>
        POS_D_S = 0x00008000,	//	處所詞

        /// <summary>
        /// 時間詞
        /// </summary>
        POS_D_T = 0x00004000,	//	時間詞

        /// <summary>
        /// 助詞 助語素
        /// </summary>
        POS_D_U = 0x00002000,	//	助詞 助語素

        /// <summary>
        /// 動詞 動語素
        /// </summary>
        POS_D_V = 0x00001000,	//	動詞 動語素

        /// <summary>
        /// 標點符號
        /// </summary>
        POS_D_W = 0x00000800,	//	標點符號

        /// <summary>
        /// 非語素字
        /// </summary>
        POS_D_X = 0x00000400,	//	非語素字

        /// <summary>
        /// 語氣詞 語氣語素
        /// </summary>
        POS_D_Y = 0x00000200,	//	語氣詞 語氣語素

        /// <summary>
        /// 狀態詞
        /// </summary>
        POS_D_Z = 0x00000100,	//	狀態詞

        /// <summary>
        /// 人名
        /// </summary>
        POS_A_NR = 0x00000080,	//	人名

        /// <summary>
        /// 地名
        /// </summary>
        POS_A_NS = 0x00000040,	//	地名

        /// <summary>
        /// 機構團體
        /// </summary>
        POS_A_NT = 0x00000020,	//	機構團體

        /// <summary>
        /// 外文字符
        /// </summary>
        POS_A_NX = 0x00000010,	//	外文字符

        /// <summary>
        /// 其他專名
        /// </summary>
        POS_A_NZ = 0x00000008,	//	其他專名

        /// <summary>
        /// 前接成分
        /// </summary>
        POS_D_H = 0x00000004,	//	前接成分

        /// <summary>
        /// 後接成分
        /// </summary>
        POS_D_K = 0x00000002,	//	後接成分

        /// <summary>
        /// 未知詞性
        /// </summary>
        POS_UNK = 0x00000000,   //  未知詞性
    }


}
