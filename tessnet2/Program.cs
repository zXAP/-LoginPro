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
            {
                tessnet2.Tesseract tessocr = new tessnet2.Tesseract();
                tessocr.Init(null, "eng", false);
                tessocr.GetThresholdedImage(bmp, Rectangle.Empty).Save("c:\\temp\\" + Guid.NewGuid().ToString() + ".bmp");
                // Tessdata directory must be in the directory than this exe
                Console.WriteLine("Multithread version");
                ocr.DoOCRMultiThred(bmp, "eng");
                Console.WriteLine("Normal version");
                ocr.DoOCRNormal(bmp, "eng");
            }
        }
    }

    public class Ocr
    {
        public void DumpResult(List<tessnet2.Word> result)
        {
            foreach (tessnet2.Word word in result)
                Console.WriteLine("{0} : {1}", word.Confidence, word.Text);
        }

        public List<tessnet2.Word> DoOCRNormal(Bitmap image, string lang)
        {
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            ocr.Init(null, lang, false);
            List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);
            DumpResult(result);
            return result;
        }

        ManualResetEvent m_event;

        public void DoOCRMultiThred(Bitmap image, string lang)
        {
            tessnet2.Tesseract ocr = new tessnet2.Tess