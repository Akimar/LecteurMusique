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
    public partial class AlbumWindow : Form
    {
        #region Proprietés

        public Album album;

        //si true on ajoute sinon on modifie
        //public bool ajout = false;

        // si true c'est que l'utilisateur a appuyé su le bouton valider et pas annuler
        public bool validate = false;



        #endregion

        public AlbumWindow(Album _album)
        {
            InitializeComponent();


            if (_album != null)
            {
                //si != null on modifie
                album = _album;
            }

            else
            {
                //si == null on ajoute une nouvelle musique
                album = new Album();
            }

            this.textBoxNom.Text = album.Nom;
            //this.textBoxArtiste.Text = album.ArtisteNom;
            this.comboBoxArtiste.DisplayMember = "Nom";

            this.comboBoxArtiste.DataSource = ArtisteRepository.getArtistes();

            foreach (Artiste item in this.comboBoxArtiste.Items)
            {
                if (item.Identifiant == album.Artiste)
                {
                    this.comboBoxArtiste.SelectedItem = item;
                    break;
                }
            }

            if (album.NbMusiques != null)
            {
                this.textBoxNbMusiques.Text = album.NbMusiques.ToString();

            }

            if (album.Annee != null)
            {
                this.textBoxAnnee.Text = album.Annee.ToString();

            }

            this.textBoxNbMusiques.Text = album.NbMusiques.ToString();
            this.textBoxJaquette.Text = album.Jaquette;
          

            
            
        }

        private void buttonJaquette_Click(object sender, EventArgs e)
        {

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "jpg files (*.jpg)|*.jpg|jpeg files (*jpeg)|*.jpeg|png files (*.png)|*.png";
            openDialog.Multiselect = false;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxJaquette.Text = openDialog.FileName;
            }
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            bool verifOk = true;
            

            //champ nom
            if (this.textBoxNom.Text == "")
            {
                this.textBoxNom.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxNom.BackColor = Color.White;
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

            //champ nbmusiques
            if (this.textBoxNbMusiques.Text == "")
            {
                this.textBoxNbMusiques.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxNbMusiques.BackColor = Color.White;
            }

            //champ annee
            if (this.textBoxAnnee.Text == "")
            {
                this.textBoxAnnee.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxAnnee.BackColor = Color.White;
            }

            //champ jaquette
            if (this.textBoxJaquette.Text == "")
            {
                this.textBoxJaquette.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxJaquette.BackColor = Color.White;
            }


            //verifie si l artiste existe
            //if (ArtisteRepository.artisteExist(this.textBoxArtiste.Text) == false && textBoxArtiste.Text != "")
            //{
            //    verifOk = false;
            //    MessageBox.Show("\nL'artiste \"" + this.textBoxArtiste.Text + "\" n'existe pas. Il faut l'ajouter au préalable. Vous devez accéder aux aristes et l'ajouter.");
            //}

           
            if (verifOk)
            {

                // si tout est ok on va mettre les infos dans notre objet musique
                this.album.Nom = this.textBoxNom.Text;
                //this.album.ArtisteNom = this.textBoxArtiste.Text;
                this.album.Artiste = ((Artiste)this.comboBoxArtiste.SelectedItem).Identifiant;
                this.album.NbMusiques = Int32.Parse(this.textBoxNbMusiques.Text);
                this.album.Annee = Int32.Parse(this.textBoxAnnee.Text);
                this.album.Jaquette = this.textBoxJaquette.Text;
                //this.album.Artiste = ArtisteRepository.getIdFromNom(this.textBoxArtiste.Text);



                this.validate = true;
                this.Close();
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
