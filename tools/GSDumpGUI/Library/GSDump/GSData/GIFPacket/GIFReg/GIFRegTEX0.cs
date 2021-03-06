﻿/*
 * Copyright (C) 2009-2011 Ferreri Alessio
 * Copyright (C) 2009-2018 PCSX2 Dev Team
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace GSDumpGUI
{
    [Serializable]
    public class GIFRegTEX0 : GIFReg
    {
        public ushort TBP0;
        public byte TBW;
        public TEXPSM PSM;
        public byte TW;
        public byte TH;
        public TEXTCC TCC;
        public TEXTFX TFX;
        public ushort CBP;
        public TEXCPSM CPSM;
        public TEXCSM CSM;
        public byte CSA;
        public byte CLD;

        public GIFRegTEX0(byte addr, UInt64 LowData, UInt64 HighData, bool PackedFormat) : base(addr, LowData, HighData, PackedFormat) { }

        static public GIFReg Unpack(GIFTag tag, byte addr, UInt64 LowData, UInt64 HighData, bool PackedFormat)
        {
            GIFRegTEX0 tex0 = new GIFRegTEX0(addr, LowData, HighData, PackedFormat);
            tex0.Descriptor = (GIFRegDescriptor)addr;
            tex0.TBP0 = (ushort)GetBit(LowData, 0, 14);
            tex0.TBW = (byte)GetBit(LowData, 14, 6);
            tex0.PSM = (TEXPSM)GetBit(LowData, 20, 6);
            tex0.TW = (byte)GetBit(LowData, 26, 4);
            tex0.TH = (byte)GetBit(LowData, 30, 4);
            tex0.TCC = (TEXTCC)GetBit(LowData, 34, 1);
            tex0.TFX = (TEXTFX)GetBit(LowData, 35, 2);
            tex0.CBP = (ushort)GetBit(LowData, 37, 14);
            tex0.CPSM = (TEXCPSM)GetBit(LowData, 51, 4);
            tex0.CSM = (TEXCSM)GetBit(LowData, 55, 1);
            tex0.CSA = (byte)GetBit(LowData, 56, 5);
            tex0.CLD = (byte)GetBit(LowData, 61, 3);
            return tex0;
        }

        public override string ToString()
        {
            return Descriptor.ToString() + "@TBP0 : " + TBP0.ToString() + "@TBW : " + TBW.ToString() + "@PSM : " + PSM.ToString() + "@TW : " + TW.ToString() + "@TH : " + TH.ToString()
                                    + "@TCC : " + TCC.ToString() + "@TFX : " + TFX.ToString() + "@CBP : " + CBP.ToString() + "@CPSM : " + CPSM.ToString() + "@CSM : " + CSM.ToString()
                                    + "@CSA : " + CSA.ToString() + "@CLD : " + CLD.ToString();
        }
    }

    public enum TEXPSM
    {
        PSMCT32 = 0,
        PSMCT24 = 1,
        PSMCT16 = 2,
        PSMCT16S = 10,
        PSMT8 = 19,
        PSMT4 = 20,
        PSMT8H = 27,
        PSMT4HL = 36,
        PSMT4HH = 44,
        PSMZ32 = 48,
        PSMZ24 = 49,
        PSMZ16 = 50,
        PSMZ16S = 58
    }

    public enum TEXTCC
    {
        RGB = 0,
        RGBA = 1
    }

    public enum TEXTFX
    {
        MODULATE = 0,
        DECAL = 1,
        HIGHLIGHT = 2,
        HIGHLIGHT2 = 3
    }

    public enum TEXCPSM
    {
        PSMCT32 = 0,
        PSMCT16 = 2,
        PSMCT16S = 10
    }

    public enum TEXCSM
    {
        CSM1 = 0,
        CSM2 = 1
    }
}
