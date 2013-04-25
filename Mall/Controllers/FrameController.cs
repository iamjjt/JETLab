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

        public ActionResult FrameIt(int goodId,int paintsizeId)
        {
            PaintFrameViewModel Model = new PaintFrameViewModel { 
                 FrameList=db.Frames.ToList(),
                  ChosenSize=db.PaintSizes.Single(p=>p.ID==paintsizeId),
                 Paint=db.Goods.Single(g=>g.ID==goodId),
                  PaintFramePrice=0
            };
            return View(Model);
        }

        public ActionResult FramePaint(int gid,int fid)
        {
            string paintPath = db.Goods.Single(g => g.ID == gid).Img;
            string framePath = db.Frames.Single(f => f.ID == fid).Img;
            Image img = FrameIt(Server.MapPath("~/"+paintPath), Server.MapPath(@"~/"+framePath), Color.White);
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);
            return File(stream.ToArray(), @"image/jpeg");
        }

       

        /// <summary>
        /// 为画加框
        /// </summary>
        /// <param name="curPaint">需要加框的画的地址</param>
        /// <param name="curFrame">画框地址</param>
        private Image FrameIt(string curPaint,string curFrame,Color bgColor)
        {

            //设置画和边框
            Bitmap frame = new Bitmap(curFrame);
            Bitmap paint = new Bitmap(curPaint);

            paint = new Bitmap(ImgHelper.ScalingInMode(paint, frame.Width-200, frame.Height-200));
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

    }
}
