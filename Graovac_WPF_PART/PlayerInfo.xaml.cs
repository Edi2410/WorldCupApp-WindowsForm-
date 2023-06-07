using DAL.Classes;
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

namespace Graovac_WPF_PART
{
    /// <summary>
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Window
    {
        private static string IMAGES_PATH = System.IO.Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "photos");
        private static string DEFAULT_IMAGE = System.IO.Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "photos\\defaultPhoto.png");
        IRepo repo = RepoFactory.GetRepo();
        
        public PlayerInfo(Player player)
        {
            InitializeComponent();
            SetData(player);
        }

        private void SetData(Player player)
        {
            if (File.Exists(System.IO.Path.Combine(IMAGES_PATH, player.Name) + ".png"))
            {
                string imagePath = System.IO.Path.Combine(IMAGES_PATH, $"{player.Name}.png");
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                imagePlayer.Source = bitmap;
            }
            else
            {
                BitmapImage bitmap = new BitmapImage(new Uri(DEFAULT_IMAGE));
                imagePlayer.Source = bitmap;
            }
            labPlayerName.Content = player.Name;
            labPlayerNumber.Content = player.ShirtNumber;
            labPlayerPosition.Content = player.Position;
            if(player.Captain == true)
            {
                labPlayerIsCapetan.Content = "DA";
            }
            else
            {
                labPlayerIsCapetan.Content = "DA";
            }
            List<Event> events = repo.GetPlayerStats(player.TeamCode);

             events.Where(p => (p?.EventType == "goal" || p?.EventType == "yellow-card") && p?.PlayerName == player.Name)
                .GroupBy(p => p.PlayerName)
                .Select(temp => new
                {
                    Name = temp.Key,
                    Goals = temp.Count(e => e.EventType == "goal"),
                    Cards = temp.Count(e => e.EventType == "yellow-card")
                })
                .ToList().ForEach(data => { 
                        labYellowCardNumber.Content = data.Cards;
                        labPlayerGoals.Content = data.Goals;
                    }); 

        }
    }
}
