using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CustomControlsLib
{
    /// <summary>
    /// Lógica de interacción para EmailTextBox.xaml
    /// </summary>
    public partial class EmailTextBox : UserControl
    {

        // Definició de les DepecncyProperty Email i Validació
        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register(
                "Email",
                typeof(string),
                typeof(EmailTextBox),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnValueChanged));

        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }

        public EmailTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (s, e) => Email = textBox.Text;
        }

        // Callback quan la DependencyProperty Email canvia
        public static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (EmailTextBox)d;
            var newValue = (string)e.NewValue;
            control.Validate(newValue);
        }

            // Regex de Validació
            private static bool IsValidBool(string newValue)
        {

            var dniRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return dniRegex.IsMatch(newValue);
        }

        // Mètode per validar el format del Email
        private void Validate(string newValue)
        {
            if (string.IsNullOrEmpty(newValue) || IsValidBool(newValue))
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D5D8DC"));
            }
            else
            {
                border.BorderBrush = new SolidColorBrush(Colors.DarkRed);
            }
        }
    }
}
