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

namespace CustomControlsLib
{
    /// <summary>
    /// Lógica de interacción para TextBoxSimple.xaml
    /// </summary>
    public partial class TextBoxSimple : UserControl
    {
        
        // DependencyProperty for the Text property
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(TextBoxSimple),
                new PropertyMetadata(string.Empty));

        // CLR property wrapper
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public TextBoxSimple()
        {
            InitializeComponent();
            textBox.TextChanged += (s, e) => Text = textBox.Text;
        }
    }
}
