using LecteurMusique.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.BDD
{
    public static class GenreRepository
    {

        //get le libelle du genre à partir de son id
        public static string getGenreLibelle(long identifiantGenre)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();
                commande.CommandText = @"SELECT Libelle FROM Genre WHERE Identifiant = @identifiantGenre";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@identifiantGenre", identifiantGenre);

                return commande.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        //get tous les genres en base
        public static List<Genre> getGenres()
        {
            List<Genre> toReturn = new List<Genre>();
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"SELECT Identifiant
                                        ,Libelle
                                         FROM Genre";
            commande.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Genre toAdd = new Genre();

                toAdd.Identifiant = dataReader.GetInt64(0);
                toAdd.Libelle = dataReader.GetString(1);


                toReturn.Add(toAdd);
            }


            return toReturn;
        }
    }
}
