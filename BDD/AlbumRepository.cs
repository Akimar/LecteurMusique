using LecteurMusique.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.BDD
{
    public static class AlbumRepository
    {

        public static string getAlbumLibelle(long identifiantAlbum)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT Nom FROM Album WHERE Identifiant = @identifiantAlbum";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@identifiantAlbum", identifiantAlbum);

                return commande.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static long getIdFromNom(string nomAlbum)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT Identifiant FROM Album WHERE Nom = @nomAlbum";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@nomAlbum", nomAlbum);

                return long.Parse(commande.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public static List<Album> getAlbums()
        {
            List<Album> toReturn = new List<Album>();
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"SELECT * FROM Album";
            commande.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Album toAdd = new Album();

                toAdd.Identifiant = dataReader.GetInt64(0);
                toAdd.Nom = dataReader.GetString(1);
                toAdd.NbMusiques = dataReader.GetInt32(2);
                toAdd.Annee = dataReader.GetInt32(3);
                toAdd.Artiste = dataReader.GetInt64(4);
                toAdd.Jaquette = dataReader.GetString(5);


                toReturn.Add(toAdd);
            }
            return toReturn;
        }

        public static bool albumExist(string nomAlbum)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT * FROM Album WHERE Nom = @nomAlbum";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@nomAlbum", nomAlbum);

                SqlDataReader reader = commande.ExecuteReader();

                while (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        public static bool addAlbum(Album album)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"INSERT INTO Album VALUES(
                                     @Nom
                                    ,@NbMusiques
                                    ,@Annee
                                    ,@Artiste
                                    ,@Jaquette);";
            commande.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande.Prepare();

            //on mape les paramètres
            commande.Parameters.AddWithValue("@Nom", album.Nom);
            commande.Parameters.AddWithValue("@NbMusiques", album.NbMusiques);
            commande.Parameters.AddWithValue("@Annee", album.Annee);
            commande.Parameters.AddWithValue("@Artiste", album.Artiste);
            commande.Parameters.AddWithValue("@Jaquette", album.Jaquette);



            connection.Open();

            try
            {
                commande.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool updateAlbum(Album album)
        {

            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"UPDATE Album
                                    SET
                                    Nom = @Nom
                                    ,NbMusiques = @NbMusiques
                                    ,Annee = @Annee
                                    ,Artiste = @Artiste
                                    ,Jaquette = @Jaquette
                                    WHERE Identifiant = @Identifiant";
            commande.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande.Prepare();

            commande.Parameters.AddWithValue("@Nom", album.Nom);
            commande.Parameters.AddWithValue("@NbMusiques", album.NbMusiques);
            commande.Parameters.AddWithValue("@Annee", album.Annee);
            commande.Parameters.AddWithValue("@Artiste", album.Artiste);
            commande.Parameters.AddWithValue("@Jaquette", album.Jaquette);
            commande.Parameters.AddWithValue("@Identifiant", album.Identifiant);

            connection.Open();

            try
            {
                commande.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool deleteAlbum(Album album)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"DELETE FROM Album
                                     WHERE Identifiant = @Identifiant";
            commande.Connection = connection;

            //On spécifie que la requête est une commande "préparée"
            commande.Prepare();

            //On mappe les paramètres
            commande.Parameters.AddWithValue("@Identifiant", album.Identifiant);

            connection.Open();

            try
            {
                commande.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
