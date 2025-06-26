using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stemwijzer_v2
{
    public class Partijen
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Logo { get; set; }
        public string Contact { get; set; }

    }

    public class PartijenById
    {
        public int Id { get; set; }
        public string Partij { get; set; }
        public string Contact { get; set; }
        public string Logo { get; set; }
    }

    public class PartijenDatabase
    {
        private readonly string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=";

        public List<Partijen> GetPartijen()
        {
            var partijen = new List<Partijen>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM partijen;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                partijen.Add(new Partijen()
                {
                    Id = reader.GetInt32("id"),
                    Naam = reader.GetString("naam"),
                    Logo = reader.GetString("logo"),
                    Contact = reader.GetString("contact"),
                });
            }

            return partijen;
        }


        public void VerwijderPartij(int partijId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "DELETE FROM partijen WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", partijId);
            cmd.ExecuteNonQuery();
        }


        public List<PartijenById> GetPartijenById(int partijId)
        {
            var partijen = new List<PartijenById>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM partijen WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", partijId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                partijen.Add(new PartijenById()
                {
                    Id = reader.GetInt32("id"),
                    Partij = reader.GetString("naam"),
                    Contact = reader.GetString("contact"),
                    Logo = reader.GetString("logo"),
                });
            }
            return partijen;
            
        }



        public void AanpasPartijen(int id, string partijNaam, string contact, string filepad)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"UPDATE partijen SET naam = @naam, contact = @contact, logo = @logo
            WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@naam", partijNaam);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@logo", filepad);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void ToevoegPartijen(string partijNaam, string contact, string filepad)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"INSERT INTO partijen (naam, contact, logo) VALUES (@naam, @contact, @logo)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@naam", partijNaam);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@logo", filepad);
            cmd.ExecuteNonQuery();
        }


    }
}
