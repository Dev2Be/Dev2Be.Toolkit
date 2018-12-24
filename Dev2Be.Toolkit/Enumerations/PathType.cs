using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Enumerations
{
    /// <summary>
    /// Spécifier le type de chemin du fichier.
    /// </summary>
    public enum PathType
    {
        /// <summary>
        /// Indique que le fichier se trouve sur un dossier local (disque interne/externe, etc...).
        /// </summary>
        Local = 0,
        /// <summary>
        /// Indique que le fichier se trouve sur Internet.
        /// </summary>
        Url = 1
    }
}
