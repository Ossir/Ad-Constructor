using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
//using FormSerialisation;

namespace diplom
{
    public partial class Form1 : Form
    {
        int pbCnt = 0;
        DragPictureBox selDPB = null;
        Bitmap img;
        Bitmap img2; 
        List<DragPictureBox> pictureBox1 = new List<DragPictureBox>();
        public Form1()
        {
            InitializeComponent();
        }

        public string ImageToString(Image img)
        {
            Image im = img;
            MemoryStream ms = new MemoryStream();
            im.Save(ms, ImageFormat.Png);
            byte[] array = ms.ToArray();
            return Convert.ToBase64String(array);
        }

        public Image StringToImage(string imageString)
        {
            if (imageString == null)
                throw new ArgumentNullException("imageString");
            byte[] array = Convert.FromBase64String(imageString);
            Image image = Image.FromStream(new MemoryStream(array));
            return image;
        }

        protected override void OnMouseWheel(MouseEventArgs mea)
        {
            // Override OnMouseWheel event, for zooming in/out with the scroll wheel
            if (selDPB != null)
            {
                // If the mouse wheel is moved forward (Zoom in)
                if (mea.Delta > 0)
                {
                    //Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
                    if ((selDPB.Width < (15 * selDPB.Width)) && (selDPB.Height < (15 * selDPB.Height)))
                    {
                        //ImageFormat format = selDPB.Image.RawFormat;
                        Image myBitmap = selDPB.Image;
                        this.selDPB.Size = new Size(myBitmap.Width, myBitmap.Height);
                        Size nSize = new Size((int)(selDPB.Image.Width * 1.05), (int)(selDPB.Image.Height * 1.05));
                        Bitmap gdi = new Bitmap(nSize.Width, nSize.Height);
                        Graphics ZoomInGraphics = Graphics.FromImage(gdi);
                        ZoomInGraphics.SmoothingMode = SmoothingMode.HighQuality;
                        ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        ZoomInGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        ZoomInGraphics.DrawImage(selDPB.Image, new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), selDPB.Image.Size), GraphicsUnit.Pixel);
                        ZoomInGraphics.Dispose();
                        selDPB.Image = gdi;
                        selDPB.Size = gdi.Size;
                        //selDPB.Image.RawFormat = format;
                    }
                }
                else
                {
                    if ((selDPB.Width > (selDPB.Width / 15)) && (selDPB.Height > (selDPB.Height / 15)))
                    {
                        Image myBitmap = selDPB.Image;
                        this.selDPB.Size = new Size(myBitmap.Width, myBitmap.Height);
                        Size nSize = new Size((int)(selDPB.Image.Width / 1.05), (int)(selDPB.Image.Height / 1.05));
                        Bitmap gdi = new Bitmap(nSize.Width, nSize.Height);
                        Graphics ZoomInGraphics = Graphics.FromImage(gdi);
                        ZoomInGraphics.SmoothingMode = SmoothingMode.HighQuality;
                        ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        ZoomInGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        ZoomInGraphics.DrawImage(selDPB.Image, new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), selDPB.Image.Size), GraphicsUnit.Pixel);
                        ZoomInGraphics.Dispose();
                        selDPB.Image = gdi;
                        selDPB.Size = gdi.Size;
                    }
                }
            }
            base.OnMouseWheel(mea);
        }

        private void PBFocusEvent(object sender, EventArgs e)
        {
            selDPB = (DragPictureBox)sender;
            selDPB.Focus();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            pictureBox1.Add(new DragPictureBox());
            pictureBox1.Last().Click += new EventHandler(PBFocusEvent);
            pictureBox1.Last().Name = "dpb" + (pbCnt++).ToString();
            pictureBox1.Last().Width = 1242;
            pictureBox1.Last().Height = 852;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                if (file.Remove(0, file.Length - 2) == "ac")
                {
                    ObjSer os = new ObjSer();
                    pictureBox1.Clear();
                    Stream TestFileStream = File.OpenRead(file);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    os = (ObjSer)deserializer.Deserialize(TestFileStream);
                    TestFileStream.Close();
                    for (int i = 0; i < os.GetPicEnumerator(); i++)
                    {
                        pictureBox1.Add(new DragPictureBox());
                        pictureBox1.Last().Click += new EventHandler(PBFocusEvent);
                        pictureBox1.Last().Width = os.GetFromPicList(i).Width;
                        pictureBox1.Last().Height = os.GetFromPicList(i).Height;
                        pictureBox1.Last().Location = new Point(os.GetFromPicList(i).X, os.GetFromPicList(i).Y);
                        pictureBox1.Last().Image = StringToImage(os.GetFromPicList(i).PicArray);
                        panel1.Controls.Add(pictureBox1.Last());
                        pictureBox1.Last().BringToFront();
                    }
                    for (int i = 0; i < os.GetTextEnumerator(); i++)
                    {
                        AlphaBlendTextBox text = new AlphaBlendTextBox();
                        text.BorderStyle = BorderStyle.FixedSingle;
                        text.ContextMenu = new ContextMenu();
                        text.Multiline = true;
                        text.Font = new Font(os.GetFromTextList(i).FontName, os.GetFromTextList(i).FontSize, os.GetFromTextList(i).FontStyle);
                        text.ForeColor = os.GetFromTextList(i).FontColor;
                        text.Location = new Point(os.GetFromTextList(i).X, os.GetFromTextList(i).Y);
                        text.Text = os.GetFromTextList(i).Text;
                        pictureBox1[os.GetFromTextList(i).PicNumber].Controls.Add(text);
                        text.Focus();
                        text.Select(text.Text.Length, 0);
                    }
                }
                else
                {
                    img = new Bitmap(file);
                    while (img.Height > pictureBox1.Last().Height)
                    {
                        img2 = new Bitmap(img, (int)(img.Width * 0.9), (int)(img.Height * 0.9));
                        img = img2;
                    }
                    pictureBox1.Last().Image = img;
                    pictureBox1.Last().Width = img.Width;
                    pictureBox1.Last().Height = img.Height;
                    pictureBox1.Last().BackColor = Color.Transparent;
                    panel1.Controls.Add(pictureBox1.Last());
                    pictureBox1.Last().BringToFront();
                }
            }
        }

        private void newText_Click(object sender, EventArgs e)
        {
            AlphaBlendTextBox text = new AlphaBlendTextBox();
            text.BorderStyle = BorderStyle.FixedSingle;
            text.ContextMenu = new ContextMenu();
            text.Multiline = true;
            //panel1.Controls.Add(text);
            //text.BringToFront();
            if (selDPB != null)
                selDPB.Controls.Add(text);
            else
                MessageBox.Show("Выберите Картинку на форме");
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            //Bitmap bmp = new Bitmap(this.Size.Width, this.Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Graphics gfx = Graphics.FromImage(bmp);
            //gfx.CopyFromScreen(this.Location.X+17, this.Location.Y+65, 0, 0, this.panel1.Size, CopyPixelOperation.SourceCopy);
            //Создаем Graphics для PictureBox
            Graphics g1 = panel1.CreateGraphics();

            ////Создаем объект Image с теми же параметрами, что и PictureBox
            Image img = new Bitmap(panel1.ClientRectangle.Width, panel1.ClientRectangle.Height, g1);

            //Создаем новый Graphics для рисования на изображении
            Graphics g2 = Graphics.FromImage(img);

            //Получаем контексты рисования для PictureBox и Image из объектов Graphics
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();

            //Копируем изображение с PictureBox на Image
            BitBlt(dc2, 0, 0, panel1.ClientRectangle.Width, panel1.ClientRectangle.Height, dc1, 0, 0, 13369376);

            //Освобождаем ресурсы контекстов рисования
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);

            //Сохраняем изображение в файл
            //img.Save("out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "AC File(*.ac)|*.ac|" +
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            // If selected, save
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // Get the user-selected file name
                string fileName = savedialog.FileName;
                // Get the extension
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                // Save file
                switch (strFilExtn)
                {
                    case "bmp":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case ".ac":
                        ObjSer os = new ObjSer();
                        int pictureNumber = 0;
                        foreach (DragPictureBox pic in pictureBox1)
                        {
                            SerPic sp = new SerPic(pic.Location.X, pic.Location.Y, pic.Width, pic.Height, ImageToString(pic.Image));
                            os.AddToPicList(sp);
                            foreach (Control c in pic.Controls)
                            {
                                if (c is AlphaBlendTextBox)
                                {
                                    SerText st = new SerText(c.Location.X, c.Location.Y, c.Font.Name, c.Font.Size, 
                                        c.ForeColor, pictureNumber, c.Text,c.Font.Style/*,c.Font.Style*/);
                                    os.AddToTextList(st);
                                }
                            }
                            pictureNumber++;
                        }
                        Stream TestFileStream = File.Create(fileName);
                        BinaryFormatter serializer = new BinaryFormatter();
                        serializer.Serialize(TestFileStream, os);
                        TestFileStream.Close();
                        break;
                    default:
                        break;
                }
            }

        }
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nxDest, int nyDest, int nWidth, int nHeight, IntPtr hdcSrc, int nxSrc, int nySrc, int dwRop);

        private void button1_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.FullOpen = true;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    panel1.BackColor = cd.Color;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selDPB != null)
            {               
                pictureBox1.Remove(selDPB);
                selDPB.Dispose();
            }
            else
                MessageBox.Show("Выбирите Картинку на форме!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"help.chm";
            proc.Start();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile("out.jpg");
            Point loc = new Point(50, 50);
            e.Graphics.DrawImage(img, loc);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            //Создаем Graphics для PictureBox
            Graphics g1 = panel1.CreateGraphics();

            ////Создаем объект Image с теми же параметрами, что и PictureBox
            Image img = new Bitmap(panel1.ClientRectangle.Width, panel1.ClientRectangle.Height, g1);

            //Создаем новый Graphics для рисования на изображении
            Graphics g2 = Graphics.FromImage(img);

            //Получаем контексты рисования для PictureBox и Image из объектов Graphics
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();

            //Копируем изображение с PictureBox на Image
            BitBlt(dc2, 0, 0, panel1.ClientRectangle.Width, panel1.ClientRectangle.Height, dc1, 0, 0, 13369376);

            //Освобождаем ресурсы контекстов рисования
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);

            //Сохраняем изображение в файл
            img.Save("out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPage;
                pd.Print();
            }
            //File.Delete("out.jpg");         
        }
    }
}
