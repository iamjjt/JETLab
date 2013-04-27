using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models;
using Mall.ViewModels;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using JETLib.Common;
namespace Mall.Controllers
{
    public class FrameController : Controller
    {

        MallDB db = new MallDB();
        //
        // GET: /Frame/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult FrameIt(int goodId, int paintsizeId)
        {
            PaintFrameViewModel Model = new PaintFrameViewModel
            {
                FrameList = db.Frames.ToList(),
                ChosenSize = db.PaintSizes.Single(p => p.ID == paintsizeId),
                Paint = db.Goods.Single(g => g.ID == goodId),
                PaintFramePrice = 0
            };
            return View(Model);
        }

        public ActionResult FramePaint(int gid, int fid)
        {
            string paintPath = db.Goods.Single(g => g.ID == gid).Img;
            string framePath = db.Frames.Single(f => f.ID == fid).Img;
            //Image img = FrameIt(Server.MapPath("~/"+paintPath), Server.MapPath(@"~/"+framePath), Color.White);
            Image img = FrameIt(Server.MapPath("~/" + paintPath), db.Frames.Single(f => f.ID == fid), Color.White);
            img = GetFramePaint(db.Goods.Single(g => g.ID == gid), db.Frames.Single(f => f.ID == fid), Color.Pink);
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), @"image/png");
        }



        /// <summary>
        /// 为画加框
        /// </summary>
        /// <param name="curPaint">需要加框的画的地址</param>
        /// <param name="curFrame">画框地址</param>
        private Image FrameIt(string curPaint, string curFrame, Color bgColor)
        {
            //设置画和边框
            Bitmap frame = new Bitmap(curFrame);
            Bitmap paint = new Bitmap(curPaint);

            paint = new Bitmap(ImgHelper.ScalingInMode(paint, frame.Width - 200, frame.Height - 200));
            Bitmap anthorFrame = new Bitmap(curFrame);
            //绘制画框
            Graphics g = Graphics.FromImage(frame);
            g.Clear(bgColor);

            g.FillRectangle(new TextureBrush(new Bitmap(curFrame)), 0, 0, frame.Width, frame.Height);

            anthorFrame.RotateFlip(RotateFlipType.Rotate180FlipNone);
            TextureBrush tb = new TextureBrush(anthorFrame);
            Point[] ps = new Point[]{
                new Point{ X=1000,Y=0},
                new Point{ X=0,Y=1000},
                new Point{ X=1000,Y=1000}
            };
            g.FillPolygon(tb, ps);
            int startX = (frame.Width - paint.Width) / 2;
            int startY = (frame.Height - paint.Height) / 2;
            TextureBrush tb2 = new TextureBrush(paint);

            //g.FillRectangle(tb2,startX,startY,paint.Width,paint.Height);
            Rectangle rect = new Rectangle(startX, startY, paint.Width, paint.Height);
            g.DrawImage(paint, rect);

            //ThePic.Image = frame;
            //g.Dispose();
            return frame;

        }
        /// <summary>
        /// 为画加框
        /// </summary>
        /// <param name="curPaint">需要加框的画的地址</param>
        /// <param name="curFrame">画框地址</param>
        private Image FrameIt(string curPaint, Frames theFrame, Color bgColor)
        {
            //设置画和边框
            Bitmap oFrame = new Bitmap(Server.MapPath("~/" + theFrame.Img));

            Bitmap frame = new Bitmap(Server.MapPath("~/" + theFrame.Img));
            Bitmap paint = new Bitmap(curPaint);

            paint = new Bitmap(ImgHelper.ScalingInMode(paint, frame.Width - 100, frame.Height - 100));
            int frameWidth = paint.Width + 100 + theFrame.Width;
            int frameHeight = paint.Height + 100 + theFrame.Width;

            //绘制画框
            Graphics g = Graphics.FromImage(frame);


            //frame = new Bitmap(frame, frameWidth, frameHeight);
            g.DrawImage(frame, new Point(frameWidth, frameHeight));
            Bitmap anthorFrame = new Bitmap(frame);
            g.Clear(bgColor);

            g.FillRectangle(new TextureBrush(oFrame), 0, 0, frameWidth, frameHeight);

            anthorFrame.RotateFlip(RotateFlipType.Rotate180FlipNone);
            TextureBrush tb = new TextureBrush(anthorFrame);
            Point[] ps = new Point[]{
                new Point{ X=frame.Width,Y=0},
                new Point{ X=0,Y=frame.Height},
                new Point{ X=frame.Width,Y=frame.Height}
            };
            g.FillPolygon(tb, ps);
            int startX = (frame.Width - paint.Width) / 2;
            int startY = (frame.Height - paint.Height) / 2;
            TextureBrush tb2 = new TextureBrush(paint);

            //g.FillRectangle(tb2,startX,startY,paint.Width,paint.Height);
            Rectangle rect = new Rectangle(startX, startY, paint.Width, paint.Height);
            g.DrawImage(paint, rect);

            //ThePic.Image = frame;
            //g.Dispose();
            return frame;

        }

        public Image GetFramePaint(Goods paint, Frames frame, Color bgColor)
        {

            //先比较图片和框的尺寸，如果图片的尺寸较大，就缩图片适应框，如果框的尺寸较大，就缩框适应图片
            Bitmap frameImage = new Bitmap(Server.MapPath("~/"+ frame.Img) );
            Bitmap paintImage = new Bitmap(Server.MapPath("~/"+ paint.Img) );
            int frameWidth = frame.Width;
            //如果画比框大,则缩小画到适合框的比例，与框之间留白100px
            if (paintImage.Width > frameImage.Width - frameWidth || paintImage.Height > frameImage.Height - frameWidth)
            {
                //先根据框的大小，缩放画的尺寸到适合框的大小
                paintImage = new Bitmap(ImgHelper.ScalingInMode(paintImage, frameImage.Width - 100 - frameWidth, frameImage.Height - 100 - frameWidth));
            }
            //定义装框后画的尺寸
            int paintFramedWidth = paintImage.Width + frameWidth + 100;
            int paintFramedHeight = paintImage.Height + frameWidth + 100;
            Bitmap thumbFrame = new Bitmap(paintFramedWidth, paintFramedHeight);
            using (Graphics g = Graphics.FromImage(thumbFrame))
            {
                g.Clear(bgColor);
                //g.FillRectangle(new TextureBrush(frameImage), new Rectangle(0, 0, paintFramedWidth, paintFramedHeight));
                //此时，frameImage已经变成了缩放后需要的大小
                g.DrawImage(frameImage, new Rectangle(0, 0, paintFramedWidth, paintFramedHeight));
                //左上，右上，左下
                Point[] ps = new Point[] { 
                    new Point(0,0),
                    new Point(paintFramedWidth,0),
                    new Point(0,paintFramedHeight)
                };
                g.DrawImage(frameImage,ps,new Rectangle(0,0,paintFramedWidth,paintFramedHeight),GraphicsUnit.Pixel);
                Bitmap rightFrame = new Bitmap(thumbFrame);
                rightFrame.RotateFlip(RotateFlipType.Rotate180FlipNone);
                TextureBrush tb = new TextureBrush(rightFrame);
                Point[] rightPs = new Point[]{
                    new Point{ X=rightFrame.Width,Y=0},
                    new Point{ X=rightFrame.Width-frameWidth,Y=frameWidth},
                    new Point{ X=frameWidth,Y=rightFrame.Height-frameWidth},
                    new Point{ X=0,Y=rightFrame.Height},
                    new Point{ X=rightFrame.Width,Y=rightFrame.Height}
                };
                //画另半边框
                g.FillPolygon(tb, rightPs);
                //画画心
                g.DrawImage(paintImage, new Point((thumbFrame.Width - paintImage.Width) / 2, (thumbFrame.Height - paintImage.Height) / 2));

                
            }
            return thumbFrame;
        }

    }
}
