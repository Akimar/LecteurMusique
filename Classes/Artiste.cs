using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.Classes
{
    public class Artiste
    {
        #region Proprietés

        public long Identifiant;

        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private int note;

        public int Note
        {
            get { return note; }
            set { note = value; }
        }

        public string Image;

        #endregion

        #region Constructeurs
        public Artiste()
        {

        }
        #endregion
    }
}
