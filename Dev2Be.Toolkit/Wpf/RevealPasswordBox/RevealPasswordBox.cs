using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Dev2Be.Toolkit.Wpf
{ 
    /// <summary>
    /// Représente un contrôle qui permet de saisir un mot de passe.
    /// </summary>
    public class RevealPasswordBox : WatermarkTextBox
    {
        private WatermarkTextBox PasswordArea { get => Template.FindName("PART_PasswordArea", this) as WatermarkTextBox; }
        private ToggleButton ShowPassword { get { return Template.FindName("PART_ShowPasswordHost", this) as ToggleButton; } }

        #region Variables
        private SecureString encryptedPassword;

        private int caretIndex = -1;

        /// <summary>
        /// Obtient ou définit le mode d'affichage du mot de passe.
        /// </summary>
        [Description("Obtient ou définit le mode d'affichage du mot de passe.")]
        public PasswordRevealMode PasswordRevealMode { get; set; }

        public SecureString EncryptedPassword { get => encryptedPassword; }

        #region Password
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(ExtendedListView), new PropertyMetadata(""));

        /// <summary>
        /// Obtient ou définit le mot de passe.
        /// </summary>
        [Description("Obtient ou définit le mot de passe.")]
        public string Password
        {
            [SecuritySafeCritical]
            get
            {
                string password = "";

                IntPtr intPtr = Marshal.SecureStringToBSTR(EncryptedPassword);

                try
                {
                    password = Marshal.PtrToStringBSTR(intPtr);
                }
                finally
                {
                    Marshal.ZeroFreeBSTR(intPtr);
                }

                return password;
            }
            set
            {
                encryptedPassword = new SecureString();
                
                foreach (char c in value)
                    encryptedPassword.AppendChar(c);

                EncryptedPassword.MakeReadOnly();

                SyncTextAndPassword(caretIndex);
            }
        }
        #endregion Password
        #endregion Variables

        static RevealPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RevealPasswordBox), new FrameworkPropertyMetadata(typeof(RevealPasswordBox)));
        }

        public RevealPasswordBox() : base() { }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (PasswordArea != null)
            {
                PasswordArea.IsUndoEnabled = false;

                DataObject.AddPastingHandler(PasswordArea, OnPaste);
            }

            if (ShowPassword != null)
            {
                switch (PasswordRevealMode)
                {
                    case PasswordRevealMode.Hide:
                        ShowPassword.Visibility = Visibility.Collapsed;
                        break;
                    case PasswordRevealMode.Peak:
                        ShowPassword.Checked += ShowPassword_CheckedChange;
                        ShowPassword.Unchecked += ShowPassword_CheckedChange;
                        ShowPassword.Visibility = Visibility.Visible;
                        break;
                    case PasswordRevealMode.Visible:
                        ShowPassword.Visibility = Visibility.Collapsed;
                        ShowPassword.IsChecked = true;
                        break;
                }
            }
        }

        private void ShowPassword_CheckedChange(object sender, RoutedEventArgs e)
        {
            SyncTextAndPassword(PasswordArea.CaretIndex);
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            bool isText = e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true);

            if (!isText)
                return;

            if (e.SourceDataObject.GetData(DataFormats.UnicodeText) is string text)
                InsertTextPassword(text, PasswordArea.CaretIndex);

            e.CancelCommand();
        }

        [SecuritySafeCritical]
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            InsertTextPassword(e.Text, PasswordArea.CaretIndex);

            e.Handled = true;

            base.OnPreviewTextInput(e);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Back:
                    RemoveTextPassword((PasswordArea.SelectedText.Length > 0) ? PasswordArea.CaretIndex : PasswordArea.CaretIndex - 1);
                    e.Handled = true;
                    break;
                case Key.Delete:
                    RemoveTextPassword(PasswordArea.CaretIndex);
                    e.Handled = true;
                    break;
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if(Text.Length != Password.Length)
            {
                if (string.IsNullOrEmpty(Text))
                    SetPassword("", 0);
                else
                    SyncTextAndPassword(Password.Length);
            }
        }

        [SecurityCritical]
        private void InsertTextPassword(string text, int index)
        {
            if (PasswordArea.SelectedText.Length > 0)
                RemoveTextPassword(index);

            string newPassword = Password;

            for (int i=0; i < text.Length; i++)
                newPassword = newPassword.Insert(index++, text[i].ToString());

            SetPassword(newPassword, index);
        }

        private void SetPassword(string password, int index)
        {
            caretIndex = index;

            Password = password;

            caretIndex = -1;
        }

        [SecurityCritical]
        private void RemoveTextPassword(int index)
        {
            if (index < 0)
                return;

            string newPassword = Password;

            newPassword = (PasswordArea.SelectedText.Length > 0) ? Password.Remove(index, PasswordArea.SelectedText.Length) : Password.Remove(index, 1);

            SetPassword(newPassword, index);
        }

        private void SyncTextAndPassword(int index)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (!(bool)ShowPassword.IsChecked) Text = stringBuilder.Append(Enumerable.Repeat('\u25CF', Password.Length).ToArray()).ToString();
                else
                    Text = Password;

                PasswordArea.CaretIndex = index;
            }
            catch (Exception) { }
        }
    }
}
