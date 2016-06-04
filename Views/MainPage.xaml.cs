using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tasky.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {

            InitializeComponent();

            var isLeftMouseDown = false;

            this.MouseMove += (s, e) => {
                try
                {
                    if (isLeftMouseDown)
                    {
                       
                        DragMove();
                    }
                }
                catch (Exception ex)
                {
                    
                }

            };
            this.MouseLeftButtonDown += (s, e) => { isLeftMouseDown = !isLeftMouseDown; };
            this.MouseLeftButtonUp += (s, e) => { isLeftMouseDown = !isLeftMouseDown; };
            InstallMeOnStartUp();
        }

        private void ShellMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ShellCloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ReCallData();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var _settingsPage = new SettingsPage();
            _settingsPage.Show();
            
        }
        private void InstallMeOnStartUp()
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Assembly curAssembly = Assembly.GetExecutingAssembly();
                key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
            }
            catch { }
        }
    }
}
