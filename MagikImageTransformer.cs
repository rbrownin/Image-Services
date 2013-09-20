using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;


namespace MagikGrayscale
{
    public class MagikImageTransformer
    {
        public void ConvertToGrayScale(string sourceFile, string targetFile)
        {
            

            using (MagickImageCollection images = new MagickImageCollection())
            {
                string newTargetFile = @"D:\Development\Magik\Images\NewTiffs\New.tif";
                MagickReadSettings settings = new MagickReadSettings();
                images.Read(sourceFile, settings);
                settings.FrameIndex = 0; // First page
                settings.FrameCount = images.Count; // Number of pages
                int count = images.Count;

                foreach (MagickImage image in images)
                {
                    image.ColorType = ColorType.Grayscale;
                    image.Quantize();

                    image.Write(newTargetFile + count.ToString() + ".tif");
                    ++count;
                }
            }
               
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo

                {
 
                    FileName = @"C:\Program Files (x86)\ImageMagick-6.8.6-Q8\convert.exe",
                    Arguments = @"D:\Development\Magik\Images\NewTiffs\*.tif D:\Development\Magik\Images\Combined\all-in-one.tif",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
        }



    }
}





