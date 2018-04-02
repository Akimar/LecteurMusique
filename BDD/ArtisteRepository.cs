using LecteurMusique.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.BDD
{
    public static class ArtisteRepository
    {
        public static string getArtisteNomFromMusique(long identifiantMusique)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT Artiste.Nom FROM Compose INNER JOIN Artiste ON Compose.IdentifiantArtiste = Artiste.Identifiant WHERE IdentifiantMusique = @identifiantMusique";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@identifiantMusique", identifiantMusique);

                return commande.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool artisteExist(string nomArtiste)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT * FROM Artiste WHERE Nom = @nomArtiste";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@nomArtiste", nomArtiste);

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

        public static List<Artiste> getArtistes()
        {
            List<Artiste> toReturn = new List<Artiste>();
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"SELECT Identifiant
                                        ,Nom
                                        ,Image
                                         FROM Artiste";
            commande.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Artiste toAdd = new Artiste();

                toAdd.Identifiant = dataReader.GetInt64(0);
                toAdd.Nom = dataReader.GetString(1);
                toAdd.Image = dataReader.GetString(2);


                toReturn.Add(toAdd);
            }


            return toReturn;
        }

        public static long getIdFromNom(string nomArtiste)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT Identifiant FROM Artiste WHERE Nom = @nomArtiste";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@nomArtiste", nomArtiste);

                return long.Parse(commande.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string getArtisteNom(long identifiantArtiste)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT Nom FROM Artiste WHERE Identifiant = @identifiantArtiste";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@identifiantArtiste", identifiantArtiste);

                return commande.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool addArtiste(Artiste artiste)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"INSERT INTO Artiste VALUES(
                                     @Nom
                                    ,@Image);";
            commande.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande.Prepare();

            //on mape les paramètres
            commande.Parameters.AddWithValue("@Nom", artiste.Nom);
            commande.Parameters.AddWithValue("@Image", artiste.Image);
           



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

        public static bool updateArtiste(Artiste artiste)
        {

            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"UPDATE Artiste
                                    SET
                                    Nom = @Nom
                                    ,Image = @Image
                                    WHERE Identifiant = @Identifiant";
            commande.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande.Prepare();

            commande.Parameters.AddWithValue("@Nom", artiste.Nom);
            commande.Parameters.AddWithValue("@Image", artiste.Image);
            commande.Parameters.AddWithValue("@Identifiant", artiste.Identifiant);
           
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
    }
}
