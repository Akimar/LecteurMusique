using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.Classes
{
    public class Genre
    {
        #region Proprietés

        public long Identifiant;

        private string libelle;

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }
        #region Constructeurs

        public Genre()
        {

        }

        #endregion

        #endregion


    }
}
