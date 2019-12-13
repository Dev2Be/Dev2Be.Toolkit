using Dev2Be.Toolkit.Enumerations;
using System;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;

namespace Dev2Be.Toolkit.Extensions
{
    public static class BitmapImageExtension
    {
        /// <summary>
        /// Sauvegarder l'image en format .png.
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <param name="imagePath">Spécifier le chemin d'enregistrement de l'image.</param>
        public static void Save(this BitmapImage bitmapImage, string imagePath)
        {
            Save(bitmapImage, imagePath, ImageFormat.Png);
        }

        /// <summary>
        /// Sauvegarder l'image dans le format souhaité.
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <param name="imagePath">Spécifier le chemin d'enregistrement de l'image.</param>
        /// <param name="imageFormat">Spécifier le format de l'image.</param>
        public static void Save(this BitmapImage bitmapImage, string imagePath, ImageFormat imageFormat)
        {
            if (imageFormat == ImageFormat.Jpg)
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                    encoder.Save(stream);
            }
            else
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                    encoder.Save(stream);
            }
        }

        /// <summary>
        /// Ouvrir une image se trouvant dans un dossier local dans BitmapImage avant de la sauvegarder en format png.
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <param name="openImagePath">Spécifieer le chemin de l'image à ouvrir.</param>
        /// <param name="saveImagePath">Spécifier le chemin d'enregistrement de l'image.</param>
        public static void Save(this BitmapImage bitmapImage, string openImagePath, string saveImagePath)
        {
            bitmapImage = Open(bitmapImage, openImagePath);

            Save(bitmapImage, saveImagePath);
        }

        /// <summary>
        /// Ouvrir une image dans BitmapImage avant de la sauvegarder dans le format souhaité.
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <param name="openImagePath">Spécifieer le chemin de l'image à ouvrir.</param>
        /// <param name="saveImagePath">Spécifier le chemin d'enregistrement de l'image.</param>
        /// <param name="pathType">Spécifier le type du chemin à ouvrir.</param>
        /// <param name="imageFormat">Spécifier le format de l'image.</param>
        public static void Save(this BitmapImage bitmapImage, string openImagePath, string saveImagePath, PathType pathType, ImageFormat imageFormat)
        {
            bitmapImage = Open(bitmapImage, openImagePath, pathType);

            Save(bitmapImage, saveImagePath, imageFormat);
        }

        /// <summary>
        /// Ouvrir l'image se trouvant dans un dossier local dans BitmapImage.
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <param name="imagePath">Spécifier le chemin de l'image à ouvrir.</param>
        /// <returns></returns>
        public static BitmapImage Open(this BitmapImage bitmapImage, string imagePath)
        {
            return Open(bitmapImage, imagePath, PathType.Local);
        }

        /// <summary>
        /// Ouvrir l'image dans BitmapImage.
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <param name="imagePath">Spécifier le chemin de l'image à ouvrir.</param>
        /// <param name="pathType">Spécifier le type du chemin à ouvrir.</param>
        /// <returns></returns>
        public static BitmapImage Open(this BitmapImage bitmapImage, string imagePath, PathType pathType)
        {
            if (pathType == PathType.Local)
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = new Uri(imagePath);
                bitmapImage.EndInit();
            }
            else
            {
                int BytesToRead = 100;

                WebRequest request = WebRequest.Create(new Uri(imagePath, UriKind.Absolute));
                request.Timeout = -1;

                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                BinaryReader reader = new BinaryReader(responseStream);
                MemoryStream memoryStream = new MemoryStream();

                byte[] bytebuffer = new byte[BytesToRead];
                int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

                while (bytesRead > 0)
                {
                    memoryStream.Write(bytebuffer, 0, bytesRead);
                    bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
                }

                bitmapImage.BeginInit();
                memoryStream.Seek(0, SeekOrigin.Begin);

                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }
    }
}
