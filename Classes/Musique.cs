using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.Classes
{
    public class Musique
    {
        #region Propriétés

        public long Identitfiant;

        private string titre;

        public string Titre
        {
            get { return titre; }
            set { titre = value; }
        }

        private int duree;

        public int Duree
        {
            get { return duree; }
            set { duree = value; }
        }

        private string format;

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public string CheminFichier;

        public long Genre;
        public long Album;

        #endregion

    }
}
