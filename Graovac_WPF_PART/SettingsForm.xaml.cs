using DAL.RepoFactory;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using DAL.Classes;
using DAL.RepoFactory;

namespace Graovac_WPF_PART
{
    /// <summary>
    /// Interaction logic for SettingsFroms.xaml
    /// </summary>
    public partial class SettingsFroms : Window
    {
        private static string WPF_SETTINGS_PATH = System.IO.Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "wpf_settings.txt");
        IRepo repo = RepoFactory.GetRepo();

        public SettingsFroms()
        {
            InitializeComponent();
            CheckIfSettingsExist();
        }

        private void CheckIfSettingsExist()
        {
            if (File.Exists(WPF_SETTINGS_PATH))
            {
                if (repo.GetWidth() == 999999)
                {
                    var mainWindow = new MainWindow();
                    mainWindow.WindowState = WindowState.Maximized;
                    mainWindow.WindowStyle = WindowStyle.None;
                    mainWindow.ResizeMode = ResizeMode.NoResize;
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Width = repo.GetWidth();
                    mainWindow.Height = repo.GetHeight();
                    mainWindow.Show();
                    Close();
                }
            }
        }


        private void btnSettingsSave_Click(object sender, RoutedEventArgs e)
        {
            string language = ((ComboBoxItem)cbWPFLanguage.SelectedItem).Content.ToString();
            string worldCup = ((ComboBoxItem)cbWPFWorldCup.SelectedItem).Content.ToString();
            string windowSize = ((ComboBoxItem)cbWindowSize.SelectedItem).Content.ToString();
            repo.SaveUsersSettings(language, $"{worldCup},{windowSize}", WPF_SETTINGS_PATH);
            CheckIfSettingsExist();
        }
    }
}
