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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMusique_Click(object sender, EventArgs e)
        {
            MenuMusique windowToOpen = new MenuMusique();
            windowToOpen.ShowDialog();
        }
    }
}
