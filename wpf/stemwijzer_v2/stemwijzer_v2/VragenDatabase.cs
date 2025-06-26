using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stemwijzer_v2
{
    public class Vragen
    {
        public int Id { get; set; }
        public string Vraag { get; set; }
        public string Verkiezing { get; set; }
    }

    public class VragenById
    {
        public int Id { get; set; }
        public string Vraag { get; set; }
        public string Verkiezing { get; set; }
        public int VerkiezingId { get; set; }
    }

    public class VragenDatabase
    {
        private readonly string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=";

        public List<Vragen> GetVragen()
        {
            var vragen = new List<Vragen>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT va.id, va.vraag, v.titel FROM vragenarregement AS va INNER JOIN verkiezingen AS v ON va.verkiezing_id = v.id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vragen.Add(new Vragen()
                {
                    Id = reader.GetInt32("id"),
                    Vraag = reader.GetString("vraag"),
                    Verkiezing = reader.GetString("titel")
                });
            }

            return vragen;
        }

        public void VerwijderVraag(int vraagId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "DELETE FROM vragenarregement WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", vraagId);
            cmd.ExecuteNonQuery();
        }

        public List<VragenById> GetVragenById(int vraagId)
        {
            var vragen = new List<VragenById>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT va.id, va.vraag, v.titel, v.id AS vId FROM vragenarregement AS va INNER JOIN verkiezingen AS v ON va.verkiezing_id = v.id WHERE va.id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", vraagId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vragen.Add(new VragenById()
                {
                    Id = reader.GetInt32("id"),
                    Vraag = reader.GetString("vraag"),
                    Verkiezing = reader.GetString("titel"),
                    VerkiezingId = reader.GetInt32("vId")
                });
            }

            return vragen;
        }

        public void AanpasVragen(int id, string vraagTekst, int vkId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"UPDATE vragenarregement SET vraag = @vraag, verkiezing_id = @verkiezingId
            WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@vraag", vraagTekst);
            cmd.Parameters.AddWithValue("@verkiezingId", vkId);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void ToevoegVragen(string vraag, int verkiezingId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"INSERT INTO vragenarregement (vraag, verkiezing_id) VALUES (@vraag, @verkiezing)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@vraag", vraag);
            cmd.Parameters.AddWithValue("@verkiezing", verkiezingId);
            cmd.ExecuteNonQuery();
        }

    }
}
