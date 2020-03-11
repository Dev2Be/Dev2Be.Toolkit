using Dev2Be.Toolkit.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dev2Be.Toolkit.UI.Tests
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<ColumnItem> columnItems = new List<ColumnItem>() { new ColumnItem() { Item = "Assembly" }, new ColumnItem() { Item = "Commande" }, new ColumnItem() { Item = "Bibliothèque" }, new ColumnItem() { Item = "Commande" }, new ColumnItem() { Item = "Cycle" }, new ColumnItem() { Item = "Développement" }, new ColumnItem() { Item = "Commentaire" }, new ColumnItem() { Item = "namespace" }, new ColumnItem() { Item = "private" }, new ColumnItem() { Item = "protected" }, new ColumnItem() { Item = "Variable" }, new ColumnItem() { Item = "public" }, new ColumnItem() { Item = "Valeur" }, new ColumnItem() { Item = "Programmation" } };

            TestExtendedListView.ItemsSource = columnItems;
        }

        private void BrowseModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrowseModeComboBox.SelectedIndex == 0)
                BrowseTextBox1.BrowseMode = Wpf.BrowseMode.File;
            else
                BrowseTextBox1.BrowseMode = Wpf.BrowseMode.Folder;
        }

        private void RefreshConnectedStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (NetworkHelper.IsInternetAvailable())
                ConnectedInternetStateTextBlock.Text = "Internet is connected";
            else
                ConnectedInternetStateTextBlock.Text = "Internet is not connected";
        }
    }
}
