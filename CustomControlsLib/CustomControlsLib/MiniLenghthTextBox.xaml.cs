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
    /// Lógica de interacción para MiniLenghthTextBox.xaml
    /// </summary>
    public partial class MiniLenghthTextBox : UserControl
    {
        // Definició de les DepecncyProperty MiniLengthText i Validació
        public static readonly DependencyProperty MiniLengthTextProperty =
            DependencyProperty.Register(
                "MiniLengthText",
                typeof(string),
                typeof(MiniLenghthTextBox),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnValueChanged));
        public string MiniLengthText
        {
            get => (string)GetValue(MiniLengthTextProperty);
            set => SetValue(MiniLengthTextProperty, value);
        }

        public MiniLenghthTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (s, e) => MiniLengthText = textBox.Text;
        }

        // Callback quan la DependencyProperty MiniLengthText canvia
        public static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (MiniLenghthTextBox)d;
            var newValue = (string)e.NewValue;
            control.Validate(newValue);

        }

        // Regex de Validació
        private static bool IsValidBool(string newValue)
        {
       
            var vRegex = new Regex(@"^[A-Za-zÀ-ÿÇçñÑ]{3,}$");
            return vRegex.IsMatch(newValue);
        }

        // Mètode per validar el format del MiniLengthText
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
