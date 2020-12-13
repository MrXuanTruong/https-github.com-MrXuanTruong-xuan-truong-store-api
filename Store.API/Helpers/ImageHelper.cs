using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Helpers
{
    public class ImageHelper
    {

        public static bool IsImage(string fileName)
        {
            var list = GetAllImagesExtensions();
            var filename = fileName.ToLower();
            bool isThere = false;
            foreach (var item in list)
            {
                if (filename.EndsWith(item))
                {
                    isThere = true;
                    break;
                }
            }
            return isThere;
        }

        static List<string> allImagesExtensions;
        public static List<string> GetAllImagesExtensions()
        {
            if (allImagesExtensions == null)
            {
                allImagesExtensions = new List<string>();
                allImagesExtensions.Add(".jpg");
                allImagesExtensions.Add(".png");
                allImagesExtensions.Add(".bmp");
                allImagesExtensions.Add(".gif");
                allImagesExtensions.Add(".jpeg");
                allImagesExtensions.Add(".tiff");
            }
            return allImagesExtensions;
        }
    }
}
