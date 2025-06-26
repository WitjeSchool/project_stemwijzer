using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace stemwijzer_v2
{
    public class Users
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Machtiging { get; set; }
        public DateTime Geboorte_datum { get; set; }
        public DateTime Account_bijgewerkt { get; set; }
        public DateTime Account_gemaakt { get; set; }

    }

    public class Inloggen
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Machtiging { get; set; }
    }

    public class UsersById
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Machtiging { get; set; }
        public DateTime Geboorte_datum { get; set; }
        public DateTime Account_bijgewerkt { get; set; }
        public DateTime Account_gemaakt { get; set; }

    }

    public class UsersDatabase
    {
        private readonly string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=";

        public List<Users> GetUsers()
        {
            var users = new List<Users>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM users;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new Users()
                {
                    Id = reader.GetInt32("id"),
                    Gebruikersnaam = reader.GetString("gebruikersnaam"),
                    Email = reader.GetString("email"),
                    Wachtwoord = reader.GetString("wachtwoord"),
                    Machtiging = reader.GetString("machtiging"),
                    Geboorte_datum = reader.GetDateTime("geboorte_datum"),
                    Account_bijgewerkt = reader.GetDateTime("account_bijgewerkt"),
                    Account_gemaakt = reader.GetDateTime("account_gemaakt"),

                });
            }

            return users;
        }


        public List<Inloggen> GetUserLogin()
        {
            var inloggen = new List<Inloggen>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT id, gebruikersnaam, email, wachtwoord, machtiging FROM users;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                inloggen.Add(new Inloggen()
                {
                    Id = reader.GetInt32("id"),
                    Gebruikersnaam = reader.GetString("gebruikersnaam"),
                    Email = reader.GetString("email"),
                    Wachtwoord = reader.GetString("wachtwoord"),
                    Machtiging = reader.GetString("machtiging"),
                });
            }

            return inloggen;
        }


        public void VerwijderUser(int userId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "DELETE FROM users WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }



        public List<UsersById> GetUsersById(int userId)
        {
            var users = new List<UsersById>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT * FROM users WHERE id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", userId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new UsersById()
                {
                    Id = reader.GetInt32("id"),
                    Gebruikersnaam = reader.GetString("gebruikersnaam"),
                    Email = reader.GetString("email"),
                    Wachtwoord = reader.GetString("wachtwoord"),
                    Machtiging = reader.GetString("machtiging"),
                    Geboorte_datum = reader.GetDateTime("geboorte_datum"),
                    Account_bijgewerkt = reader.GetDateTime("account_bijgewerkt"),
                    Account_gemaakt = reader.GetDateTime("account_gemaakt"),

                });
            }

            return users;
        }


        public void AanpasUsers(int id, string gebruikersnaam, string email, string wachtwoord, string machtiging, DateTime geboorteDatum, DateTime bijgewerktDatum)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"UPDATE users SET gebruikersnaam = @gebruikersnaam, email = @email, wachtwoord = @wachtwoord, machtiging = @machtiging, geboorte_datum = @geboorteDatum, account_bijgewerkt = @bijgewerktDatum
            WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            cmd.Parameters.AddWithValue("@machtiging", machtiging);
            cmd.Parameters.AddWithValue("@geboorteDatum", geboorteDatum);
            cmd.Parameters.AddWithValue("@bijgewerktDatum", bijgewerktDatum);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void ToevoegUsers(string gebruikersnaam, string email, string wachtwoord, string machtiging, DateTime geboorteDatum, DateTime bijgewerktDatum, DateTime gemaaktDatum)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = @"INSERT INTO users (gebruikersnaam, email, wachtwoord, machtiging, geboorte_datum, account_bijgewerkt, account_gemaakt) VALUES (@gebruikersnaam, @email, @wachtwoord, @machtiging, @geboorteDatum, @bijgewerktDatum, @gemaaktDatum)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            cmd.Parameters.AddWithValue("@machtiging", machtiging);
            cmd.Parameters.AddWithValue("@geboorteDatum", geboorteDatum);
            cmd.Parameters.AddWithValue("@bijgewerktDatum", bijgewerktDatum);
            cmd.Parameters.AddWithValue("@gemaaktDatum", gemaaktDatum);
            cmd.ExecuteNonQuery();
        }

    }
}
