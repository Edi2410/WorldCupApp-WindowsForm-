using DAL.Classes;
using DAL.RepoFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraovacEdi_OOP_NET
{
    public partial class FootballManager : Form
    {
        private static string SETTINGS_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "settings.txt");
        private static string FAVORITETEAM_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "favorite_team.txt");
        private static string FAVORITEPLAYER_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "favorite_player.txt");

        IRepo repo = RepoFactory.GetRepo();

        public FootballManager()
        {
            InitializeComponent();
        }

        private void FootballManager_Load(object sender, EventArgs e)
        {


            SetStartUpSettings();
        }

        private void SetStartUpSettings()
        {
            PlayersInfo playersInfo = pPlayerInfo.Controls.OfType<PlayersInfo>().FirstOrDefault();
            if (playersInfo != null)
            {
                pPlayerInfo.Controls.Remove(playersInfo);
            }

            pFavoritePlayer.Visible = false;
            pPlayers.Visible = false;

            if (!File.Exists(SETTINGS_PATH) || File.ReadAllText(SETTINGS_PATH).Length == 0)
            {
                var settingsForm = new Settings();
                File.Delete(FAVORITETEAM_PATH);
                File.Delete(FAVORITEPLAYER_PATH);
                settingsForm.ShowDialog();
            }

            if (!File.Exists(FAVORITETEAM_PATH))
            {
                repo.GetNationalTeams().ForEach(team => cbChoseFavoriteTeam.Items.Add(team.NationalTeamForChose()));
                tlpFavoriteTeam.Visible = true;
            }
            else
            {
                FillPlayers();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbChoseFavoriteTeam.SelectedIndex == -1)
            {
                MessageBox.Show("Morate odabrat tim", "Error");
                return;
            }
            repo.SaveChosenNationalTeam(cbChoseFavoriteTeam.SelectedItem.ToString(), FAVORITETEAM_PATH);
            tlpFavoriteTeam.Visible = false;
            tlpFavoritePlayer.Visible = true;
            repo.GetPlayers().ForEach(player => clbPlayers.Items.Add(player.PlayerForChackbox()));
        }

        private void btnSaveFavoritePlayers_Click(object sender, EventArgs e)
        {
            if (clbPlayers.CheckedItems.Count < 3)
            {
                MessageBox.Show("Morate odabrati najmanje 3 igrača", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<string> selectedPlayers = new List<string>();
            foreach (string player in clbPlayers.CheckedItems)
            {
                selectedPlayers.Add(player);
            }
            repo.SaveFavoritePlayes(selectedPlayers, FAVORITEPLAYER_PATH);

            tlpFavoritePlayer.Visible = false;
            FillPlayers();
        }

        private void FillPlayers()
        {
            lbPlayers.Visible = true;
            lbFavoritePlayer.Visible = true;
            pPlayers.Visible = true;
            pFavoritePlayer.Visible = true;

            pPlayerInfo.Controls.Add(new PlayersInfo());

            List<Player> listPlayers = repo.GetPlayers();
            string[] FavoritePlayers = repo.GetFavoritePlayers();

            List<Player> favoritePlayers = listPlayers.Where(player => FavoritePlayers.Contains($"{player.Name} ({player.ShirtNumber})")).ToList();
            favoritePlayers.ForEach(player => lbFavoritePlayer.Items.Add(player.PlayerForChackbox()));

            listPlayers.RemoveAll(player => FavoritePlayers.Contains($"{player.Name} ({player.ShirtNumber})"));
            listPlayers.ForEach(player => lbPlayers.Items.Add(player.PlayerForChackbox()));
        }

        //Drag and drop from players to favorite player
        private bool isDragging = false;

        private void lbPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbPlayers.Items.Count > 0 && lbPlayers.SelectedItem != null)
            {
                isDragging = true;
                string selectedPlayer = lbPlayers.SelectedItem.ToString();
                string name = selectedPlayer.Split('(')[0].Trim();

                List<Player> listPlayers = repo.GetPlayers();
                Player player = listPlayers.FirstOrDefault(p => p.Name == name);
                PlayersInfo playersInfo = null;

                foreach (Control control in pPlayerInfo.Controls)
                {
                    if (control is PlayersInfo)
                    {
                        playersInfo = (PlayersInfo)control;
                        break;
                    }
                }

                if (playersInfo != null)
                {
                    playersInfo.Player = player;
                }

                List<string> selectedItems = new List<string>();

                foreach (var selectedItem in lbPlayers.SelectedItems)
                {
                    selectedItems.Add(selectedItem.ToString());
                }

                lbPlayers.DoDragDrop(selectedItems, DragDropEffects.Move);
                lbFavoritePlayer.SelectedItem = null;
            }
        }

        private void lbFavoritePlayer_DragEnter(object sender, DragEventArgs e)
        {
            if (isDragging && lbPlayers.SelectedItem != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lbFavoritePlayer_DragDrop(object sender, DragEventArgs e)
        {
            if (isDragging && lbPlayers.SelectedItem != null)
            {
                List<string> favouritePlayers = repo.GetFavoritePlayers().ToList();
                List<string> draggedItems = (List<string>)e.Data.GetData(typeof(List<string>));

                foreach (var draggedItem in draggedItems)
                {
                    if (lbPlayers.Items.Contains(draggedItem))
                    {
                        favouritePlayers.Add(draggedItem);
                        lbFavoritePlayer.Items.Add(draggedItem);
                        lbPlayers.Items.Remove(draggedItem);
                    }
                }

                repo.SaveFavoritePlayes(favouritePlayers, FAVORITEPLAYER_PATH);
            }
        }

        private void lbFavoritePlayer_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbFavoritePlayer.Items.Count > 0 && lbFavoritePlayer.SelectedItem != null)
            {
                isDragging = true;
                string selectedPlayer = lbFavoritePlayer.SelectedItem.ToString();
                string name = selectedPlayer.Split('(')[0].Trim();

                List<Player> listPlayers = repo.GetPlayers();
                Player player = listPlayers.FirstOrDefault(p => p.Name == name);
                player.Favorite = true;
                PlayersInfo playersInfo = null;

                foreach (Control control in pPlayerInfo.Controls)
                {
                    if (control is PlayersInfo)
                    {
                        playersInfo = (PlayersInfo)control;
                        break;
                    }
                }

                if (playersInfo != null)
                {
                    playersInfo.Player = player;
                }

                List<string> selectedItems = new List<string>();

                foreach (var selectedItem in lbFavoritePlayer.SelectedItems)
                {
                    selectedItems.Add(selectedItem.ToString());
                }

                lbFavoritePlayer.DoDragDrop(selectedItems, DragDropEffects.Move);
                lbPlayers.SelectedItem = null;
            }
        }

        private void lbPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (isDragging && lbFavoritePlayer.SelectedItem != null)
                e.Effect = DragDropEffects.Move;
        }

        private void lbPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (isDragging && lbFavoritePlayer.SelectedItem != null)
            {

                List<string> favouritePlayers = repo.GetFavoritePlayers().ToList();
                List<string> draggedItems = (List<string>)e.Data.GetData(typeof(List<string>));

                foreach (var draggedItem in draggedItems)
                {
                    if (lbFavoritePlayer.Items.Contains(draggedItem))
                    {
                        favouritePlayers.Remove(draggedItem);
                        lbFavoritePlayer.Items.Remove(draggedItem);
                        lbPlayers.Items.Add(draggedItem);
                    }
                }


                repo.SaveFavoritePlayes(favouritePlayers, FAVORITEPLAYER_PATH);
            }
        }

        private void lbPlayers_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

        }

        private void lbFavoritePlayer_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void labelPlayer_Click(object sender, EventArgs e)
        {

        }

        private void postavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(SETTINGS_PATH);
            clbPlayers.Items.Clear();
            cbChoseFavoriteTeam.Items.Clear();
            lbFavoritePlayer.Items.Clear();
            lbPlayers.Items.Clear();
            SetStartUpSettings();

        }

        private void rangListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pFavoritePlayer.Visible = false;
            pPlayers.Visible = false;
            pPlayerInfo.Visible = false;
            lbYellowCarton.Items.Clear();
            lbWisitors.Items.Clear();


            pRangLists.Visible = true;

            repo.GetPlayerStatsData()
                .Where(p => p?.EventType == "goal" || p?.EventType == "yellow-card")
                .GroupBy(p => p?.PlayerName)
                .Select(g => new
                {
                    Name = g.Key,
                    Goals = g.Count(p => p?.EventType == "goal"),
                    Cards = g.Count(p => p?.EventType == "yellow-card")
                })
                .OrderByDescending(p => p?.Goals)
                .ToList().ForEach(stats => lbYellowCarton.Items.Add($"{stats.Name} Cards: {stats.Cards} Goals: {stats.Goals}"));

            repo.GetVisitorsStatsData().ForEach(visitor => lbWisitors.Items.Add(visitor.GetVisitorInfo()));
        }

        private void igraciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pFavoritePlayer.Visible = true;
            pPlayers.Visible = true;
            pPlayerInfo.Visible = true;
            pRangLists.Visible = false;
            lbFavoritePlayer.Items.Clear();
            lbPlayers.Items.Clear();

            FillPlayers();
        }
    }
}
