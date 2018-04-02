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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void updateDataGrid()
        {
            this.dataGridView1.DataSource = ArtisteRepository.getArtistes();
            this.dataGridView1.Refresh();

         
        }
        private void loadImages()
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Artiste artisteImageToLoad = null;

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Artiste))
                    {
                        artisteImageToLoad = item.DataBoundItem as Artiste;

                        pictureBox1.Image = Bitmap.FromFile(artisteImageToLoad.Image);
                        pictureBox1.Update();

                    }

                }


            }
            else
            {
                MessageBox.Show("Merci de ne séléctionner qu'un et un seul album.");
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMusique_Click(object sender, EventArgs e)
        {
            MenuMusique windowToOpen = new MenuMusique();
            windowToOpen.ShowDialog();
        }

        private void buttonAlbum_Click(object sender, EventArgs e)
        {
            MenuAlbum windowToopen = new MenuAlbum();
            windowToopen.ShowDialog();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            ArtisteWindow windowToOpen = new ArtisteWindow(null);
            windowToOpen.ShowDialog();
            if (windowToOpen.validate == true)
            {
                ArtisteWindow.addArtiste(windowToOpen.artiste);
                updateDataGrid();
            }
        }

        private void butttonModifier_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Artiste artisteToUpdate = null;

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Artiste))
                    {
                        artisteToUpdate = item.DataBoundItem as Artiste;

                    }

                }

                ArtisteWindow windowToOpen = new ArtisteWindow(artisteToUpdate);
                windowToOpen.ShowDialog();

                if (windowToOpen.validate == true)
                {
                    ArtisteWindow.updateArtiste(windowToOpen.artiste);
                    updateDataGrid();

                }
            }
            else
            {
                MessageBox.Show("Merci de ne séléctionner qu'un et un seul album.");
            }
        }
    }
}
