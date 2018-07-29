using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dev2Be.Toolkit.Wpf
{
    public class AutoCompleteTextBox : TextBox
    {
        #region Variables
        private bool previousPopupState;

        public static readonly DependencyProperty SuggestionsProperty = DependencyProperty.RegisterAttached("Suggestions", typeof(List<string>), typeof(AutoCompleteTextBox), new PropertyMetadata(new List<string>()));

        /// <summary>
        /// Obtient ou définit la liste des suggestions affichées par l'<see cref="AutoCompleteTextBox"/>.
        /// </summary>
        [Description("Obtient ou définit la liste des suggestion affichées par cet élément.")]
        public List<string> Suggestions
        {
            get { return (List<string>)GetValue(SuggestionsProperty); }
            set { SetValue(SuggestionsProperty, value); }
        }
        #endregion Variables

        #region Components
        Grid Root { get { return Template.FindName("PART_Root", this) as Grid; } }
        Popup SuggestionsPopup { get { return Template.FindName("PART_SuggestionsPopup", this) as Popup; } }
        ListBox SuggestionsList { get { return Template.FindName("PART_SuggestionsList", this) as ListBox; } }
        #endregion Components

        static AutoCompleteTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(typeof(AutoCompleteTextBox)));
        }

        public AutoCompleteTextBox()
        {
            Suggestions = new List<string>();
        }

        #region Override
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PreviewKeyDown += AutoCompleteTextBox_PreviewKeyDown;

            if (SuggestionsList != null)
            {
                SuggestionsList.PreviewKeyDown += SuggestionsList_PreviewKeyDown;
            }

            Window window = GetParentWindow();

            if (window != null)
            {
                window.Deactivated += delegate { previousPopupState = SuggestionsPopup.IsOpen; SuggestionsPopup.IsOpen = false; };
                window.Activated += delegate { SuggestionsPopup.IsOpen = previousPopupState; };
            }
        }

        private Window GetParentWindow()
        {
            DependencyObject dependencyObject = this;

            while (dependencyObject != null && !(dependencyObject is Window))
                dependencyObject = LogicalTreeHelper.GetParent(dependencyObject);

            return dependencyObject as Window;
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            SuggestionsList.ItemsSource = FilterSuggestion(Text);

            SuggestionsPopup.IsOpen = SuggestionsList.Items.Count > 0;
        }
        #endregion

        private void AutoCompleteTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (SuggestionsPopup.IsOpen && !(e.OriginalSource is ListBoxItem))
            {
                switch (e.Key)
                {
                    case Key.Down:
                    case Key.Up:
                        SuggestionsList.Focus();
                        SuggestionsList.SelectedIndex = 0;
                        ListBoxItem lbi = SuggestionsList.ItemContainerGenerator.ContainerFromIndex(SuggestionsList.SelectedIndex) as ListBoxItem;
                        lbi.Focus();
                        e.Handled = true;
                        break;
                }
            }
        }

        private void SuggestionsList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ListBoxItem listBoxItem = e.OriginalSource as ListBoxItem;

            e.Handled = true;

            switch (e.Key)
            {
                case Key.Tab:
                case Key.Enter:
                    Text = listBoxItem.Content as string;
                    break;
                default:
                    e.Handled = false;
                    break;
            }

            if (e.Handled)
            {
                SuggestionsPopup.IsOpen = false;
                Focus();
                Select(Text.Length, 0);
            }
        }

        internal List<string> FilterSuggestion(string value)
        {
            if (string.IsNullOrEmpty(value))
                return default(List<string>);

            return (from suggestion in Suggestions where suggestion.StartsWith(value, StringComparison.CurrentCultureIgnoreCase) select suggestion).ToList();
        }
    }
}
