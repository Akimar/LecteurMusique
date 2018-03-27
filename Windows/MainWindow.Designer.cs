namespace LecteurMusique
{
    partial class MainWindow
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMusique = new System.Windows.Forms.Button();
            this.buttonPlaylist = new System.Windows.Forms.Button();
            this.buttonArtiste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(495, 535);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Fermer";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMusique
            // 
            this.buttonMusique.Location = new System.Drawing.Point(206, 108);
            this.buttonMusique.Name = "buttonMusique";
            this.buttonMusique.Size = new System.Drawing.Size(149, 23);
            this.buttonMusique.TabIndex = 4;
            this.buttonMusique.Text = "Accéder aux musiques";
            this.buttonMusique.UseVisualStyleBackColor = true;
            this.buttonMusique.Click += new System.EventHandler(this.buttonMusique_Click);
            // 
            // buttonPlaylist
            // 
            this.buttonPlaylist.Location = new System.Drawing.Point(206, 373);
            this.buttonPlaylist.Name = "buttonPlaylist";
            this.buttonPlaylist.Size = new System.Drawing.Size(149, 23);
            this.buttonPlaylist.TabIndex = 5;
            this.buttonPlaylist.Text = "Afficher les playlists";
            this.buttonPlaylist.UseVisualStyleBackColor = true;
            // 
            // buttonArtiste
            // 
            this.buttonArtiste.Location = new System.Drawing.Point(206, 241);
            this.buttonArtiste.Name = "buttonArtiste";
            this.buttonArtiste.Size = new System.Drawing.Size(149, 23);
            this.buttonArtiste.TabIndex = 6;
            this.buttonArtiste.Text = "Accéder aux artistes";
            this.buttonArtiste.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 570);
            this.Controls.Add(this.buttonArtiste);
            this.Controls.Add(this.buttonPlaylist);
            this.Controls.Add(this.buttonMusique);
            this.Controls.Add(this.buttonClose);
            this.Name = "MainWindow";
            this.Text = "Lecteur de musique";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMusique;
        private System.Windows.Forms.Button buttonPlaylist;
        private System.Windows.Forms.Button buttonArtiste;
    }
}

