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
using WPF_MVVM_SPA_Template.ViewModels;

namespace WPF_MVVM_SPA_Template.Views
{
    /// <summary>
    /// Lógica de interacción para EditarUsuari.xaml
    /// </summary>
    public partial class EditarUsuari : UserControl
    {
        public EditarUsuari()
        {
            InitializeComponent();
    }

        private void Text_Changed(object sender, TextChangedEventArgs e)
        {
            var viewModel = this.DataContext as ClientViewModel;
            if (viewModel != null)
            {
                saveButton.IsEnabled = viewModel.ObligatoryFields;
            }
        }
        private void Text_Changed(object sender, CalendarDateChangedEventArgs e)
        {
            var viewModel = this.DataContext as ClientViewModel;
            if (viewModel != null)
            {
                saveButton.IsEnabled = viewModel.ObligatoryFields;
            }
        }
        private void Text_Changed(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as ClientViewModel;
            if (viewModel != null)
            {
                saveButton.IsEnabled = viewModel.ObligatoryFields;
            }
        }

    }
}
