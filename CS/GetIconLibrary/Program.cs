using System;
using System.IO;
using DevExpress.Images;

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
            

            foreach (ImagesAssemblyImageInfo imageInfo in ImagesAssemblyImageList.Images) {
                if (imageInfo.Colored) {
                    using (Stream str = ImageResourceCache.Default.GetResourceByFileName(imageInfo.Name)) {
                        if (str != null) {
                            using (FileStream fileStream = File.Create(filePath + imageInfo.Name)) {
                                str.CopyTo(fileStream);
                                Console.WriteLine("Writing " + imageInfo.Name);
                            }
                        }
                    }
                }
            }

        }
    }

}
