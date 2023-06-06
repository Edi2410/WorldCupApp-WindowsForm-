namespace GraovacEdi_OOP_NET
{
    partial class Settings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cbChoseWorldCup = new ComboBox();
            cbChoseLanguage = new ComboBox();
            btnSaveSettings = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(167, 70);
            label1.Name = "label1";
            label1.Size = new Size(167, 50);
            label1.TabIndex = 0;
            label1.Text = "Postavke";
            // 
            // cbChoseWorldCup
            // 
            cbChoseWorldCup.DisplayMember = "Odaberi natjecanje";
            cbChoseWorldCup.FormattingEnabled = true;
            cbChoseWorldCup.Items.AddRange(new object[] { "Musko Svijetsko 2018", "Zensko Svijetsko 2019" });
            cbChoseWorldCup.Location = new Point(90, 154);
            cbChoseWorldCup.Name = "cbChoseWorldCup";
            cbChoseWorldCup.Size = new Size(315, 28);
            cbChoseWorldCup.TabIndex = 1;
            cbChoseWorldCup.Text = "Odaberi natjecanje";
            // 
            // cbChoseLanguage
            // 
            cbChoseLanguage.FormattingEnabled = true;
            cbChoseLanguage.Items.AddRange(new object[] { "Hrvatski ", "Engleski" });
            cbChoseLanguage.Location = new Point(90, 228);
            cbChoseLanguage.Name = "cbChoseLanguage";
            cbChoseLanguage.Size = new Size(315, 28);
            cbChoseLanguage.TabIndex = 2;
            cbChoseLanguage.Text = "Odaberi jezik";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(286, 312);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(184, 29);
            btnSaveSettings.TabIndex = 3;
            btnSaveSettings.Text = "Spremi postavke";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 0, 192);
            ClientSize = new Size(482, 353);
            Controls.Add(btnSaveSettings);
            Controls.Add(cbChoseLanguage);
            Controls.Add(cbChoseWorldCup);
            Controls.Add(label1);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbChoseWorldCup;
        private ComboBox cbChoseLanguage;
        private Button btnSaveSettings;
    }
}