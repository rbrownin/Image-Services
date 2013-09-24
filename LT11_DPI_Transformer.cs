using System;
using System.Collections.Generic;
using System.Text;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.ImageProcessing;


namespace DPIImageTransformerLT11
{
    public class LT11_DPI_Transformer
    {

        public LT11_DPI_Transformer(string srcFileName, string destFileName) //fully qualified path & filename
        {
            RasterCodecs codecs = new RasterCodecs();

           
            //Read Original Values
            IRasterImage image = codecs.Load(srcFileName);

            //Change values and save a new file name
           
            int newResolution = 300; //BR says all files need to be 300 DPI. This should probably be an enum, db table or config file.

            // Load the source image from disk
            image.XResolution = newResolution;
            image.YResolution = newResolution;
            SizeCommand command = new SizeCommand();
            command.Width = image.Width;
            command.Height = image.Height;
            command.Flags = RasterSizeFlags.Resample;
            command.Run(image);
            //This changes the entire image and all pages. There is no need to pageinate.

            codecs.Save(image, destFileName, RasterImageFormat.Tif, image.BitsPerPixel);
            image.Dispose();

        }
    }
}

