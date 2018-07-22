using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Auth
{
    public class RandomCodeEntity
    {
        public string CodeString { get; set; }
        public string CodePicBase64 { get; set; }
        public DateTime StartTime { get; set; }
        public int CodeLife { get; set; }
    }

    public class RandomCodeUtility
    { 
        /// <summary>
        /// 生成验证码字符串
        /// </summary>
        /// <param name="codeLen">验证码字符长度</param>
        /// <returns>返回验证码字符串</returns>
        public static string MakeCode(int codeLen)
        {
            if (codeLen < 1)
            {
                return string.Empty;
            }
            int number;
            StringBuilder sbCheckCode = new StringBuilder();
            Random random = new Random();

            for (int index = 0; index < codeLen; index++)
            {
                number = random.Next();

                if (number % 2 == 0)
                {
                    sbCheckCode.Append((char)('0' + (char)(number % 10))); //生成数字
                }
                else
                {
                    sbCheckCode.Append((char)('A' + (char)(number % 26))); //生成字母
                }
            }
            return sbCheckCode.ToString();
        }

        ///<summary>
        /// 获取验证码图片流
        /// </summary>
        /// <param name="checkCode">验证码字符串</param>
        /// <returns>返回验证码Base64编码的图片流</returns>
        public static string CreateRandomCode(string checkCode)
        {
            string pic = "";

            if (string.IsNullOrEmpty(checkCode))
            {
                return pic;
            }

            Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);
            Graphics graphic = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                graphic.Clear(Color.White);
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                for (int index = 0; index < 25; index++)
                {
                    x1 = random.Next(image.Width);
                    x2 = random.Next(image.Width);
                    y1 = random.Next(image.Height);
                    y2 = random.Next(image.Height);

                    graphic.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Red, Color.DarkRed, 1.2f, true);
                graphic.DrawString(checkCode, font, brush, 2, 2);

                int x = 0;
                int y = 0;

                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    x = random.Next(image.Width);
                    y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                graphic.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                
                //将图片验证码保存为流Stream
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

                // 测试
                //image.Save("test.gif");

                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();

                pic = Convert.ToBase64String(arr);
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
            finally
            {
                graphic.Dispose();
                image.Dispose();
            }

            return pic;
        }
    }
}
