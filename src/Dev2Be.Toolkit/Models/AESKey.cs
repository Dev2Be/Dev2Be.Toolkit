using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Models
{
    public class AESKey
    {
        /// <summary>
        /// Obtenir ou définir la clé AES.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Obtenir ou définir le vecteur d'initialisation.
        /// </summary>
        public string IV { get; set; }
    }
}
