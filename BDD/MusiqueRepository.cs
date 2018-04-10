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

        //get les musiques en base
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
                toAdd.Duree = dataReader.GetString(2);
                toAdd.Genre = dataReader.GetInt64(3);
                toAdd.Album = dataReader.GetInt64(4);
                toAdd.CheminFichier = dataReader.GetString(5);
                toAdd.Note = dataReader.GetInt32(6);

                toReturn.Add(toAdd);
            }


            return toReturn;
        }


        //ajoute une musique en base
        public static long addMusique(Musique musique)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"INSERT INTO Musique VALUES(
                                     @Titre
                                    ,@Duree
                                    ,@Genre
                                    ,@Album
                                    ,@CheminFichier
                                    ,@Note);
                                    SELECT @@IDENTITY;
                                   ";
            commande.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande.Prepare();

            //on mape les paramètres
            commande.Parameters.AddWithValue("@Titre", musique.Titre);
            commande.Parameters.AddWithValue("@Duree", musique.Duree);
            commande.Parameters.AddWithValue("@Genre", musique.Genre);
            commande.Parameters.AddWithValue("@Album", musique.Album);
            commande.Parameters.AddWithValue("@CheminFichier", musique.CheminFichier);
            commande.Parameters.AddWithValue("@Note", musique.Note);
            

            connection.Open();

            try
            {
                long idMusiqueAdded = long.Parse(commande.ExecuteScalar().ToString());
                addCompose(musique.Artiste, idMusiqueAdded);
                return idMusiqueAdded;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //ajoute une ligne dans la tables compose
        public static bool addCompose(long idArtiste, long idMusique)
        {
           
                SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

                SqlCommand commande = new SqlCommand();

                commande.CommandText = @"INSERT INTO Compose VALUES(@idArtiste, @idMusique)";
                commande.Connection = connection;

                connection.Open();

                commande.Prepare();
                commande.Parameters.AddWithValue("@idArtiste", idArtiste);
                commande.Parameters.AddWithValue("@idMusique", idMusique);
            try
            {

                commande.ExecuteNonQuery();
                return true;
            }
           catch(Exception)
            {
                return false;
            }
        }

        //met à jour une musique
        public static bool updateMusique(Musique musique)
        {
            //long idArtiste = 0;
            //idArtiste = ArtisteRepository.getIdFromNom(musique.ArtisteNom);
            

            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"UPDATE Musique
                                    SET
                                    Titre = @Titre
                                    ,Duree = @Duree
                                    ,Genre = @Genre
                                    ,Album = @Album
                                    ,CheminFichier = @CheminFichier
                                    ,Note = @Note
                                    WHERE Identifiant = @Identifiant";
            commande.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande.Prepare();

            //on mape les paramètres
            commande.Parameters.AddWithValue("@Titre", musique.Titre);
            commande.Parameters.AddWithValue("@Duree", musique.Duree);
            commande.Parameters.AddWithValue("@Genre", musique.Genre);
            commande.Parameters.AddWithValue("@Album", musique.Album);
            commande.Parameters.AddWithValue("@CheminFichier", musique.CheminFichier);
            commande.Parameters.AddWithValue("@Note", musique.Note);
            commande.Parameters.AddWithValue("@Identifiant", musique.Identifiant);

            SqlCommand commande2 = new SqlCommand();
            commande2.CommandText = @"UPDATE Compose
                                    SET
                                    IdentifiantArtiste = @Artiste
                                    WHERE IdentifiantMusique = @IdentifiantMusique";
            commande2.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande2.Prepare();

            //on mape les paramètres
            commande2.Parameters.AddWithValue("@IdentifiantMusique", musique.Identifiant);
            commande2.Parameters.AddWithValue("@Artiste", musique.Artiste);

            connection.Open();

            try
            {
                commande.ExecuteNonQuery();
                commande2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //suppression d'une musique
        public static bool deleteMusique(Musique musique)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"DELETE FROM Compose
                                     WHERE IdentifiantMusique = @IdentifiantMusique";
            commande.Connection = connection;

            //On spécifie que la requête est une commande "préparée"
            commande.Prepare();

            //On mappe les paramètres
            commande.Parameters.AddWithValue("@IdentifiantMusique", musique.Identifiant);

            connection.Open();

            SqlCommand commande2 = new SqlCommand();
            commande2.CommandText = @"DELETE FROM Musique
                                     WHERE Identifiant = @Identifiant";
            commande2.Connection = connection;

            //On spécifie que la requête est une commande "préparée"
            commande2.Prepare();

            //On mappe les paramètres
            commande2.Parameters.AddWithValue("@Identifiant", musique.Identifiant);

            try
            {
                commande.ExecuteNonQuery();
                commande2.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        //get l'id d'un artiste à partir de l'id d'une musique
        public static long getArtisteFromMusiqueId(long idMusique)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=BaseDeDonneesLecteur;Trusted_Connection=True;");

            SqlCommand commande = new SqlCommand();
            commande.CommandText = @"SELECT IdentifiantArtiste FROM Compose WHERE IdentifiantMusique = @idMusique;
                                   ";
            commande.Connection = connection;

            //on spécifie que la requête est une commande préparée
            commande.Prepare();

            //on mape les paramètres
            commande.Parameters.AddWithValue("@idMusique", idMusique);
           


            connection.Open();

            try
            {
                long idArtiste = long.Parse(commande.ExecuteScalar().ToString());
                
                return idArtiste;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}
