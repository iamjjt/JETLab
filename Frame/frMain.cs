using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Frame
{
    public partial class frMain : Form
    {

        string curPaint = @"01.jpg";
        string curFrame = @"f1.png";
        Color bgColor = Color.White;
        public frMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //画1
            curPaint = @"01.jpg";
            FrameIt();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //画2
            curPaint = @"02.jpg";
            FrameIt();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //画3
            curPaint = @"03.jpg";
            FrameIt();
            
        }

        /// <summary>
        /// 为画加框
        /// </summary>
        /// <param name="framePath"></param>
        private void FrameIt()
        {
            //设置画和边框
            Bitmap paint = new Bitmap(curPaint);
            Bitmap frame = new Bitmap(curFrame);
            Bitmap anthorFrame = new Bitmap(curFrame);
            //绘制画框
            Graphics g = Graphics.FromImage(frame);
            g.Clear(bgColor);

            g.FillRectangle(new TextureBrush(new Bitmap(curFrame)), 0, 0, frame.Width, frame.Height);

            anthorFrame.RotateFlip(RotateFlipType.Rotate180FlipNone);
            TextureBrush tb = new TextureBrush(anthorFrame);
            Point[] ps=new Point[]{
                new Point{ X=1000,Y=0},
                new Point{ X=0,Y=1000},
                new Point{ X=1000,Y=1000}
            };
            g.FillPolygon(tb, ps);
            int startX = (frame.Width - paint.Width) / 2;
            int startY = (frame.Height - paint.Height) / 2;
            TextureBrush tb2=new TextureBrush(paint);

            //g.FillRectangle(tb2,startX,startY,paint.Width,paint.Height);
            Rectangle rect=new Rectangle(startX,startY,paint.Width,paint.Height);
            g.DrawImage(paint, rect);

            ThePic.Image = frame;

            g.Dispose();

        }

        private void frMain_Load(object sender, EventArgs e)
        {
            //FrameIt("frame.png");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //框1
            curFrame = @"f1.png";
            FrameIt();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //框2
            curFrame = @"f2.png";
            FrameIt();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //框3
            curFrame = @"f3.png";
            FrameIt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap newbit = new Bitmap("11.png");
            newbit.RotateFlip(RotateFlipType.Rotate180FlipNone);
            ThePic.Image = newbit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap newbit = new Bitmap("11.png");
            newbit.RotateFlip(RotateFlipType.Rotate180FlipX);
            ThePic.Image = newbit;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap newbit = new Bitmap("11.png");
            newbit.RotateFlip(RotateFlipType.Rotate180FlipXY);
            ThePic.Image = newbit;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap newbit = new Bitmap("11.png");
            newbit.RotateFlip(RotateFlipType.Rotate180FlipY);
            ThePic.Image = newbit;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap newbit = new Bitmap("11.png");
            newbit.RotateFlip(RotateFlipType.Rotate270FlipNone);
            ThePic.Image = newbit;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap newbit = new Bitmap("11.png");
            newbit.RotateFlip(RotateFlipType.Rotate270FlipX);
            ThePic.Image = newbit;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap newbit = new Bitmap("f1.png");
            newbit.RotateFlip(RotateFlipType.Rotate180FlipNone);
            ThePic.Image = newbit;
        }

        private void ThePic_Click(object sender, EventArgs e)
        {
            if (ThePic.Image != null)
            {
                paintMax paint = new paintMax(ThePic.Image);
                paint.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // 将先中的颜色设置为窗体的背景色
                bgColor = colorDialog1.Color;
                FrameIt();
            }
        }

    }
}
