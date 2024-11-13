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
    /// Lógica de interacción para PhoneMaskTextBox.xaml
    /// </summary>
    public partial class PhoneMaskTextBox : UserControl
    {

        // Definició de les DepecncyProperty Phone i Validació
        public static readonly DependencyProperty PhoneProperty =
            DependencyProperty.Register(
                "Phone",
                typeof(string),
                typeof(PhoneMaskTextBox),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnValueChanged));
        public string Phone
        {
            get => (string)GetValue(PhoneProperty);
            set => SetValue(PhoneProperty, value);
        }

        public PhoneMaskTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (s, e) => Phone = textBox.Text;
        }

        // Callback quan la DependencyProperty Phone canvia
        public static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (PhoneMaskTextBox)d;
            var newValue = (string)e.NewValue;
            control.Validate(newValue);

        }
        // Regex de Validació
        private static bool IsValidBool(string newValue)
        {
            var vRegex = new Regex(@"^\d{9}$");
            return vRegex.IsMatch(newValue);
        }
        // Mètode per validar el format del Phone
        private void Validate(string newValue)
        {
            if (string.IsNullOrEmpty(newValue) ||IsValidBool(newValue))
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
