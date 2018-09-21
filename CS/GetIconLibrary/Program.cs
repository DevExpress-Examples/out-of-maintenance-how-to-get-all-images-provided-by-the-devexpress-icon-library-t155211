using System;
using System.Drawing;
using System.IO;
using DevExpress.Images;
using DevExpress.Utils.Design;

namespace GetIconLibrary {

    class Program {
        static void Main(string[] args) {

            string filePath = @"c:\DevExpressIcons\";

            if (!Directory.Exists(filePath)) {
                try {
                    Directory.CreateDirectory(filePath);
                }
                catch (Exception e) {
                    Console.WriteLine("Can't create a directory: {0}", e.ToString());
                }
                finally { }
            }


            StoreImagesByImageType(filePath, ImageType.Colored);

        }

        public static void StoreImagesByImageType(string filePath, ImageType imageType) {
            foreach (ImagesAssemblyImageInfo imageInfo in ImagesAssemblyImageList.Images) {
                var stream = ImageResourceCache.Default.GetResourceByFileName(imageInfo.Name, imageType);
                if (stream == null) continue;
                using (Image image = Image.FromStream(stream)) {
                    image.Save(filePath + imageInfo.Name);
                }
                Console.WriteLine("Writing " + imageInfo.Name);
            }
        }
    }
}
