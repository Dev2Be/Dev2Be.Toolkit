using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dev2Be.Toolkit.Wpf
{
    /// <summary>
    /// Représente un contrôle permettant de parcourir les fichiers ou les dossiers présent dans l'ordinateur.
    /// </summary>
    public class BrowseTextBox : AutoCompleteTextBox
    {
        #region Variables
        public DependencyProperty BrowseModeProperty = DependencyProperty.RegisterAttached("BrowseMode", typeof(BrowseMode), typeof(BrowseMode), new PropertyMetadata(BrowseMode.File));

        /// <summary>
        /// Obtient ou définit le mode de navigation utilisé par la <see cref="BrowseTextBox"./>
        /// </summary>
        [Description("Obtient ou définit le mode de navigation utilisé par le composant.")]
        public BrowseMode BrowseMode
        {
            get { return (BrowseMode)GetValue(BrowseModeProperty); }
            set { SetValue(BrowseModeProperty, value); }
        }
        #endregion Variables

        #region Components
        Button BrowseButton { get { return Template.FindName("PART_BrowseButton", this) as Button; } }
        #endregion Components

        static BrowseTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BrowseTextBox), new FrameworkPropertyMetadata(typeof(BrowseTextBox)));
        }
        
        #region Override
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (BrowseButton != null)
                BrowseButton.Click += BrowseButton_Click;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            switch (BrowseMode)
            {
                case BrowseMode.File:
                    OpenFileDialog openFileDialog = new OpenFileDialog();

                    if ((bool)openFileDialog.ShowDialog())
                        Text = openFileDialog.FileName;

                    break;
                case BrowseMode.Folder:
                    System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

                    if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        Text = folderBrowserDialog.SelectedPath;

                    break;
                default:
                    break;
            }
        }

        internal override List<string> FilterSuggestion(string value)
        {
            switch (BrowseMode)
            {
                case BrowseMode.File:
                    try
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(value)))
                            return default(List<string>);

                        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(value));

                        if (directoryInfo != null)
                        {
                            FileInfo[] fileInfos = directoryInfo.GetFiles();

                            List<string> files = (from file in fileInfos where file.FullName.StartsWith(value, StringComparison.CurrentCultureIgnoreCase) select file.FullName).ToList();

                            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();

                            List<string> directories = (from directory in directoryInfos where directory.FullName.StartsWith(value, StringComparison.CurrentCultureIgnoreCase) select directory.FullName).ToList();

                            return files.Concat(directories).ToList();
                        }

                        return default(List<string>);
                    }
                    catch (Exception)
                    {
                        return default(List<string>);
                    }
                case BrowseMode.Folder:
                    try
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(value)))
                            return default(List<string>);

                        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(value));

                        if (directoryInfo != null)
                        {
                            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();

                            return (from directory in directoryInfos where directory.FullName.StartsWith(value, StringComparison.CurrentCultureIgnoreCase) select directory.FullName).ToList();
                        }

                        return default(List<string>);
                    }
                    catch (Exception)
                    {
                        return default(List<string>);
                    }
                default:
                    return default(List<string>);
            }
        }
        #endregion Override
    }
}
