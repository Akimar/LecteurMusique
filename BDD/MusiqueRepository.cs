using LecteurMusique.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurMusique.BDD
{
    public static class MusiqueRepository
    {

        public static List<Musique> getMusiques()
        {
            List<Musique> toReturn = new List<Musique>();
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"SELECT * FROM Musique";
            commande.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Musique toAdd = new Musique();

                toAdd.Identifiant = dataReader.GetInt64(0);
                toAdd.Titre = dataReader.GetString(1);
                toAdd.Duree = dataReader.GetInt32(2);
                toAdd.Format = dataReader.GetString(3);
                toAdd.Genre = dataReader.GetInt64(4);
                toAdd.Album = dataReader.GetInt64(5);
                toAdd.CheminFichier = dataReader.GetString(6);
                toAdd.Note = dataReader.GetInt32(7);

                toReturn.Add(toAdd);
            }


            return toReturn;
        }


        //public static bool AddPersonne(Musique musique)
        //{
        //    SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

        //    SqlCommand commande = new SqlCommand();
        //    commande.CommandText = @"INSERT INTO Musique VALUES(
        //                             @Titre
        //                            ,@Duree
        //                            ,@Format
        //                            ,@Genre
        //                            ,@Album
        //                            ,@CheminFichier
        //                            ,@Pays)
        //                           ";
        //    commande.Connection = connection;

        //    //on spécifie que la requête est une commande préparée
        //    commande.Prepare();

        //    //on mape les paramètres
        //    commande.Parameters.AddWithValue("@Prenom", personne.Prenom);
        //    commande.Parameters.AddWithValue("@Nom", personne.Nom);
        //    commande.Parameters.AddWithValue("@Adresse", personne.Adresse);
        //    commande.Parameters.AddWithValue("@CodePostal", personne.Codepostal);
        //    commande.Parameters.AddWithValue("@Ville", personne.Ville);
        //    commande.Parameters.AddWithValue("@DateDeNaissance", personne.DateDeNaissance);
        //    commande.Parameters.AddWithValue("@Pays", personne.Pays);
        //    //commande.Parameters.AddWithValue("@Identifiant", personne.Identifiant);

        //    connection.Open();

        //    try
        //    {
        //        commande.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

    }
}
