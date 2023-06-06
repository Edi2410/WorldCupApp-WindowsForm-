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

namespace Graovac_WPF_PART
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private void SetTeams2()
        {
            repo.GetEnemyTeams().ForEach(team => cbTeam2.Items.Add(team.NationalTeamForChose()));
            
        }

        private void cbTeam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<NationalTeam> teams = repo.GetNationalTeams();
            NationalTeam homeTeam = teams.FirstOrDefault(team => $"{team.Country} ({team.FifaCode})" == cbTeam1.SelectedValue.ToString());
            NationalTeam awayTeam = teams.FirstOrDefault(team => $"{team.Country} ({team.FifaCode})" == cbTeam2.SelectedValue.ToString());


            lbResults.Content = repo.GetResults(homeTeam, awayTeam);
            
        }
    }
}
