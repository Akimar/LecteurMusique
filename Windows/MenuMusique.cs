using LecteurMusique.BDD;
using LecteurMusique.Classes;
using LecteurMusique.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LecteurMusique
{
    public partial class MenuMusique : Form
    {
        public MenuMusique()
        {
            InitializeComponent();
        }

        public void LoadMusic(string filename)
        {
            try
            {
                if (this.axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsStopped)
                {
                    this.axWindowsMediaPlayer1.Ctlcontrols.stop();
                }
            }
            catch (Exception) { }
            this.axWindowsMediaPlayer1.URL = filename;
            this.axWindowsMediaPlayer1.Refresh();
            this.axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void updateDataGrid()
        {
            //récupère la liste des musiques et la met dans un datagridview
            this.dataGridView1.DataSource = MusiqueRepository.getMusiques();
            this.dataGridView1.Refresh();

            //modifie les noms des colonnes du dgv
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                if (item.HeaderText == "AlbumLibelle")
                {
                    item.HeaderText = "Album";
                }

                if (item.HeaderText == "GenreLibelle")
                {
                    item.HeaderText = "Genre";
                }

                if (item.HeaderText == "ArtisteNom")
                {
                    item.HeaderText = "Artiste";
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuMusique_Load(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            //ouvre la fenêtre d'ajout d'une musique
            MusiqueWindow windowToOpen = new MusiqueWindow(null);
            windowToOpen.ShowDialog();
            if (windowToOpen.validate == true)
            {
                //ajoute la musique  en base
               MusiqueRepository.addMusique(windowToOpen.musique);
                updateDataGrid();
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            //vérifie qu'une seule ligne a été sélectionnée
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Musique musiqueToUpdate = null;

                //pour le chaque ligne du data gridview selectionnée, on vérifie que l'objet contenu soit de type musique
                //(il n'y a ici qu'une seule ligne)
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Musique))
                    {
                        //on affecte l'item du datagridview en le castant en objet Musique
                        musiqueToUpdate = item.DataBoundItem as Musique;
                        //ajoute l'id de l'artiste dans l'instance de l'objet musique
                        musiqueToUpdate.Artiste = MusiqueRepository.getArtisteFromMusiqueId(musiqueToUpdate.Identifiant);
                        
                    }

                }

                MusiqueWindow windowToOpen = new MusiqueWindow(musiqueToUpdate);
                windowToOpen.ShowDialog();

                if (windowToOpen.validate == true)
                {
                    //met à jour la musique en base
                    MusiqueRepository.updateMusique(windowToOpen.musique);
                    updateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Merci de ne séléctionner qu'une et une seule musique.");
            }
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            //vérifie si une et une seule ligne est séléctionnée dans le data gridview
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Musique musiqueToDelete = null;

                //pour le chaque ligne du data gridview selectionnée, on vérifie que l'objet contenu soit de type musique
                //(il n'y a ici qu'une seule ligne)
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Musique))
                    {
                        //on affecte l'item du datagridview en le castant en objet Musique
                        musiqueToDelete = item.DataBoundItem as Musique;
                        
                    }
                }

                if (MessageBox.Show("Êtes-vous sur de vouloir supprimer cetter chanson ?", "Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //suppression de la musique
                    MusiqueRepository.deleteMusique(musiqueToDelete);
                }
                updateDataGrid();
            }
            else
            {
                MessageBox.Show("Merci de sélectionner une chanson !");
            }
        }

       

        private void buttonLire_Click(object sender, EventArgs e)
        {
            //vérifie qu'une seule ligne a été sélectionnée
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Musique musiqueToPlay = null;

                //pour le chaque ligne du data gridview selectionnée, on vérifie que l'objet contenu soit de type musique
                //(il n'y a ici qu'une seule ligne)
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Musique))
                    {
                        //on affecte l'item du datagridview en le castant en objet Musique
                        musiqueToPlay = item.DataBoundItem as Musique;

                    }
                }

                if (musiqueToPlay != null)
                {
                    //lit la musique
                    LoadMusic(musiqueToPlay.CheminFichier);
                }
            }
        }
    }
}
