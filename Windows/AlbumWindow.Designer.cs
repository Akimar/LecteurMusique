namespace LecteurMusique.Windows
{
    partial class AlbumWindow
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
            this.labelNom = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelArtiste = new System.Windows.Forms.Label();
            this.labelNbMusiques = new System.Windows.Forms.Label();
            this.labelAnnee = new System.Windows.Forms.Label();
            this.textBoxArtiste = new System.Windows.Forms.TextBox();
            this.textBoxNbMusiques = new System.Windows.Forms.TextBox();
            this.textBoxAnnee = new System.Windows.Forms.TextBox();
            this.buttonValider = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.textBoxJaquette = new System.Windows.Forms.TextBox();
            this.labelJaquette = new System.Windows.Forms.Label();
            this.buttonJaquette = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Location = new System.Drawing.Point(109, 34);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(29, 13);
            this.labelNom.TabIndex = 0;
            this.labelNom.Text = "Nom";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(208, 34);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(154, 20);
            this.textBoxNom.TabIndex = 1;
            // 
            // labelArtiste
            // 
            this.labelArtiste.AutoSize = true;
            this.labelArtiste.Location = new System.Drawing.Point(109, 74);
            this.labelArtiste.Name = "labelArtiste";
            this.labelArtiste.Size = new System.Drawing.Size(36, 13);
            this.labelArtiste.TabIndex = 2;
            this.labelArtiste.Text = "Artiste";
            // 
            // labelNbMusiques
            // 
            this.labelNbMusiques.AutoSize = true;
            this.labelNbMusiques.Location = new System.Drawing.Point(109, 114);
            this.labelNbMusiques.Name = "labelNbMusiques";
            this.labelNbMusiques.Size = new System.Drawing.Size(89, 13);
            this.labelNbMusiques.TabIndex = 3;
            this.labelNbMusiques.Text = "Nombre de pistes";
            // 
            // labelAnnee
            // 
            this.labelAnnee.AutoSize = true;
            this.labelAnnee.Location = new System.Drawing.Point(112, 160);
            this.labelAnnee.Name = "labelAnnee";
            this.labelAnnee.Size = new System.Drawing.Size(38, 13);
            this.labelAnnee.TabIndex = 4;
            this.labelAnnee.Text = "Année";
            // 
            // textBoxArtiste
            // 
            this.textBoxArtiste.Location = new System.Drawing.Point(208, 74);
            this.textBoxArtiste.Name = "textBoxArtiste";
            this.textBoxArtiste.Size = new System.Drawing.Size(154, 20);
            this.textBoxArtiste.TabIndex = 5;
            // 
            // textBoxNbMusiques
            // 
            this.textBoxNbMusiques.Location = new System.Drawing.Point(208, 114);
            this.textBoxNbMusiques.Name = "textBoxNbMusiques";
            this.textBoxNbMusiques.Size = new System.Drawing.Size(154, 20);
            this.textBoxNbMusiques.TabIndex = 6;
            // 
            // textBoxAnnee
            // 
            this.textBoxAnnee.Location = new System.Drawing.Point(208, 160);
            this.textBoxAnnee.Name = "textBoxAnnee";
            this.textBoxAnnee.Size = new System.Drawing.Size(154, 20);
            this.textBoxAnnee.TabIndex = 7;
            // 
            // buttonValider
            // 
            this.buttonValider.Location = new System.Drawing.Point(112, 259);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(75, 23);
            this.buttonValider.TabIndex = 8;
            this.buttonValider.Text = "Valider";
            this.buttonValider.UseVisualStyleBackColor = true;
            this.buttonValider.Click += new System.EventHandler(this.buttonValider_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(379, 259);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 9;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // textBoxJaquette
            // 
            this.textBoxJaquette.Location = new System.Drawing.Point(208, 205);
            this.textBoxJaquette.Name = "textBoxJaquette";
            this.textBoxJaquette.Size = new System.Drawing.Size(154, 20);
            this.textBoxJaquette.TabIndex = 10;
            // 
            // labelJaquette
            // 
            this.labelJaquette.AutoSize = true;
            this.labelJaquette.Location = new System.Drawing.Point(112, 205);
            this.labelJaquette.Name = "labelJaquette";
            this.labelJaquette.Size = new System.Drawing.Size(48, 13);
            this.labelJaquette.TabIndex = 11;
            this.labelJaquette.Text = "Jaquette";
            // 
            // buttonJaquette
            // 
            this.buttonJaquette.Location = new System.Drawing.Point(379, 205);
            this.buttonJaquette.Name = "buttonJaquette";
            this.buttonJaquette.Size = new System.Drawing.Size(75, 23);
            this.buttonJaquette.TabIndex = 12;
            this.buttonJaquette.Text = "Ouvrir";
            this.buttonJaquette.UseVisualStyleBackColor = true;
            this.buttonJaquette.Click += new System.EventHandler(this.buttonJaquette_Click);
            // 
            // AlbumWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 318);
            this.Controls.Add(this.buttonJaquette);
            this.Controls.Add(this.labelJaquette);
            this.Controls.Add(this.textBoxJaquette);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.textBoxAnnee);
            this.Controls.Add(this.textBoxNbMusiques);
            this.Controls.Add(this.textBoxArtiste);
            this.Controls.Add(this.labelAnnee);
            this.Controls.Add(this.labelNbMusiques);
            this.Controls.Add(this.labelArtiste);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.labelNom);
            this.Name = "AlbumWindow";
            this.Text = "Album";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label labelArtiste;
        private System.Windows.Forms.Label labelNbMusiques;
        private System.Windows.Forms.Label labelAnnee;
        private System.Windows.Forms.TextBox textBoxArtiste;
        private System.Windows.Forms.TextBox textBoxNbMusiques;
        private System.Windows.Forms.TextBox textBoxAnnee;
        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.TextBox textBoxJaquette;
        private System.Windows.Forms.Label labelJaquette;
        private System.Windows.Forms.Button buttonJaquette;
    }
}