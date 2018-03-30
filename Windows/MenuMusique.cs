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
            this.dataGridView1.DataSource = MusiqueRepository.getMusiques();
            this.dataGridView1.Refresh();

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
            MusiqueWindow windowToOpen = new MusiqueWindow(null);
            windowToOpen.ShowDialog();
            if (windowToOpen.validate == true)
            {
               MusiqueRepository.addMusique(windowToOpen.musique);
                updateDataGrid();
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Musique musiqueToUpdate = null;

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Musique))
                    {
                        musiqueToUpdate = item.DataBoundItem as Musique;
                        
                    }

                }

                MusiqueWindow windowToOpen = new MusiqueWindow(musiqueToUpdate);
                windowToOpen.ShowDialog();

                if (windowToOpen.validate == true)
                {
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
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Musique musiqueToDelete = null;

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Musique))
                    {
                        musiqueToDelete = item.DataBoundItem as Musique;
                        
                    }
                }

                if (MessageBox.Show("Êtes-vous sur de vouloir supprimer cetter chanson ?", "Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MusiqueRepository.deleteMusique(musiqueToDelete);
                }
                updateDataGrid();
            }
            else
            {
                MessageBox.Show("Merci de sélectionner une chanson !");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Musique musiqueToPlay = null;

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Musique))
                    {
                        musiqueToPlay = item.DataBoundItem as Musique;

                    }
                }

                if (musiqueToPlay != null)
                {
                    LoadMusic(musiqueToPlay.CheminFichier);
                }
            }

        }
    }
}
