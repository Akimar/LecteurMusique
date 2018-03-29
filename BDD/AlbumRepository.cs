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

        public static string getIdFromNom(string nomAlbum)
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

                return commande.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return "";
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
                commande.CommandText = @"SELECT * FROM Artiste WHERE Nom = @nomAlbum";
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
    }
}
