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
                                         FROM Artiste";
            commande.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Artiste toAdd = new Artiste();

                toAdd.Identifiant = dataReader.GetInt64(0);
                toAdd.Nom = dataReader.GetString(1);


                toReturn.Add(toAdd);
            }


            return toReturn;
        }

    }
}
