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

        //si true on ajoute sinon on modifie
        //public bool ajout = false;

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

            this.textBoxNom.Text = artiste.Nom;
            this.textBoxImage.Text = artiste.Image;
        }

        private void butttonImage_Click(object sender, EventArgs e)
        {
             OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "jpg files (*.jpg)|*.jpg|jpeg files (*jpeg)|*.jpeg|png files (*.png)|*.png";
            openDialog.Multiselect = false;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxImage.Text = openDialog.FileName;
            }
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            bool verifOk = true;


            if (this.textBoxNom.Text == "")
            {
                this.textBoxNom.BackColor = Color.Red;
                verifOk = false;
            }
            else
            {
                this.textBoxNom.BackColor = Color.White;
            }

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

                // si tout est ok on va mettre les infos dans notre objet musique
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
