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
        private bool updateOriginalText = true;

        private string originalText;

        public static readonly DependencyProperty SuggestionsProperty = DependencyProperty.RegisterAttached("Suggestions", typeof(List<string>), typeof(AutoCompleteTextBox), new PropertyMetadata(new List<string>()));

        public static readonly DependencyProperty ShowSuggestionsProperty = DependencyProperty.RegisterAttached("ShowSuggestions", typeof(bool), typeof(AutoCompleteTextBox), new PropertyMetadata(true));

        /// <summary>
        /// Obtient ou définit la liste des suggestions affichées par l'<see cref="AutoCompleteTextBox"/>.
        /// </summary>
        [Description("Obtient ou définit la liste des suggestion affichées par cet élément.")]
        public List<string> Suggestions
        {
            get { return (List<string>)GetValue(SuggestionsProperty); }
            set { SetValue(SuggestionsProperty, value); }
        }

        /// <summary>
        /// Obtient ou définit l'état de visibilité de la liste des suggestions.
        /// </summary>
        [Description("Obtient ou définit l'état de visibilité de la liste des suggestions.")]
        public bool ShowSuggestions
        {
            get { return (bool)GetValue(ShowSuggestionsProperty); }
            set { SetValue(ShowSuggestionsProperty, value); }
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
                SuggestionsList.PreviewMouseLeftButtonDown += SuggestionsList_PreviewMouseLeftButtonDown;
            }

            Window window = GetParentWindow();

            if (window != null)
            {
                window.Deactivated += delegate { previousPopupState = SuggestionsPopup.IsOpen; SuggestionsPopup.IsOpen = false; };
                window.Activated += delegate { SuggestionsPopup.IsOpen = previousPopupState; };
            }
        }

        private void SuggestionsList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Text = (ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem).Content as string;
            
            SuggestionsPopup.IsOpen = false;
            Focus();
            Select(Text.Length, 0);
            updateOriginalText = true;
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (!updateOriginalText)
                return;

            base.OnTextChanged(e);

            originalText = Text;

            if (ShowSuggestions) 
            {
                SuggestionsList.ItemsSource = FilterSuggestion(originalText);

                SuggestionsPopup.IsOpen = SuggestionsList.Items.Count > 0;
            }
        }
        #endregion

        #region Events
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
                        updateOriginalText = false;

                        Text = lbi.Content as string;
                        break;
                }
            }
        }

        private void SuggestionsList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.Key)
            {
                case Key.Tab:
                case Key.Enter:
                    Text = (e.OriginalSource as ListBoxItem).Content as string;
                    break;
                case Key.Escape:
                    Text = originalText;
                    break;
                case Key.Down:
                    if (SuggestionsList.SelectedIndex + 1 >= SuggestionsList.Items.Count)
                        SuggestionsList.SelectedIndex = 0;
                    else
                        SuggestionsList.SelectedIndex++;

                    Text = SuggestionsList.SelectedItem.ToString();

                    e.Handled = false;
                    break;
                case Key.Up:
                    if (SuggestionsList.SelectedIndex - 1 < 0)
                        SuggestionsList.SelectedIndex = SuggestionsList.Items.Count - 1;
                    else
                        SuggestionsList.SelectedIndex--;

                    Text = SuggestionsList.SelectedItem.ToString();

                    e.Handled = false;
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
                updateOriginalText = true;
            }
        }
        #endregion Events

        private Window GetParentWindow()
        {
            DependencyObject dependencyObject = this;

            while (dependencyObject != null && !(dependencyObject is Window))
                dependencyObject = LogicalTreeHelper.GetParent(dependencyObject);

            return dependencyObject as Window;
        }

        internal virtual List<string> FilterSuggestion(string value)
        {
            if (string.IsNullOrEmpty(value))
                return default(List<string>);

            return (from suggestion in Suggestions where suggestion.StartsWith(value, StringComparison.CurrentCultureIgnoreCase) select suggestion).ToList();
        }
    }
}
