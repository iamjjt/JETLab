using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Frame
{
    public partial class frPaintFrame : Form
    {
        public frPaintFrame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //思路：新建画布，然后将边框作为画笔画在画布上，然后计算出中间图的位置，将中间图画上即可。


            Bitmap bg = new Bitmap("framesmall.png");
            bg.RotateFlip(RotateFlipType.Rotate180FlipY);
            bg.RotateFlip(RotateFlipType.Rotate180FlipX);

            //pictureBox1.BackgroundImage = bg;

            //Bitmap background = new Bitmap("framesmall.png");
            Bitmap background = new Bitmap(500, 500);
           
            Graphics baseG = Graphics.FromImage(background);
            Point[] ps = new Point[]{
                new Point{X=0,Y=0},
                new Point{X=500,Y=0},
                new Point{X=500,Y=500}
            };

            TextureBrush tb = new TextureBrush(bg);
            baseG.FillPolygon(tb, ps);

            //pictureBox1.BackgroundImage = background;
            
            
        }
    }
}
