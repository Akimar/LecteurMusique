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
    public partial class MenuAlbum : Form
    {
        public MenuAlbum()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateDataGrid()
        {
            this.dataGridView1.DataSource = AlbumRepository.getAlbums();
            this.dataGridView1.Refresh();

            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {

                if (item.HeaderText == "ArtisteNom")
                {
                    item.HeaderText = "Artiste";
                }

                
                if (item.HeaderText == "NbMusiques")
                {
                    item.HeaderText = "Nombre de pistes";
                }
            }
        }

        private void MenuAlbum_Load(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void butttonAjouter_Click(object sender, EventArgs e)
        {
            AlbumWindow windowToOpen = new AlbumWindow(null);
            windowToOpen.ShowDialog();
            if (windowToOpen.validate == true)
            {
                AlbumRepository.addAlbum(windowToOpen.album);
                updateDataGrid();
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Album albumToUpdate = null;

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Album))
                    {
                        albumToUpdate = item.DataBoundItem as Album;
                       
                    }

                }

                AlbumWindow windowToOpen = new AlbumWindow(albumToUpdate);
                windowToOpen.ShowDialog();

                if (windowToOpen.validate == true)
                {
                    AlbumRepository.updateAlbum(windowToOpen.album);
                    updateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Merci de ne séléctionner qu'un et un seul album.");
            }
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Album albumToDelete = null;
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Album))
                    {
                        albumToDelete = item.DataBoundItem as Album;
                       
                    }
                }

                if (MessageBox.Show("Êtes-vous sur de vouloir supprimer cet album ?", "Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AlbumRepository.deleteAlbum(albumToDelete);
                }
                updateDataGrid();
            }
            else
            {
                MessageBox.Show("Merci de sélectionner un album !");
            }
        }
    }
}
