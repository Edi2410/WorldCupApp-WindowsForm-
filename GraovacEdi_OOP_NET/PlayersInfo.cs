using DAL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraovacEdi_OOP_NET
{
    public partial class PlayersInfo : UserControl
    {

        private static string IMAGES_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "photos");
        private static string DEFAULT_IMAGE = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "photos\\defaultPhoto.png");
        private Player player;

        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                // Ovdje možete ažurirati informacije na UserControl-u na temelju proslijeđenog igrača (player)
                UpdatePlayerInfo();
            }
        }

        private void UpdatePlayerInfo()
        {
            // Ovdje ažurirajte kontrolama unutar UserControl-a s informacijama o igraču (player)
            if (player != null)
            {
                // Primjer: Postavljanje teksta labele na ime igrača
                labelPlayerName.Text = player.Name;
                labelDresNumber.Text = player.ShirtNumber.ToString();
                labelPosition.Text = player.Position;
                if (player.Captain == true)
                {
                    labelCapetan.Text = "DA";
                    labelCapetan.ForeColor = Color.White;
                }
                else
                {
                    labelCapetan.Text = "NE";
                }
                if (player.Favorite == true)
                {
                    pbStarsForFavorite.Visible = true;
                }
                else
                {
                    pbStarsForFavorite.Visible = false;
                }
                if (File.Exists(Path.Combine(IMAGES_PATH, player.Name) + ".png"))
                {
                    Image image = Image.FromFile(Path.Combine(IMAGES_PATH, player.Name) + ".png");
                    pbPlayer.Image = image;
                    btnAddPhoto.Enabled = false;
                }
                else
                {
                    Image image = Image.FromFile(DEFAULT_IMAGE);
                    pbPlayer.Image = image;
                    btnAddPhoto.Enabled = true;
                }
                pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public PlayersInfo()
        {
            InitializeComponent();
            UpdatePlayerInfo();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        string fileName = labelPlayerName.Text;
                        string extension = Path.GetExtension(openFileDialog.FileName);

                        string playerImagePath = Path.Combine(IMAGES_PATH, $"{fileName}{extension}");

                        File.Copy(openFileDialog.FileName, playerImagePath);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Slika već postoji", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }


                }
                UpdatePlayerInfo();

            }

        }
    }
}
