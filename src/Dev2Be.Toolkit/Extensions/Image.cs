using Dev2Be.Toolkit.Enumerations;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Dev2Be.Toolkit.Extensions
{
    public static class ImageExtension
    {
        /// <summary>
        /// Ouvrir une image sur trouvant dans un dossier local dans Image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imagePath">Indiquer le chemin de l'image à ouvrir.</param>
        public static void Open(this Image image, string imagePath)
        {
            Open(image, imagePath, PathType.Local);
        }

        /// <summary>
        /// Ouvrir une image dans Image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imagePath">Indiquer le chemin de l'image à ouvrir.</param>
        /// <param name="pathType">Indiquer le type du chemin.</param>
        public static void Open(this Image image, string imagePath, PathType pathType)
        {
            BitmapImage bitmapImage = new BitmapImage();

            if (pathType == PathType.Local)
            {
                bitmapImage.Open(imagePath);
            }
            else
            {
                bitmapImage.Open(imagePath, PathType.Url);
            }

            image.Source = bitmapImage;
        }
    }
}
