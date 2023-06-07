using DAL.Classes;
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
using System.Windows.Shapes;

namespace Graovac_WPF_PART
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        public TeamDetails(NationalTeam team)
        {
            InitializeComponent();
            SetData(team);
        }

        private void SetData(NationalTeam team)
        {
            labTeamName.Content = team.Country;
            labFifaCode.Content = team.FifaCode;
            labMatchStats.Content = $"{team.GamePlayed}/{team.GameWins}/{team.GameLosses}/{team.GameDraws}";
            labGoalsStats.Content = $"{team.GoalsAgainst}/{team.GoalsFor}/{team.GoalsDiferential}";
        }
    }
}
