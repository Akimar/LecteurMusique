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

       private void loadImages()
        {
            //vérifie qu'une seule ligne a été sélectionnée
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Album albumImageToLoad = null;

                //pour le chaque ligne du data gridview selectionnée, on vérifie que l'objet contenu soit de type album
                //(il n'y a ici qu'une seule ligne)
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    //on affecte l'item du datagridview en le castant en objet album
                    if (item.DataBoundItem.GetType() == typeof(Album))
                    {
                        albumImageToLoad = item.DataBoundItem as Album;

                        //on charge l'image à afficher
                        pictureBox1.Image = Bitmap.FromFile(albumImageToLoad.Jaquette);
                        pictureBox1.Update();

                    }

                }

                
            }
           
      }

        private void updateDataGrid()
        {
            //récupère la liste des albums et la met dans un datagridview
            this.dataGridView1.DataSource = AlbumRepository.getAlbums();
            this.dataGridView1.Refresh();

            //modifie les noms des colonnes du dgv
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
            //déléctione la premire ligne du dgv
            dataGridView1.Rows[0].Selected = true;
            loadImages();
        }

        private void butttonAjouter_Click(object sender, EventArgs e)
        {
            //ouvre la fenêtre d'ajout d'un album
            AlbumWindow windowToOpen = new AlbumWindow(null);
            windowToOpen.ShowDialog();
            if (windowToOpen.validate == true)
            {
                //ajoute l'album  en base
                AlbumRepository.addAlbum(windowToOpen.album);
                updateDataGrid();
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            //vérifie qu'une seule ligne a été sélectionnée
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Album albumToUpdate = null;

                //pour le chaque ligne du data gridview selectionnée, on vérifie que l'objet contenu soit de type album
                //(il n'y a ici qu'une seule ligne)
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Album))
                    {
                        //on affecte l'item du datagridview en le castant en objet album
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
            //vérifie qu'une seule ligne a été sélectionnée
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                Album albumToDelete = null;

                //pour le chaque ligne du data gridview selectionnée, on vérifie que l'objet contenu soit de type album
                //(il n'y a ici qu'une seule ligne)
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows.OfType<DataGridViewRow>())
                {
                    if (item.DataBoundItem.GetType() == typeof(Album))
                    {
                        //on affecte l'item du datagridview en le castant en objet album
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

        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
           
            if (dgv.CurrentRow.Selected)
            {
                loadImages();
               
            }
        }
    }
}
