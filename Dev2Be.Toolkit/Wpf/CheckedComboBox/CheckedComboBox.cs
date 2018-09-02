using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Dev2Be.Toolkit.Wpf
{
    /// <summary>
    /// Représente un contrôle permettant de séléctionner des élèments dans un <see cref="ComboBox"/>
    /// </summary>
    public class CheckedComboBox : ComboBox
    {
        public static DependencyProperty SeparatorProperty = DependencyProperty.RegisterAttached("Separator", typeof(char), typeof(CheckedComboBox), new PropertyMetadata(','));

        /// <summary>
        /// Obtient ou définit le séparateur utilisé par la <see cref="CheckedComboBox"/>
        /// </summary>
        public char Separator
        {
            get { return (char)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        public static DependencyProperty CheckedItemsProperty = DependencyProperty.RegisterAttached("CheckedItems", typeof(string), typeof(CheckedComboBox), new PropertyMetadata(""));

        /// <summary>
        /// Obtenir les éléments sélectionnés par l'utilisateur.
        /// </summary>
        public string CheckedItems
        {
            get { return (string)GetValue(CheckedItemsProperty); }
        }

        static CheckedComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckedComboBox), new FrameworkPropertyMetadata(typeof(CheckedComboBox)));
        }

        public CheckedComboBox() : base()
        {
            AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ComboBoxItem_Click));
        }

        private void ComboBoxItem_Click(object sender, RoutedEventArgs e)
        {
            string checkedItems = string.Empty;

            foreach (ComboBoxItem comboBoxItem in Items)
            {
                if (comboBoxItem.Template.FindName("PART_CheckBoxBorder", comboBoxItem) is Border border)
                {
                    CheckBox checkBox = comboBoxItem.Template.FindName("PART_ComboBoxItem", comboBoxItem) as CheckBox;

                    if (checkBox.IsChecked.GetValueOrDefault())
                        checkedItems += checkBox.Content + Separator.ToString();
                }
            }

            SetValue(CheckedItemsProperty, checkedItems.Trim(Separator));

            ComboBoxItem comboBoxItemToDisplay = new ComboBoxItem() { Content = checkedItems.Trim(Separator), Visibility = Visibility.Collapsed };

            Items.Add(comboBoxItemToDisplay);

            SelectedItem = comboBoxItemToDisplay;
        }
    }
}
