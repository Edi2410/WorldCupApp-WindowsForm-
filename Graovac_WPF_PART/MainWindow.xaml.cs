using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Numerics;
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
using DAL.Classes;
using DAL.RepoFactory;
using System.Windows.Media.Animation;

namespace Graovac_WPF_PART
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string WPF_SETTINGS_PATH = System.IO.Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "wpf_settings.txt");
        IRepo repo = RepoFactory.GetRepo();
        public MainWindow()
        {
            InitializeComponent();
            SetStartUpSettings();
        }

        private void SetStartUpSettings()
        {
            repo.GetNationalTeams().ForEach(team => { 
                if(team.FifaCode == repo.GetFifaCode())
                {
                    cbTeam1.Items.Add(team.NationalTeamForChose());
                    cbTeam1.SelectedItem = team.NationalTeamForChose();
                }
                else
                {

                cbTeam1.Items.Add(team.NationalTeamForChose());
                }
            });
            SetTeams2();

        }

        private void SetTeams1Players()
        {
            List<Player> playerList = repo.GetPlayersPositions(GetHomeTeam(), GetAwayTeam());
            Grid homegrid = homeTeamGrid;
            Grid awaygrid = awayTeamGrid;

            foreach (var player in playerList)
            {
                if (player.Position == "Goalie" && player.TeamCode == GetHomeTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    homeGoalie.Children.Add(playerName);
                }
                if (player.Position == "Defender" && player.TeamCode == GetHomeTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    homeDefender.Children.Add(playerName);
                }
                if (player.Position == "Midfield" && player.TeamCode == GetHomeTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    homeMidfield.Children.Add(playerName);
                }
                if (player.Position == "Forward" && player.TeamCode == GetHomeTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    homeForward.Children.Add(playerName);
                }
                if (player.Position == "Forward" && player.TeamCode == GetAwayTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    awayForward.Children.Add(playerName);
                }
                if (player.Position == "Midfield" && player.TeamCode == GetAwayTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    awayMidfield.Children.Add(playerName);
                }
                if (player.Position == "Defender" && player.TeamCode == GetAwayTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    awayDefender.Children.Add(playerName);
                }
                if (player.Position == "Goalie" && player.TeamCode == GetAwayTeam().FifaCode)
                {
                    Button playerName = new Button();
                    playerName.Content = $"{player.Name.Split(" ")[1]} {player.ShirtNumber}";
                    playerName.Click += OpenPlayerInfo(player);
                    awayGoalie.Children.Add(playerName);
                }
            }

        }

        private RoutedEventHandler OpenPlayerInfo(Player player)
        {
            return (sender, e) =>
            {
                new PlayerInfo(player).Show();
            };
        }

        private void SetTeams2()
        {
            repo.GetEnemyTeams(GetHomeTeam()).ForEach(team => cbTeam2.Items.Add(team.NationalTeamForChose()));
        }

        private void cbTeam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            homeDefender.Children.Clear();
            homeGoalie.Children.Clear();
            homeMidfield.Children.Clear();
            homeForward.Children.Clear();
            awayGoalie.Children.Clear();
            awayDefender.Children.Clear();
            awayMidfield.Children.Clear();
            awayForward.Children.Clear();
            btnTeam2Details.IsEnabled = true;
            if(cbTeam2.Items.Count > 0 && cbTeam2.SelectedItem != null)
            {
                lbResults.Content = repo.GetResults(GetHomeTeam(), GetAwayTeam());
            }
            SetTeams1Players();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TeamDetails(GetHomeTeam()).Show();
            
        }

        private NationalTeam GetAwayTeam()
        {
            try
            {if(cbTeam2.SelectedItem != null)
                {
                    List<NationalTeam> teams = repo.GetNationalTeams();
                    return teams.FirstOrDefault(team => $"{team.Country} ({team.FifaCode})" == cbTeam2.SelectedValue.ToString());
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private NationalTeam GetHomeTeam()
        {
            try
            {
                if (cbTeam1.SelectedItem != null)
                {
                    List<NationalTeam> teams = repo.GetNationalTeams();
                    return teams.FirstOrDefault(team => $"{team.Country} ({team.FifaCode})" == cbTeam1.SelectedValue.ToString());
                }   
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnTeam2Details_Click(object sender, RoutedEventArgs e)
        {
             new TeamDetails(GetAwayTeam()).Show();
        }

        private void cbTeam1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbTeam2.SelectedItem = null;
            lbResults.Content = "0 : 0";
            cbTeam2.Items.Clear();
            SetTeams2();
        }

        private void tbSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Želite li promijeniti i spremiti postavke?", "Potvrda spremanja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                File.Delete(WPF_SETTINGS_PATH);
                new SettingsFroms().Show(); 
                Close();
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Želite li zatvoriti aplikaciju?", "Potvrda zatvaranja", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; 
            }
        }
    }
}
