using Dev2Be.Toolkit.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class NumericUpDown : WatermarkTextBox
    {
        private bool initializing;

        private string oldText;

        public static DependencyProperty MinimumDependencyProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDown), new UIPropertyMetadata(default(int)));

        public static DependencyProperty MaximumDependencyProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new UIPropertyMetadata(default(int)));

        public static DependencyProperty ValueDependencyProperty = DependencyProperty.Register("Value", typeof(int?), typeof(NumericUpDown), new FrameworkPropertyMetadata(default(int?), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged, null, false, UpdateSourceTrigger.PropertyChanged));

        public int Minimum
        {
            get { return (int)GetValue(MinimumDependencyProperty); }
            set { SetValue(MinimumDependencyProperty, value); }
        }

        public int Maximum
        {
            get { return (int)GetValue(MaximumDependencyProperty); }
            set { SetValue(MaximumDependencyProperty, value); }
        }

        public int? Value
        {
            get { return (int?)GetValue(ValueDependencyProperty); }
            set
            {
                SetValue(ValueDependencyProperty, value);
                // Text = value.ToString();
            }
        }

        private static void OnValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown numericUpDown = dependencyObject as NumericUpDown;

            if (numericUpDown != null)
                numericUpDown.OnValueChanged((int?)e.OldValue, (int?)e.NewValue);
        }

        protected virtual void OnValueChanged(int? oldValue, int? newValue)
        {
            Text = newValue.ToString();
        }

        #region Components
        WatermarkTextBox TextBox { get { return Template.FindName("PART_TextBox", this) as WatermarkTextBox; } }
        RepeatButton UpButton { get { return Template.FindName("PART_UpButton", this) as RepeatButton; } }
        RepeatButton DownButton { get { return Template.FindName("PART_DownButton", this) as RepeatButton; } }
        #endregion Components

        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        public NumericUpDown() : base()
        {
            Text = Value.ToString();
        }

        #region Override
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (UpButton != null)
                UpButton.Click += UpButton_Click;

            if (DownButton != null)
                DownButton.Click += DownButton_Click;
        }

        public override void BeginInit() => initializing = true;

        public override void EndInit()
        {
            initializing = false;

            ConstraintValue();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (!Text.IsNumerical() && !string.IsNullOrEmpty(Text))
            {
                Text = oldText;
                e.Handled = true;
            }

            oldText = Text;

            if (Text.IsNumerical())
                Value = int.Parse(Text);
        }
        #endregion Override

        private void NumericUpDown_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Text = e.Text;
            PreviewTextInput -= NumericUpDown_PreviewTextInput;
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value == null)
            {
                Value = (Minimum > 0) ? Minimum : 0;
                return;
            }

            Value = (Value - 1 > Minimum) ? Value - 1 : Minimum;
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value == null)
            {
                Value = (Minimum > 0) ? Minimum : 0;
                return;
            }

            Value = (Value + 1 < Maximum) ? Value + 1 : Maximum;
        }

        private void ConstraintValue()
        {
            if (initializing)
                return;

            if (Minimum > Maximum)
                Minimum = Maximum;

            if (Maximum < Minimum)
                Maximum = Minimum;

            if (Value > Maximum)
                Value = Maximum;

            if (Value < Minimum)
                Value = Minimum;
        }
    }
}
