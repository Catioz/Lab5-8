using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WebApplication2.Models
{
    public class NotepadModel
    {
        public string App_DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\");
        public string ContentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Content\");

        public void Create(string Name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                System.IO.File.Create(App_DataPath + Name).Close();
            }
        }
        public void Record(string Name, string Text)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                System.IO.File.WriteAllText(App_DataPath + Name, Text + Environment.NewLine);
            }
        }
        public string Load(string Name)
        {
            string item = System.IO.File.ReadAllText(App_DataPath + Name);
            return item;
        }

        public void Image(string Name)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            int width = 0;
            int height = 0;

            // Создаем объект Font для "рисования" им текста.
            Font font = new Font("Arial Black", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            // Создаем объект Graphics для вычисления высоты и ширины текста.
            Graphics graphics = Graphics.FromImage(bitmap);
            // Определение размеров изображения.
            width = (int)graphics.MeasureString(Name, font).Width;
            height = (int)graphics.MeasureString(Name, font).Height;
            // Пересоздаем объект Bitmap с откорректированными размерами под текст и шрифт.
            bitmap = new Bitmap(bitmap, new Size(width, height));
            // Пересоздаем объект Graphics
            graphics = Graphics.FromImage(bitmap);
            // Задаем цвет фона.
            graphics.Clear(Color.WhiteSmoke);
            // Задаем параметры анти-алиасинга
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            // Пишем (рисуем) текст
            graphics.DrawString(Name, font, new SolidBrush(Color.Blue), 0, 0);
            graphics.Flush();

            bitmap.Save(ContentPath + "/name/" + Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }
}