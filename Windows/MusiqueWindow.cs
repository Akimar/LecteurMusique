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
        //public bool ajout = false;

        // si true c'est que l'utilisateur a appuyé su le bouton valider et pas annuler
        public bool validate = false;



        #endregion


        public MusiqueWindow(Musique _musique)
        {
            InitializeComponent();

            //datetimepicker
            //dateTimePickerDuree = new DateTimePicker();
            //dateTimePickerDuree.CustomFormat = "mm:ss";
                       

            // va chercher la propriete get Libelle
            this.comboBoxGenre.DisplayMember = "Libelle";
            this.comboBoxAlbum.DisplayMember = "Nom";
            this.comboBoxArtiste.DisplayMember = "Nom";

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



            this.comboBoxGenre.DataSource = GenreRepository.getGenres();
            this.comboBoxArtiste.DataSource = ArtisteRepository.getArtistes();
            this.comboBoxAlbum.DataSource = AlbumRepository.getAlbums();

            this.textBoxTitre.Text = musique.Titre;
            //this.comboBoxArtiste.Text = musique.ArtisteNom;
            //this.textBoxAlbum.Text = musique.AlbumLibelle;
            this.textBoxChemin.Text = musique.CheminFichier;
            this.textBoxDuree.Text = musique.Duree;

            //if (musique.Duree != null)
            //{
            //    this.textBoxDuree.Text = musique.Duree.ToString();
            //}

            //this.textBoxFormat.Text = musique.Format;

            if (musique.Note != null)
            {
                this.textBoxNote.Text = musique.Note.ToString();
            }

            foreach (Artiste item in this.comboBoxArtiste.Items)
            {
                if (item.Identifiant == musique.Artiste)
                {
                    this.comboBoxArtiste.SelectedItem = item;
                    break;
                }
            }

            foreach (Album item in this.comboBoxAlbum.Items)
            {
                if (item.Identifiant == musique.Album)
                {
                    this.comboBoxAlbum.SelectedItem = item;
                    break;
                }
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
            string messageErreur = "";

           
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
            //if (this.textBoxArtiste.Text == "")
            //{
            //    this.textBoxArtiste.BackColor = Color.Red;
            //    verifOk = false;
            //}
            //else
            //{
            //    this.textBoxArtiste.BackColor = Color.White;
            //}

            ////champ album
            //if (this.textBoxAlbum.Text == "")
            //{
            //    this.textBoxAlbum.BackColor = Color.Red;
            //    verifOk = false;
            //}
            //else
            //{
            //    this.textBoxAlbum.BackColor = Color.White;
            //}

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
            //if (this.textBoxFormat.Text == "")
            //{
            //    this.textBoxFormat.BackColor = Color.Red;
            //    verifOk = false;
            //}
            //else
            //{
            //    this.textBoxFormat.BackColor = Color.White;
            //}

            //champ note
            if (this.textBoxNote.Text == "")
            {
                this.textBoxNote.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                if (Int32.Parse(this.textBoxNote.Text) > 5 || Int32.Parse(this.textBoxNote.Text) < 0)
                {
                    MessageBox.Show("La note doit être comprise entre 0 et 5.");
                }
                this.textBoxNote.BackColor = Color.White;
            }

            

            //combobox artiste
            if (this.comboBoxArtiste.SelectedItem == null)
            {
                this.comboBoxArtiste.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.comboBoxArtiste.BackColor = Color.White;
            }

            //combobox album
            if (this.comboBoxAlbum.SelectedItem == null)
            {
                this.comboBoxAlbum.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.comboBoxAlbum.BackColor = Color.White;
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

            //champ chemin
            if (this.textBoxChemin.Text == "")
            {
                this.textBoxChemin.BackColor = Color.Red;
             
                verifOk = false;
            }
            else
            {
                this.textBoxChemin.BackColor = Color.White;
            }

            //verifie si l artiste existe
            //if(ArtisteRepository.artisteExist(this.textBoxArtiste.Text) == false && textBoxArtiste.Text != "")
            //{
            //    verifOk = false;
            //    messageErreur += "\nL'artiste \""+ this.textBoxArtiste.Text+ "\" n'existe pas. Il faut l'ajouter au préalable. Vous devez accéder aux aristes et l'ajouter.";
            //}

            //verifie si l album existe dans le groupe
            if (AlbumRepository.albumArtisteExist(this.comboBoxAlbum.Text, ((Artiste)this.comboBoxArtiste.SelectedItem).Identifiant) == false)
            {
                verifOk = false;
                messageErreur += "\nL'album \"" + this.comboBoxAlbum.Text + "\" n'existe pas pour le groupe choisi. ";
            }

            if (messageErreur != "")
            {
                MessageBox.Show(messageErreur);
            }

            if (verifOk)
            {

                // si tout est ok on va mettre les infos dans notre objet musique
                this.musique.Titre = this.textBoxTitre.Text;
                this.musique.Artiste = ((Artiste)this.comboBoxArtiste.SelectedItem).Identifiant;
                //this.musique.AlbumLibelle = this.textBoxAlbum.Text;
                this.musique.Album = ((Album)this.comboBoxAlbum.SelectedItem).Identifiant;
                //this.musique.Duree = Int32.Parse(this.textBoxDuree.Text);
                this.musique.Duree = this.textBoxDuree.Text;
                //this.musique.Format = this.textBoxFormat.Text;
                this.musique.Note = Int32.Parse(this.textBoxNote.Text);
                this.musique.Genre = ((Genre)this.comboBoxGenre.SelectedItem).Identifiant;
                this.musique.CheminFichier = this.textBoxChemin.Text;
                //this.musique.Album = AlbumRepository.getIdFromNom(this.comboBoxAlbum.Text);
                //this.musique.Artiste = ArtisteRepository.getIdFromNom(this.comboBoxArtiste.Text);

                //this.comboBoxGenre.DataSource = GenreRepository.getGenres();
                //this.comboBoxArtiste.DataSource = ArtisteRepository.getArtistes();
                //this.comboBoxAlbum.DataSource = AlbumRepository.getAlbumsFromArtisteId(this.musique.Artiste = ((Artiste)this.comboBoxArtiste.SelectedItem).Identifiant);


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
                textBoxChemin.Text = openDialog.FileName;
            }

        }
    }
}
