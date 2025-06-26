using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stemwijzer_v2
{
    public class Verkiezingen
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Start_datum { get; set; }
        public DateTime Eind_datum { get; set; }

    }

    public class VerkiezingenById
    {
        public int Id { get; set; }
        public string Verkiezing { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Start_datum { get; set; }
        public DateTime Eind_datum { get; set; }
    }

    public class VerkiezingenDatabase
    {
        private readonly string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=";

        public List<Verkiezingen> GetVerkiezingen()
        {
            var verkiezingen = new List<Verkiezingen>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM verkiezingen;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                verkiezingen.Add(new Verkiezingen()
                {
                    Id = reader.GetInt32("id"),
                    Titel = reader.GetString("titel"),
                    Beschrijving = reader.GetString("beschrijving"),
                    Start_datum = reader.GetDateTime("start_datum"),
                    Eind_datum = reader.GetDateTime("eind_datum"),

                });
            }

            return verkiezingen;
        
        }


        public void VerwijderVerkiezing(int verkiezingId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "DELETE FROM verkiezingen WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", verkiezingId);
            cmd.ExecuteNonQuery();
        }



        public List<VerkiezingenById> GetVerkiezingenById(int verkiezingId)
        {
            var verkiezingen = new List<VerkiezingenById>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM verkiezingen WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", verkiezingId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                verkiezingen.Add(new VerkiezingenById()
                {
                    Id = reader.GetInt32("id"),
                    Verkiezing = reader.GetString("titel"),
                    Beschrijving = reader.GetString("beschrijving"),
                    Start_datum = reader.GetDateTime("start_datum"),
                    Eind_datum = reader.GetDateTime("eind_datum"),
                });
            }

            return verkiezingen;
        }


        public void AanpasVerkiezingen(int id, string verkiezing,string beschrijving, DateTime startDatum, DateTime eindDatum)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"UPDATE verkiezingen SET titel = @verkiezing, beschrijving = @beschrijving, start_datum = @startDatum, eind_datum = @eindDatum
            WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@verkiezing", verkiezing);
            cmd.Parameters.AddWithValue("@beschrijving", beschrijving);
            cmd.Parameters.AddWithValue("@startDatum", startDatum);
            cmd.Parameters.AddWithValue("@eindDatum", eindDatum);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void ToevoegVerkiezingen(string verkiezing, string beschrijving, DateTime startDatum, DateTime eindDatum)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"INSERT INTO verkiezingen (titel, beschrijving, start_datum, eind_datum) VALUES (@verkiezing, @beschrijving, @startDatum, @eindDatum)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@verkiezing", verkiezing);
            cmd.Parameters.AddWithValue("@beschrijving", beschrijving);
            cmd.Parameters.AddWithValue("@startDatum", startDatum);
            cmd.Parameters.AddWithValue("@eindDatum", eindDatum);
            cmd.ExecuteNonQuery();
        }


    }
}
