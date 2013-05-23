using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace diplom
{
    [Serializable]
    class SerText
    {
        public int X;
        public int Y;
        public string FontName;
        public float FontSize;
        public Color FontColor;
        public int PicNumber;
        public string Text;
        public FontStyle FontStyle;
        //public Font FontInfo;

        public SerText()
        {
        }

        public SerText(int x, int y, string fn, float fs, Color fc, int pn, string t, FontStyle st/*, Font fi*/)
        {
            this.X = x;
            this.Y = y;
            this.FontName = fn;
            this.FontSize = fs;
            this.FontColor = fc;
            this.PicNumber = pn;
            this.Text = t;
            this.FontStyle = st;
            //this.FontInfo = fi;
        }
    }
}
