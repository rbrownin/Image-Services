using System;
using System.Collections.Generic;
using System.Text;
using Leadtools;
using Leadtools.Codecs;
using System.IO;
using Leadtools.ImageProcessing;


namespace Leadtools11Grayscale
{
    public class GrayscaleTransformerVersion11
    {
        public static void GrayscaleTransformerVersion11(string srcFileName, string DestFileName)
        {
       
            RasterCodecs codecs = new RasterCodecs();
            UnlockLeadToolsDocumentSupport();

            IRasterImage image = null;
            int pageCount = 0;
			image = codecs.Load(srcFileName);

            pageCount = image.PageCount;
            var bitsPerPixel = 12;

            codecs.Save(image, DestFileName, RasterImageFormat.Tif, bitsPerPixel, 1, pageCount, 1, CodecsSavePageMode.Append);
            image.Dispose();
            
        }

        public static void UnlockLeadToolsDocumentSupport()
        {
            if (RasterSupport.IsLocked(RasterSupportType.Document))
            {
                RasterSupport.Unlock(RasterSupportType.Document, "IxKjEexxS");
            }
        }
    }
}




