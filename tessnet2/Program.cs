using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace TesseractConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code usage sample
            Ocr ocr = new Ocr();
            using (Bitmap bmp = new Bitmap(@"D:\temp\ocr\b1.bmp"))
            