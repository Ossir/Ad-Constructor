using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace diplom
{
    class TextBox: RichTextBox
    {

        //точка перемещения
        Point DownPoint;
        //нажата ли кнопка мыши
        bool IsDragMode;

        //public TextBox()
        //{
        //    SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        //    BackColor = Color.Transparent;
        //    BorderStyle = BorderStyle.None;
        //    ForeColor = Color.Black;
        //    BringToFront();
        //}

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            DownPoint = mevent.Location;
            IsDragMode = true;
            base.OnMouseDown(mevent);
        }
     
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            IsDragMode = false;
            base.OnMouseUp(mevent);
            if (mevent.Button == MouseButtons.Right)
            {
                using (ColorDialog cd = new ColorDialog())
                {
                    cd.FullOpen = true;
                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        this.ForeColor = cd.Color;
                    }
                }
                using (FontDialog fd = new FontDialog())
                {
                    try
                    {
                        fd.AllowScriptChange = false;
                        fd.AllowSimulations = false;
                        if (fd.ShowDialog() == DialogResult.OK)
                        {
                            this.Font = fd.Font;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Not a truetype font
                        MessageBox.Show(this, ex.Message + Environment.NewLine + "Шрифт не изменен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
     
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            //если кнопка мыши нажата
            if (IsDragMode)
            {
                Point p = mevent.Location;
                //вычисляем разницу в координатах между положением курсора и "нулевой" точкой кнопки
                Point dp = new Point(p.X - DownPoint.X, p.Y - DownPoint.Y);
                Location = new Point(Location.X + dp.X, Location.Y + dp.Y);
            }
            base.OnMouseMove(mevent);
        }
    }
}
