using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Codecs.Tif;
using Leadtools.Pdf;
using Leadtools.Forms.Ocr;
using Leadtools.Workflow.Ocr;
using Leadtools.Forms.DocumentWriters;
using Leadtools.ImageProcessing;

namespace TIF_Resolution_Converter
{
    public class LT_DPI_Converter
    {

        public LT_DPI_Converter(string srcFileName, string destFileName) //fully qualified path & filename
        {
            RasterCodecs codecs = new RasterCodecs();

            System.IO.File.Copy(srcFileName, destFileName, true);

                //Read Original Values
                RasterImage oldimage = codecs.Load(srcFileName);

                //Change values and save a new file name
                RasterImage newimage = codecs.Load(destFileName);
                int newResolution = 300; //BR says all files need to be 300 DPI. This should probably be an enum.

                // Load the source image from disk
                newimage.XResolution = newResolution;
                newimage.YResolution = newResolution;
                SizeCommand command = new SizeCommand();
                command.Width = oldimage.Width;
                command.Height = oldimage.Height;
                command.Flags = RasterSizeFlags.Resample;
                command.Run(newimage);
                //This changes the entire image and all pages. There is no need to pageinate.

                // Save the image back to disk
                codecs.Save(newimage, destFileName, RasterImageFormat.Tif, oldimage.BitsPerPixel);

            // Clean Up
                newimage.Dispose();
                oldimage.Dispose();
                codecs.Dispose();
        }
    }
}
