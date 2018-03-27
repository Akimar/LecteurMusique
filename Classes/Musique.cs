using LecteurMusique.BDD;
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

        public long Identifiant;

        private string titre;

        public string Titre
        {
            get { return titre; }
            set { titre = value; }
        }

        private string artisteNom = null;
        public string ArtisteNom
        {
            get
            {
                if (artisteNom == null)
                {
                    artisteNom = ArtisteRepository.getArtisteNomFromMusique(Identifiant);
                }
                return artisteNom;
            }
        }

        private string albumLibelle = null;
        public string AlbumLibelle
        {
            get
            {
                if (albumLibelle == null)
                {
                    albumLibelle = AlbumRepository.getAlbumLibelle(Album);
                }
                return albumLibelle;
            }
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

        private int note;

        public int Note
        {
            get { return note; }
            set { note = value; }
        }


        public string CheminFichier;

        public long Genre;
        public long Album;

       

        private string genreLibelle = null;
        public string GenreLibelle
        {
            get
            {
                if (genreLibelle == null)
                {
                    genreLibelle = GenreRepository.getGenreLibelle(Genre);
                }
                return genreLibelle;
            }
        }

        

        #endregion

    }
}
