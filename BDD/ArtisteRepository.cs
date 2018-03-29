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

        public static bool Exist(string artistName)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT * FROM Artiste WHERE Nom = @artistName";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@artistName", artistName);

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
