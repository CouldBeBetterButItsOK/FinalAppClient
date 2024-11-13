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
    /// Lógica de interacción para DNITextBox.xaml
    /// </summary>
    public partial class DNITextBox : UserControl
    {
        // Definició de les DepecncyProperty DNI i Validació
        public static readonly DependencyProperty DNIProperty =
            DependencyProperty.Register(
                "DNI",
                typeof(string),
                typeof(DNITextBox),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnValueChanged));

        public string DNI
        {
            get => (string)GetValue(DNIProperty);
            set => SetValue(DNIProperty, value);
        }

        public DNITextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (s, e) => DNI = textBox.Text;
        }

        // Callback quan la DependencyProperty DNI canvia
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DNITextBox)d;
            var newValue = (string)e.NewValue;
            control.Validate(newValue);
        }

        // Regex de Validació
        private static bool IsValidBool(string newValue)
        {
            var dniRegex = new Regex(@"^\d{8}[A-Za-z]$");
            return dniRegex.IsMatch(newValue);
        }

        // Mètode per validar el format del DNI
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
