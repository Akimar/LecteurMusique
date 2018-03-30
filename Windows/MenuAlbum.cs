using LecteurMusique.BDD;
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
                MusiqueRepository.addAlbum(windowToOpen.album);
                updateDataGrid();
            }
        }
    }
}
