using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stemwijzer_v2
{
    public class PartijMeningen
    {
        public int Id { get; set; }
        public int PartijId { get; set; }
        public int VraagId { get; set; }
        public string Mening { get; set; }

    }

    public class PartijMeningenById
    {
        public int Id { get; set; }
        public int PartijId { get; set; }
        public int VraagId { get; set; }
        public string Mening { get; set; }
    }

    public class PartijMeningenDatabase
    {
        private readonly string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=";

        public List<PartijMeningen> GetPartijMeningen()
        {
            var partijMeningen = new List<PartijMeningen>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM partij_meningen;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                partijMeningen.Add(new PartijMeningen()
                {
                    Id = reader.GetInt32("id"),
                    PartijId = reader.GetInt32("partij_id"),
                    VraagId = reader.GetInt32("vraag_id"),
                    Mening = reader.GetString("mening"),
                });
            }

            return partijMeningen;
        }


        public void VerwijderPartijMeningen(int partijMeningId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "DELETE FROM partij_meningen WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", partijMeningId);
            cmd.ExecuteNonQuery();
        }


        public List<PartijMeningenById> GetPartijMeningenById(int partijMeningId)
        {
            var partijMeningen = new List<PartijMeningenById>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM partij_meningen WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", partijMeningId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                partijMeningen.Add(new PartijMeningenById()
                {
                    Id = reader.GetInt32("id"),
                    PartijId = reader.GetInt32("partij_id"),
                    VraagId = reader.GetInt32("vraag_id"),
                    Mening = reader.GetString("mening"),
                });
            }

            return partijMeningen;
        }



        public void AanpasPartijMeningen(int partijMeningId, int partij_id, int vraag_id, string mening)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"UPDATE partij_meningen SET partij_id = @partij_id, vraag_id = @vraag_id, mening = @mening
            WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@partij_id", partij_id);
            cmd.Parameters.AddWithValue("@vraag_id", vraag_id);
            cmd.Parameters.AddWithValue("@mening", mening);
            cmd.Parameters.AddWithValue("@id", partijMeningId);
            cmd.ExecuteNonQuery();
        }

        public void ToevoegPartijMeningen(int partij_id, int vraag_id, string mening)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"INSERT INTO partij_meningen (partij_id, vraag_id, mening) VALUES (@partij_id, @vraag_id, @mening)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@partij_id", partij_id);
            cmd.Parameters.AddWithValue("@vraag_id", vraag_id);
            cmd.Parameters.AddWithValue("@mening", mening);
            cmd.ExecuteNonQuery();
        }


    }
}
