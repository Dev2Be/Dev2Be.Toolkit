using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dev2Be.Toolkit.Wpf
{
    /// <summary>
    /// Représente un contrôle qui permet de rajouter une indication pour l'utilisateur.
    /// </summary>
    public class WatermarkTextBox : TextBox
    {
        #region Variables
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(""));

        /// <summary>
        /// Obtenir ou définir le filigrane de la <see cref="TextBox"/>.
        /// </summary>
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }
        #endregion Variables

        static WatermarkTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBox), new FrameworkPropertyMetadata(typeof(WatermarkTextBox)));
        }

        public WatermarkTextBox() : base()
        {
        }
    }
}
