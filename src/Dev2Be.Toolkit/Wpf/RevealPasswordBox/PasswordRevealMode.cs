using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Wpf
{
    /// <summary>
    /// Spécifier le mode d'affichage du mot de passe
    /// </summary>
    public enum PasswordRevealMode
    {
        /// <summary>
        /// Cacher le mot de passe et désactiver le bouton permettant de changer l'état du mot de passe.
        /// </summary>
        Hide = 1,
        /// <summary>
        /// Cacher le mot de passe et activer le bouton permettant de changer l'état du mot de passe.
        /// </summary>
        Peak = 0,
        /// <summary>
        /// Afficher le mot de passe et désactiver le bouton permettant de changer l'état du mot de passe.
        /// </summary>
        Visible = 2
    }
}
