namespace LecteurMusique.Windows
{
    partial class MusiqueWindow
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
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.buttonValider = new System.Windows.Forms.Button();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.textBoxFormat = new System.Windows.Forms.TextBox();
            this.textBoxAlbum = new System.Windows.Forms.TextBox();
            this.textBoxArtiste = new System.Windows.Forms.TextBox();
            this.textBoxTitre = new System.Windows.Forms.TextBox();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.labeFormat = new System.Windows.Forms.Label();
            this.labelAlbum = new System.Windows.Forms.Label();
            this.labelArtiste = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.labelDuree = new System.Windows.Forms.Label();
            this.textBoxDuree = new System.Windows.Forms.TextBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.labelChemin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(293, 335);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 31;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // buttonValider
            // 
            this.buttonValider.Location = new System.Drawing.Point(101, 335);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(75, 23);
            this.buttonValider.TabIndex = 30;
            this.buttonValider.Text = "Valider";
            this.buttonValider.UseVisualStyleBackColor = true;
            this.buttonValider.Click += new System.EventHandler(this.buttonValider_CLick);
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(170, 204);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(144, 20);
            this.textBoxNote.TabIndex = 27;
            // 
            // textBoxFormat
            // 
            this.textBoxFormat.Location = new System.Drawing.Point(170, 169);
            this.textBoxFormat.Name = "textBoxFormat";
            this.textBoxFormat.Size = new System.Drawing.Size(144, 20);
            this.textBoxFormat.TabIndex = 26;
            // 
            // textBoxAlbum
            // 
            this.textBoxAlbum.Location = new System.Drawing.Point(170, 104);
            this.textBoxAlbum.Name = "textBoxAlbum";
            this.textBoxAlbum.Size = new System.Drawing.Size(144, 20);
            this.textBoxAlbum.TabIndex = 25;
            // 
            // textBoxArtiste
            // 
            this.textBoxArtiste.Location = new System.Drawing.Point(170, 73);
            this.textBoxArtiste.Name = "textBoxArtiste";
            this.textBoxArtiste.Size = new System.Drawing.Size(144, 20);
            this.textBoxArtiste.TabIndex = 24;
            // 
            // textBoxTitre
            // 
            this.textBoxTitre.Location = new System.Drawing.Point(170, 37);
            this.textBoxTitre.Name = "textBoxTitre";
            this.textBoxTitre.Size = new System.Drawing.Size(144, 20);
            this.textBoxTitre.TabIndex = 23;
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(65, 239);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(36, 13);
            this.labelGenre.TabIndex = 21;
            this.labelGenre.Text = "Genre";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(65, 204);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(30, 13);
            this.labelNote.TabIndex = 20;
            this.labelNote.Text = "Note";
            // 
            // labeFormat
            // 
            this.labeFormat.AutoSize = true;
            this.labeFormat.Location = new System.Drawing.Point(62, 169);
            this.labeFormat.Name = "labeFormat";
            this.labeFormat.Size = new System.Drawing.Size(39, 13);
            this.labeFormat.TabIndex = 19;
            this.labeFormat.Text = "Format";
            // 
            // labelAlbum
            // 
            this.labelAlbum.AutoSize = true;
            this.labelAlbum.Location = new System.Drawing.Point(65, 104);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.Size = new System.Drawing.Size(36, 13);
            this.labelAlbum.TabIndex = 18;
            this.labelAlbum.Text = "Album";
            // 
            // labelArtiste
            // 
            this.labelArtiste.AutoSize = true;
            this.labelArtiste.Location = new System.Drawing.Point(65, 73);
            this.labelArtiste.Name = "labelArtiste";
            this.labelArtiste.Size = new System.Drawing.Size(36, 13);
            this.labelArtiste.TabIndex = 17;
            this.labelArtiste.Text = "Artiste";
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(65, 40);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(28, 13);
            this.labelTitre.TabIndex = 16;
            this.labelTitre.Text = "Titre";
            // 
            // labelDuree
            // 
            this.labelDuree.AutoSize = true;
            this.labelDuree.Location = new System.Drawing.Point(65, 137);
            this.labelDuree.Name = "labelDuree";
            this.labelDuree.Size = new System.Drawing.Size(36, 13);
            this.labelDuree.TabIndex = 33;
            this.labelDuree.Text = "Durée";
            // 
            // textBoxDuree
            // 
            this.textBoxDuree.Location = new System.Drawing.Point(170, 137);
            this.textBoxDuree.Name = "textBoxDuree";
            this.textBoxDuree.Size = new System.Drawing.Size(144, 20);
            this.textBoxDuree.TabIndex = 34;
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(170, 239);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(144, 21);
            this.comboBoxGenre.TabIndex = 35;
            // 
            // labelChemin
            // 
            this.labelChemin.AutoSize = true;
            this.labelChemin.Location = new System.Drawing.Point(66, 278);
            this.labelChemin.Name = "labelChemin";
            this.labelChemin.Size = new System.Drawing.Size(42, 13);
            this.labelChemin.TabIndex = 36;
            this.labelChemin.Text = "Chemin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonChemin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "label1";
            // 
            // MusiqueWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 403);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelChemin);
            this.Controls.Add(this.comboBoxGenre);
            this.Controls.Add(this.textBoxDuree);
            this.Controls.Add(this.labelDuree);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.textBoxFormat);
            this.Controls.Add(this.textBoxAlbum);
            this.Controls.Add(this.textBoxArtiste);
            this.Controls.Add(this.textBoxTitre);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.labeFormat);
            this.Controls.Add(this.labelAlbum);
            this.Controls.Add(this.labelArtiste);
            this.Controls.Add(this.labelTitre);
            this.Name = "MusiqueWindow";
            this.Text = "Musique";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.TextBox textBoxFormat;
        private System.Windows.Forms.TextBox textBoxAlbum;
        private System.Windows.Forms.TextBox textBoxArtiste;
        private System.Windows.Forms.TextBox textBoxTitre;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Label labeFormat;
        private System.Windows.Forms.Label labelAlbum;
        private System.Windows.Forms.Label labelArtiste;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Label labelDuree;
        private System.Windows.Forms.TextBox textBoxDuree;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Label labelChemin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}