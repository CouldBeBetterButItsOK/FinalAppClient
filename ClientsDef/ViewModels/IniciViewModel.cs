using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.CompilerServices;
using WPF_MVVM_SPA_Template.Views;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;
using System.Windows.Controls.Primitives;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    class IniciViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        public event PropertyChangedEventHandler? PropertyChanged;
        private bool _isLightTheme = true;
        public bool IsLightTheme
        {
            get { return _isLightTheme; }
            set { _isLightTheme = value; OnPropertyChanged(); }
        }
        private bool _isntLightTheme = false;
        public bool IsntLightTheme
        {
            get { return _isntLightTheme; }
            set { _isntLightTheme = value; OnPropertyChanged(); }
        }
        private string _selectedTheme;
        public string SelectedTheme
        {
            get { return _selectedTheme; }
            set { _selectedTheme = value; OnPropertyChanged(); }
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
      

        public RelayCommand LightThemeCommand { get; set; }
        public RelayCommand DarkThemeCommand { get; set; }

 

        public IniciViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            LightThemeCommand = new RelayCommand(x => SwitchTheme("LightTheme.xaml"));
            DarkThemeCommand = new RelayCommand(x => SwitchTheme("DarkTheme.xaml"));
        }
        public void SwitchTheme(string theme)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            var themeUri = new Uri($"pack://application:,,,/Views/Themes/{theme}", UriKind.Absolute);
            var themeDictionary = new ResourceDictionary { Source = themeUri };
            if (theme.Equals("DarkTheme.xaml")) { 
                IsLightTheme = false;
                IsntLightTheme = true;
            }
            else { 
                IsLightTheme = true;
                IsntLightTheme = false;
            }
            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);

            Application.Current.MainWindow.UpdateLayout();
        }

    }
}
