using DAL.RepoFactory;

namespace GraovacEdi_OOP_NET
{
    public partial class Settings : Form
    {
        private static string PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "settings.txt");

        public Settings()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (cbChoseWorldCup.SelectedIndex == -1 || cbChoseLanguage.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali parametre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                IRepo repo = RepoFactory.GetRepo();
                repo.SaveUsersSettings(cbChoseLanguage?.SelectedItem.ToString(), cbChoseWorldCup?.SelectedItem.ToString(), PATH);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Pogreška pri spremanju datoteke: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}