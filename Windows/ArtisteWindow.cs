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
    public partial class ArtisteWindow : Form
    {
        public Artiste artiste;


        // si true c'est que l'utilisateur a appuyé su le bouton valider et pas annuler
        public bool validate = false;


        public ArtisteWindow(Artiste _artiste)
        {
            InitializeComponent();

            if (_artiste != null)
            {
                //si != null on modifie
                artiste = _artiste;
            }

            else
            {
                //si == null on ajoute une nouvelle musique
                artiste = new Artiste();
            }

            //remplit les textbox de la fenêtre
            this.textBoxNom.Text = artiste.Nom;
            this.textBoxImage.Text = artiste.Image;
        }

        private void butttonImage_Click(object sender, EventArgs e)
        {
            //ouvre une boite de dialogue pour récuperer l'image du groupe
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "jpg files (*.jpg)|*.jpg|jpeg files (*jpeg)|*.jpeg|png files (*.png)|*.png";
            openDialog.Multiselect = false;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxImage.Text = openDialog.FileName;
            }
        }

        //vérifie si tous les champs sont bien remplis
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

            //champ image
            if (this.textBoxImage.Text == "")
            {
                this.textBoxImage.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxImage.BackColor = Color.White;
            }


            if (verifOk)
            {

                // si tout est ok on va mettre les infos dans notre objet artiste
                this.artiste.Nom = this.textBoxNom.Text;
                this.artiste.Image = this.textBoxImage.Text;
               


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
