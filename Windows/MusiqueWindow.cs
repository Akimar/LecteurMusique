using LecteurMusique.BDD;
using LecteurMusique.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LecteurMusique.Windows
{
    public partial class MusiqueWindow : Form
    {
        #region Proprietés

        public Musique musique;

        //si true on ajoute sinon on modifie
        public bool ajout = false;

        // si true c'est que l'utilisateur a appuyé su le bouton valider et pas annuler
        public bool validate = false;



        #endregion


        public MusiqueWindow(Musique _musique)
        {
            InitializeComponent();

            this.comboBoxGenre.DataSource = GenreRepository.getGenres();
           //// this.comboBoxArtiste.DataSource = ArtisteRepository.getArtistes();
            this.comboBoxAlbum.DataSource = AlbumRepository.getAlbums();

            // va chercher la propriete get Libelle
            this.comboBoxGenre.DisplayMember = "Libelle";
           // this.comboBoxAlbum.DisplayMember = "Nom";
            //this.comboBoxArtiste.DisplayMember = "Nom";

            if (_musique != null)
            {
                //si != null on modifie
                musique = _musique;
            }

            else
            {
                //si == null on ajoute une nouvelle musique
                musique = new Musique();
            }

            this.textBoxTitre.Text = musique.Titre;
            this.textBoxArtiste.Text = musique.ArtisteNom;
            this.textBoxAlbum.Text = musique.AlbumLibelle;
            if (musique.Duree != null)
            {
                this.textBoxDuree.Text = musique.Duree.ToString();
            }
           
            this.textBoxFormat.Text = musique.Format;
            if (musique.Note != null)
            {
                this.textBoxNote.Text = musique.Note.ToString();
            }

            foreach (Genre item in this.comboBoxGenre.Items)
            {
                if (item.Identifiant == musique.Genre)
                {
                    this.comboBoxGenre.SelectedItem = item;
                    break;
                }
            }

        }

        private void buttonValider_CLick(object sender, EventArgs e)
        {
            bool verifOk = true;

           
            //champ titre
            if (this.textBoxTitre.Text == "")
            {
                this.textBoxTitre.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxTitre.BackColor = Color.White;
            }

            //champ artiste
            if (this.textBoxArtiste.Text == "")
            {
                this.textBoxArtiste.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxArtiste.BackColor = Color.White;
            }

            //champ album
            if (this.textBoxAlbum.Text == "")
            {
                this.textBoxAlbum.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxAlbum.BackColor = Color.White;
            }

            //champ duree
            if (this.textBoxDuree.Text == "")
            {
                this.textBoxDuree.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxDuree.BackColor = Color.White;
            }

            //champ format
            if (this.textBoxFormat.Text == "")
            {
                this.textBoxFormat.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxFormat.BackColor = Color.White;
            }

            //champ note
            if (this.textBoxNote.Text == "")
            {
                this.textBoxNote.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxNote.BackColor = Color.White;
            }

            //champ genre
            if (this.comboBoxGenre.SelectedItem == null)
            {
                this.comboBoxGenre.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.comboBoxGenre.BackColor = Color.White;
            }



            if (verifOk)
            {

                // si tout est ok on va mettre les infos dans notre objet musique
                this.musique.Titre = this.textBoxTitre.Text;
                //this.musique.ArtisteNom = this.textBoxArtiste.Text;
               // this.musique.AlbumLibelle = this.textBoxAlbum.Text;
                this.musique.Format = this.textBoxFormat.Text;
                this.musique.Note = Int32.Parse(this.textBoxNote.Text);
                this.musique.Genre = ((Genre)this.comboBoxGenre.SelectedItem).Identifiant;



                this.validate = true;
                this.Close();
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChemin_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter =  "mp3 files (*.mp3)|*.mp3";
            openDialog.Multiselect = false;

           if(openDialog.ShowDialog() == DialogResult.OK)
            {
                labelFileDialog.Text = openDialog.FileName;
            }

        }
    }
}
