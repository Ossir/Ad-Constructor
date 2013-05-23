using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diplom
{
    [Serializable]
    class SerPic
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public string PicArray;
        int Count;

        public SerPic()
        {
        }

        public SerPic(int x, int y, int width, int height, string pic)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.PicArray = pic;
        }

        public void SetCount(int c)
        {
            this.Count = c;
        }

        public int GetCount()
        {
            return this.Count;
        }
    }
}
