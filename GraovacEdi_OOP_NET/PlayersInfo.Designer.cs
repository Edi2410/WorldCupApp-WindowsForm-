namespace GraovacEdi_OOP_NET
{
    partial class PlayersInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersInfo));
            btnAddPhoto = new Button();
            labelCapetan = new Label();
            label5 = new Label();
            labelPosition = new Label();
            label4 = new Label();
            labelDresNumber = new Label();
            label3 = new Label();
            labelPlayerName = new Label();
            label2 = new Label();
            pbPlayer = new PictureBox();
            pbStarsForFavorite = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStarsForFavorite).BeginInit();
            SuspendLayout();
            // 
            // btnAddPhoto
            // 
            btnAddPhoto.ImeMode = ImeMode.NoControl;
            btnAddPhoto.Location = new Point(25, 392);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(258, 29);
            btnAddPhoto.TabIndex = 30;
            btnAddPhoto.Text = "Uplodaj sliku";
            btnAddPhoto.UseVisualStyleBackColor = true;
            btnAddPhoto.Click += btnAddPhoto_Click;
            // 
            // labelCapetan
            // 
            labelCapetan.AutoSize = true;
            labelCapetan.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelCapetan.ImeMode = ImeMode.NoControl;
            labelCapetan.Location = new Point(102, 348);
            labelCapetan.MaximumSize = new Size(50, 0);
            labelCapetan.MinimumSize = new Size(20, 0);
            labelCapetan.Name = "labelCapetan";
            labelCapetan.Size = new Size(20, 20);
            labelCapetan.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(25, 348);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 28;
            label5.Text = "Kapetan: ";
            // 
            // labelPosition
            // 
            labelPosition.AutoSize = true;
            labelPosition.ImeMode = ImeMode.NoControl;
            labelPosition.Location = new Point(93, 319);
            labelPosition.MaximumSize = new Size(190, 0);
            labelPosition.MinimumSize = new Size(190, 0);
            labelPosition.Name = "labelPosition";
            labelPosition.Size = new Size(190, 20);
            labelPosition.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(25, 319);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 26;
            label4.Text = "Pozicija:";
            // 
            // labelDresNumber
            // 
            labelDresNumber.AutoSize = true;
            labelDresNumber.ImeMode = ImeMode.NoControl;
            labelDresNumber.Location = new Point(110, 289);
            labelDresNumber.MaximumSize = new Size(100, 0);
            labelDresNumber.MinimumSize = new Size(100, 0);
            labelDresNumber.Name = "labelDresNumber";
            labelDresNumber.Size = new Size(100, 20);
            labelDresNumber.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(25, 289);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 24;
            label3.Text = "Broj dresa:";
            // 
            // labelPlayerName
            // 
            labelPlayerName.AutoSize = true;
            labelPlayerName.ImeMode = ImeMode.NoControl;
            labelPlayerName.Location = new Point(68, 260);
            labelPlayerName.MaximumSize = new Size(200, 0);
            labelPlayerName.MinimumSize = new Size(200, 0);
            labelPlayerName.Name = "labelPlayerName";
            labelPlayerName.Size = new Size(200, 20);
            labelPlayerName.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(25, 260);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 22;
            label2.Text = "Ime:";
            // 
            // pbPlayer
            // 
            pbPlayer.Image = (Image)resources.GetObject("pbPlayer.Image");
            pbPlayer.ImeMode = ImeMode.NoControl;
            pbPlayer.Location = new Point(25, 26);
            pbPlayer.Name = "pbPlayer";
            pbPlayer.Size = new Size(259, 207);
            pbPlayer.TabIndex = 21;
            pbPlayer.TabStop = false;
            // 
            // pbStarsForFavorite
            // 
            pbStarsForFavorite.BackColor = Color.Transparent;
            pbStarsForFavorite.Image = (Image)resources.GetObject("pbStarsForFavorite.Image");
            pbStarsForFavorite.Location = new Point(259, 26);
            pbStarsForFavorite.Name = "pbStarsForFavorite";
            pbStarsForFavorite.Size = new Size(25, 31);
            pbStarsForFavorite.SizeMode = PictureBoxSizeMode.Zoom;
            pbStarsForFavorite.TabIndex = 31;
            pbStarsForFavorite.TabStop = false;
            pbStarsForFavorite.Visible = false;
            // 
            // PlayersInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Fuchsia;
            Controls.Add(pbStarsForFavorite);
            Controls.Add(btnAddPhoto);
            Controls.Add(labelCapetan);
            Controls.Add(label5);
            Controls.Add(labelPosition);
            Controls.Add(label4);
            Controls.Add(labelDresNumber);
            Controls.Add(label3);
            Controls.Add(labelPlayerName);
            Controls.Add(label2);
            Controls.Add(pbPlayer);
            Name = "PlayersInfo";
            Size = new Size(308, 448);
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStarsForFavorite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddPhoto;
        private Label labelCapetan;
        private Label label5;
        private Label labelPosition;
        private Label label4;
        private Label labelDresNumber;
        private Label label3;
        private Label labelPlayerName;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pbPlayer;
        private PictureBox pbStarsForFavorite;
    }
}
