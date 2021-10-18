using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web.Mvc;

namespace DesTech
{
    public class CaptchaEngine
    {
        public string CreateCapcthaString()
        {
            const string validChars = "ABCDEFGHJKLMNPRSTUVXYZ";
            const string validNumbers = "123456789";

            StringBuilder res = new StringBuilder();
            System.Random rnd = new System.Random();

            res.Append(validChars[rnd.Next(validChars.Length)]);
            res.Append(validNumbers[rnd.Next(validNumbers.Length)]);
            res.Append(validChars[rnd.Next(validChars.Length)]);
            res.Append(validNumbers[rnd.Next(validNumbers.Length)]);
            res.Append(validChars[rnd.Next(validChars.Length)]);

            return res.ToString();
        }

        public Bitmap Generate(string sCaptchaText)
        {
            int iHeight = 80;
            int iWidth = 190;
            Random oRandom = new Random();

            int[] aBackgroundNoiseColor = new int[] { 150, 150, 150 };
            int[] aTextColor = new int[] { 0, 0, 0 };
            int[] aFontEmSizes = new int[] { 25, 25, 25, 25, 25 };

            string[] aFontNames = new string[]
            {
         "Arial"


            };

            FontStyle[] aFontStyles = new FontStyle[]
            {
         FontStyle.Bold,
         FontStyle.Bold,
         FontStyle.Bold,
         FontStyle.Bold,
         FontStyle.Bold
            };

            HatchStyle[] aHatchStyles = new HatchStyle[]
            {
        HatchStyle.Cross
            };

            //string sCaptchaText = GetCaptchaString(6);
            //context.HttpContext.Session["captchastring"] = sCaptchaText;

            //Creates an output Bitmap
            Bitmap oOutputBitmap = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
            Graphics oGraphics = Graphics.FromImage(oOutputBitmap);
            oGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            //Create a Drawing area
            RectangleF oRectangleF = new RectangleF(0, 0, iWidth, iHeight);
            Brush oBrush = default(Brush);

            //Draw background (Lighter colors RGB 100 to 255)
            oBrush = new HatchBrush(aHatchStyles[oRandom.Next(aHatchStyles.Length - 1)], Color.FromArgb((oRandom.Next(100, 255)), (oRandom.Next(100, 255)), (oRandom.Next(100, 255))), Color.White);
            oGraphics.FillRectangle(oBrush, oRectangleF);

            System.Drawing.Drawing2D.Matrix oMatrix = new System.Drawing.Drawing2D.Matrix();
            int i = 0;
            for (i = 0; i <= sCaptchaText.Length - 1; i++)
            {
                sCaptchaText = sCaptchaText.ToUpper();

                oMatrix.Reset();
                int iChars = sCaptchaText.Length;
                int x = iWidth / (iChars + 1) * i;
                int y = iHeight / 2;

                //Rotate text Random
                oMatrix.RotateAt(oRandom.Next(-20, 20), new PointF(x, y));
                oGraphics.Transform = oMatrix;

                //Draw the letters with Randon Font Type, Size and Color
                oGraphics.DrawString
                (
                //Text
                sCaptchaText.Substring(i, 1),
                //Random Font Name and Style
                new Font(aFontNames[oRandom.Next(aFontNames.Length - 1)], aFontEmSizes[oRandom.Next(aFontEmSizes.Length - 1)], aFontStyles[oRandom.Next(aFontStyles.Length - 1)]),
                //Random Color (Darker colors RGB 0 to 100)
                new SolidBrush(Color.FromArgb(oRandom.Next(0, 100), oRandom.Next(0, 100), oRandom.Next(0, 100))),
                x,
                oRandom.Next(10, 40)
                );

                oGraphics.ResetTransform();
            }

            return oOutputBitmap;
        }

    }

    public class CaptchaImageResult : System.Web.Mvc.ActionResult
    {
        CaptchaEngine captchaEngine = new CaptchaEngine();

        public override void ExecuteResult(ControllerContext context)
        {
            var captchaString = captchaEngine.CreateCapcthaString();
            context.HttpContext.Session["captchastring"] = captchaString.ToUpper();
            var oOutputBitmap = captchaEngine.Generate(captchaString);

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "image/jpeg";

            oOutputBitmap.Save(response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //oOutputBitmap.Save("C:\\Users\\besme\\Desktop\\Opet\\deneme.jpg", ImageFormat.Jpeg);
            oOutputBitmap.Dispose();
        }
    }
}