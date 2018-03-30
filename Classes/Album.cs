using LecteurMusique.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.Classes
{
    public class Album
    {
        #region Proprietés

        public long Identifiant;

        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private string artisteNom = null;
        public string ArtisteNom
        {
            get
            {
                if (artisteNom == null)
                {
                    artisteNom = ArtisteRepository.getArtisteNom(Artiste);
                }
                return artisteNom;
            }

            set { artisteNom = value; }
        }


        private int? nbMusiques;

        public int? NbMusiques
        {
            get { return nbMusiques; }
            set { nbMusiques = value; }
        }


        private int? annee;

        public int? Annee
        {
            get { return annee; }
            set { annee = value; }
        }

        public string Jaquette;

        public long Artiste;


        #endregion
    }
}
