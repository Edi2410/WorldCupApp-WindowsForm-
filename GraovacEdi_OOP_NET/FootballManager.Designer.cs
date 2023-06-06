namespace GraovacEdi_OOP_NET
{
    partial class FootballManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FootballManager));
            tlpFavoriteTeam = new TableLayoutPanel();
            lbOmiljeniTeam = new Label();
            btnFavTeamSave = new Button();
            cbChoseFavoriteTeam = new ComboBox();
            menuStrip1 = new MenuStrip();
            igraciToolStripMenuItem = new ToolStripMenuItem();
            postavkeToolStripMenuItem = new ToolStripMenuItem();
            rangListaToolStripMenuItem = new ToolStripMenuItem();
            pPlayers = new Panel();
            lbPlayers = new ListBox();
            labelPlayer = new Label();
            pFavoritePlayer = new Panel();
            labelFavoritePlayer = new Label();
            lbFavoritePlayer = new ListBox();
            tlpFavoritePlayer = new TableLayoutPanel();
            label1 = new Label();
            clbPlayers = new CheckedListBox();
            btnSaveFavoritePlayers = new Button();
            pPlayerInfo = new Panel();
            pRangLists = new Panel();
            lbWisitors = new ListBox();
            label3 = new Label();
            lbYellowCarton = new ListBox();
            label2 = new Label();
            tlpFavoriteTeam.SuspendLayout();
            menuStrip1.SuspendLayout();
            pPlayers.SuspendLayout();
            pFavoritePlayer.SuspendLayout();
            tlpFavoritePlayer.SuspendLayout();
            pPlayerInfo.SuspendLayout();
            pRangLists.SuspendLayout();
            SuspendLayout();
            // 
            // tlpFavoriteTeam
            // 
            resources.ApplyResources(tlpFavoriteTeam, "tlpFavoriteTeam");
            tlpFavoriteTeam.Controls.Add(lbOmiljeniTeam, 0, 0);
            tlpFavoriteTeam.Controls.Add(btnFavTeamSave, 0, 2);
            tlpFavoriteTeam.Controls.Add(cbChoseFavoriteTeam, 0, 1);
            tlpFavoriteTeam.Name = "tlpFavoriteTeam";
            // 
            // lbOmiljeniTeam
            // 
            resources.ApplyResources(lbOmiljeniTeam, "lbOmiljeniTeam");
            lbOmiljeniTeam.Name = "lbOmiljeniTeam";
            // 
            // btnFavTeamSave
            // 
            resources.ApplyResources(btnFavTeamSave, "btnFavTeamSave");
            btnFavTeamSave.Name = "btnFavTeamSave";
            btnFavTeamSave.UseVisualStyleBackColor = true;
            btnFavTeamSave.Click += button1_Click;
            // 
            // cbChoseFavoriteTeam
            // 
            resources.ApplyResources(cbChoseFavoriteTeam, "cbChoseFavoriteTeam");
            cbChoseFavoriteTeam.FormattingEnabled = true;
            cbChoseFavoriteTeam.Name = "cbChoseFavoriteTeam";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { igraciToolStripMenuItem, postavkeToolStripMenuItem, rangListaToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // igraciToolStripMenuItem
            // 
            igraciToolStripMenuItem.Name = "igraciToolStripMenuItem";
            resources.ApplyResources(igraciToolStripMenuItem, "igraciToolStripMenuItem");
            igraciToolStripMenuItem.Click += igraciToolStripMenuItem_Click;
            // 
            // postavkeToolStripMenuItem
            // 
            postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            resources.ApplyResources(postavkeToolStripMenuItem, "postavkeToolStripMenuItem");
            postavkeToolStripMenuItem.Click += postavkeToolStripMenuItem_Click;
            // 
            // rangListaToolStripMenuItem
            // 
            rangListaToolStripMenuItem.Name = "rangListaToolStripMenuItem";
            resources.ApplyResources(rangListaToolStripMenuItem, "rangListaToolStripMenuItem");
            rangListaToolStripMenuItem.Click += rangListaToolStripMenuItem_Click;
            // 
            // pPlayers
            // 
            pPlayers.Controls.Add(lbPlayers);
            pPlayers.Controls.Add(labelPlayer);
            resources.ApplyResources(pPlayers, "pPlayers");
            pPlayers.Name = "pPlayers";
            // 
            // lbPlayers
            // 
            lbPlayers.AllowDrop = true;
            lbPlayers.FormattingEnabled = true;
            resources.ApplyResources(lbPlayers, "lbPlayers");
            lbPlayers.Name = "lbPlayers";
            lbPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbPlayers.DragDrop += lbPlayers_DragDrop;
            lbPlayers.DragEnter += lbPlayers_DragEnter;
            lbPlayers.MouseDown += lbPlayers_MouseDown;
            lbPlayers.MouseUp += lbPlayers_MouseUp;
            // 
            // labelPlayer
            // 
            resources.ApplyResources(labelPlayer, "labelPlayer");
            labelPlayer.Name = "labelPlayer";
            labelPlayer.Click += labelPlayer_Click;
            // 
            // pFavoritePlayer
            // 
            pFavoritePlayer.Controls.Add(labelFavoritePlayer);
            pFavoritePlayer.Controls.Add(lbFavoritePlayer);
            resources.ApplyResources(pFavoritePlayer, "pFavoritePlayer");
            pFavoritePlayer.Name = "pFavoritePlayer";
            // 
            // labelFavoritePlayer
            // 
            resources.ApplyResources(labelFavoritePlayer, "labelFavoritePlayer");
            labelFavoritePlayer.Name = "labelFavoritePlayer";
            // 
            // lbFavoritePlayer
            // 
            lbFavoritePlayer.AllowDrop = true;
            lbFavoritePlayer.FormattingEnabled = true;
            resources.ApplyResources(lbFavoritePlayer, "lbFavoritePlayer");
            lbFavoritePlayer.Name = "lbFavoritePlayer";
            lbFavoritePlayer.SelectionMode = SelectionMode.MultiExtended;
            lbFavoritePlayer.DragDrop += lbFavoritePlayer_DragDrop;
            lbFavoritePlayer.DragEnter += lbFavoritePlayer_DragEnter;
            lbFavoritePlayer.MouseDown += lbFavoritePlayer_MouseDown;
            lbFavoritePlayer.MouseUp += lbFavoritePlayer_MouseUp;
            // 
            // tlpFavoritePlayer
            // 
            resources.ApplyResources(tlpFavoritePlayer, "tlpFavoritePlayer");
            tlpFavoritePlayer.Controls.Add(label1, 0, 0);
            tlpFavoritePlayer.Controls.Add(clbPlayers, 0, 1);
            tlpFavoritePlayer.Controls.Add(btnSaveFavoritePlayers, 0, 2);
            tlpFavoritePlayer.Name = "tlpFavoritePlayer";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // clbPlayers
            // 
            clbPlayers.FormattingEnabled = true;
            resources.ApplyResources(clbPlayers, "clbPlayers");
            clbPlayers.Name = "clbPlayers";
            // 
            // btnSaveFavoritePlayers
            // 
            resources.ApplyResources(btnSaveFavoritePlayers, "btnSaveFavoritePlayers");
            btnSaveFavoritePlayers.Name = "btnSaveFavoritePlayers";
            btnSaveFavoritePlayers.UseVisualStyleBackColor = true;
            btnSaveFavoritePlayers.Click += btnSaveFavoritePlayers_Click;
            // 
            // pPlayerInfo
            // 
            pPlayerInfo.Controls.Add(tlpFavoritePlayer);
            pPlayerInfo.Controls.Add(tlpFavoriteTeam);
            resources.ApplyResources(pPlayerInfo, "pPlayerInfo");
            pPlayerInfo.Name = "pPlayerInfo";
            // 
            // pRangLists
            // 
            pRangLists.Controls.Add(lbWisitors);
            pRangLists.Controls.Add(label3);
            pRangLists.Controls.Add(lbYellowCarton);
            pRangLists.Controls.Add(label2);
            resources.ApplyResources(pRangLists, "pRangLists");
            pRangLists.Name = "pRangLists";
            // 
            // lbWisitors
            // 
            lbWisitors.FormattingEnabled = true;
            resources.ApplyResources(lbWisitors, "lbWisitors");
            lbWisitors.Name = "lbWisitors";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // lbYellowCarton
            // 
            lbYellowCarton.FormattingEnabled = true;
            resources.ApplyResources(lbYellowCarton, "lbYellowCarton");
            lbYellowCarton.Name = "lbYellowCarton";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // FootballManager
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 0, 192);
            Controls.Add(pRangLists);
            Controls.Add(pPlayerInfo);
            Controls.Add(pFavoritePlayer);
            Controls.Add(menuStrip1);
            Controls.Add(pPlayers);
            MainMenuStrip = menuStrip1;
            Name = "FootballManager";
            Load += FootballManager_Load;
            tlpFavoriteTeam.ResumeLayout(false);
            tlpFavoriteTeam.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pPlayers.ResumeLayout(false);
            pPlayers.PerformLayout();
            pFavoritePlayer.ResumeLayout(false);
            pFavoritePlayer.PerformLayout();
            tlpFavoritePlayer.ResumeLayout(false);
            tlpFavoritePlayer.PerformLayout();
            pPlayerInfo.ResumeLayout(false);
            pRangLists.ResumeLayout(false);
            pRangLists.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tlpFavoriteTeam;
        private Label lbOmiljeniTeam;
        private ComboBox cbChoseFavoriteTeam;
        private Button btnFavTeamSave;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem igraciToolStripMenuItem;
        private ToolStripMenuItem postavkeToolStripMenuItem;
        private Panel pPlayers;
        private ListBox lbPlayers;
        private Panel pFavoritePlayer;
        private ListBox lbFavoritePlayer;
        private Label labelPlayer;
        private Label labelFavoritePlayer;
        private TableLayoutPanel tlpFavoritePlayer;
        private Label label1;
        private CheckedListBox clbPlayers;
        private Button btnSaveFavoritePlayers;
        private Panel pPlayerInfo;
        private ToolStripMenuItem rangListaToolStripMenuItem;
        private Panel pRangLists;
        private Label label3;
        private ListBox lbYellowCarton;
        private Label label2;
        private ListBox lbWisitors;
    }
}