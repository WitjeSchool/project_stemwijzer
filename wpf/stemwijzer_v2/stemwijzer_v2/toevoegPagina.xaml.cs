using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace stemwijzer_v2
{
    /// <summary>
    /// Interaction logic for toevoegPagina.xaml
    /// </summary>
    public partial class toevoegPagina : Window
    {

        string file = "";

        public toevoegPagina(string soort)
        {
            InitializeComponent();

            switch (soort)
            {
                case "vragen":
                    vragenAanpassen();
                    break;
                case "verkiezingen":
                    verkiezingenAanpassen();
                    break;
                case "partijen":
                    partijenAanpassen();
                    break;
                case "users":
                    usersAanpassen();
                    break;
            }

        }


        private async void vragenAanpassen()
        {
            this.Title = "Vraag toevoegen";

            VerkiezingenDatabase database = new VerkiezingenDatabase();
            List<Verkiezingen> verkiezingen;
            try
            {
                verkiezingen = await Task.Run(() => database.GetVerkiezingen());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de verkiezingen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Verkiezingen _verkiezing in verkiezingen)
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = _verkiezing.Titel,
                    Tag = _verkiezing.Id
                };
                cmb_vragen_verkiezing.Items.Add(item);
            }

            grid_vragen.Visibility = Visibility.Visible;
        }

        private void verkiezingenAanpassen()
        {
            this.Title = "Verkiezing toevoegen";

            grid_verkiezingen.Visibility = Visibility.Visible;
        }

        private void partijenAanpassen()
        {
            this.Title = "Partij toevoegen";

            grid_partijen.Visibility = Visibility.Visible;
        }

        private void usersAanpassen()
        {
            this.Title = "Gebruiker toevoegen";

            grid_users.Visibility = Visibility.Visible;
        }

        private void btn_vragen_toevoegen_Click(object sender, RoutedEventArgs e)
        {



            if (cmb_vragen_verkiezing.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een verkiezing.");
                return;
            }

            ComboBoxItem verkiezing = cmb_vragen_verkiezing.SelectedItem as ComboBoxItem;
            if (int.TryParse(verkiezing.Tag.ToString(), out int verkiezingId) == false)
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de verkiezing ID. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                return;
            }

            string vraag = tb_vragen_vraag.Text.Trim();

            if (vraag.Length < 20 || vraag.Length > 200)
            {
                MessageBox.Show("De vraag moet minimaal 20/ mag maximaal 200 tekens lang zijn.");
                return;
            }

            VragenDatabase database = new VragenDatabase();
            try
            {
                database.ToevoegVragen(vraag, verkiezingId);
                MessageBox.Show("Successvol de vraag toegevoegd");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van de vraag. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private async void btn_verkiezingen_toevoegen_Click(object sender, RoutedEventArgs e)
        {

            VerkiezingenDatabase database = new VerkiezingenDatabase();
            List<Verkiezingen> verkiezingen;
            try
            {
                verkiezingen = await Task.Run(() => database.GetVerkiezingen());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de verkiezingen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Verkiezingen _verkiezing in verkiezingen)
            {
                if (_verkiezing.Titel.ToLower() == tb_verkiezingen_verkiezing.Text.Trim().ToLower())
                {
                    MessageBox.Show("Deze verkiezing bestaat al. Kies een andere naam.", "Verkiezing al in gebruik", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }


            if (tb_verkiezingen_verkiezing.Text.Trim().Length < 5 || tb_verkiezingen_verkiezing.Text.Trim().Length > 45)
            {
                MessageBox.Show("De verkiezing moet minimaal 5/ mag maximaal 45 tekens lang zijn.");
                return;
            }

            if (tb_verkiezingen_beschrijving.Text.Trim().Length < 50 || tb_verkiezingen_beschrijving.Text.Trim().Length > 2500)
            {
                MessageBox.Show("De beschrijving moet minimaal 50/ mag maximaal 2500 tekens lang zijn.");
                return;
            }

            DateTime.TryParse(dtp_verkiezingen_startDatum.SelectedDateTime.ToString(), out DateTime startDatum);
            DateTime.TryParse(dtp_verkiezingen_eindDatum.SelectedDateTime.ToString(), out DateTime eindDatum);

            if (startDatum == null || eindDatum == null)
            {
                MessageBox.Show("Selecteer een geldige start- en einddatum.");
                return;
            }
            if (startDatum < DateTime.Now || eindDatum < DateTime.Now)
            {
                MessageBox.Show("De start- en einddatum mogen niet in het verleden liggen.");
                return;
            }
            if (startDatum >= eindDatum)
            {
                MessageBox.Show("De startdatum moet voor de einddatum liggen.");
                return;
            }
            if (startDatum > DateTime.Now.AddYears(15) || eindDatum > DateTime.Now.AddYears(15))
            {
                MessageBox.Show("De start- en einddatum mogen niet verder dan 15 jaar in de toekomst liggen.");
                return;
            }
            if (eindDatum > startDatum.AddYears(1))
            {
                MessageBox.Show("De einddatum mag niet meer dan 1 jaar na de startdatum liggen.");
                return;
            }

            string verkiezingNaam = tb_verkiezingen_verkiezing.Text.Trim();
            string verkiezingBeschrijving = tb_verkiezingen_beschrijving.Text.Trim();



            VerkiezingenDatabase database1 = new VerkiezingenDatabase();
            try
            {
                database1.ToevoegVerkiezingen(verkiezingNaam, verkiezingBeschrijving, startDatum, eindDatum);
                MessageBox.Show("Successvol de verkiezing toegevoegd");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van de verkiezing. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private async void btn_partijen_toevoegen_Click(object sender, RoutedEventArgs e)
        {

            PartijenDatabase database = new PartijenDatabase();
            List<Partijen> partijen;
            try
            {
                partijen = await Task.Run(() => database.GetPartijen());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de partijen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Partijen _partij in partijen)
            {
                if (_partij.Naam.ToLower() == tb_partijen_partij.Text.Trim().ToLower())
                {
                    MessageBox.Show("Deze partij bestaat al. Kies een andere naam.", "Partij al in gebruik", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            if (tb_partijen_partij.Text.Trim().Length < 3 || tb_partijen_partij.Text.Trim().Length > 45)
            {
                MessageBox.Show("De partij naam moet minimaal 3/ mag maximaal 45 tekens lang zijn.");
                return;
            }
            if (tb_partijen_contact.Text.Trim().Length > 150)
            {
                MessageBox.Show("De beschrijving mag maximaal 150 tekens lang zijn.");
                return;
            }

            if (file == "")
            {
                MessageBox.Show("Selecteer een afbeelding bestand.", "Geen bestand geselecteerd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string[] files = Directory.GetFiles("..\\..\\PartijLogos");
            string bestandNaam = file.Split('\\').Last();

            char[] verbodenTekens = {
                '\\', '/', ':', '*', '?', '"', '<', '>', '|',
                '.', ',', ';', '!', '@', '#', '$', '%', '^', '&',
                '(', ')', '=', '+', '[', ']', '{', '}', '~', '`', '\''
            };


            if (tb_partijen_logo.Text.Replace(" ", "") == "" || tb_partijen_logo.Text.Length <= 1 || verbodenTekens.Any(t => tb_partijen_logo.Text.Contains(t)))
            {
                MessageBox.Show("Voer een (geldige) naam in voor de afbeelding.", "Geen (geldige) naam opgegeven", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (string item in files)
            {
                if (item.ToLower().Contains(tb_partijen_logo.Text.Replace(" ", "").ToLower()))
                {
                    MessageBox.Show("Deze naam is al in gebruik. Kies een andere naam.", "Naam al in gebruik", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            try
            {
                File.Copy(file, $"..\\..\\PartijLogos\\{tb_partijen_logo.Text.Trim().Replace(" ", "")}.{file.Split('.').Last()}", false);
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij opslaan van het bestand. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string partijNaam = tb_partijen_partij.Text.Trim();
            string partijContact = tb_partijen_contact.Text.Trim();
            string partijLogo = tb_partijen_logo.Text.Trim().Replace(" ", "").Trim() + "." + file.Split('.').Last();

            PartijenDatabase database1 = new PartijenDatabase();
            try
            {
                database1.ToevoegPartijen(partijNaam, partijContact, $"..\\..\\PartijLogos\\{partijLogo}");
                MessageBox.Show("Successvol de partij toegevoegd");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van de partij. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void btn_logo_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files |*.jpg;*.jpeg;*.png",
                Title = "Kies een logo bestand"
            };
            if (dialog.ShowDialog() == true)
            {
                if (dialog.FileName.EndsWith(".jpg") || dialog.FileName.EndsWith(".jpeg") || dialog.FileName.EndsWith(".png"))
                {
                    img_partijen_logo.Visibility = Visibility.Visible;
                    img_partijen_logo.Source = new BitmapImage(new Uri(dialog.FileName));

                    tb_partijen_logo.Visibility = Visibility.Visible;
                    tb_partijen_logo.Text = dialog.FileName.Split('\\').Last().Split('.').First();

                    file = dialog.FileName;
                }
                else
                {
                    MessageBox.Show("Selecteer een geldig afbeeldingsbestand (.jpg, .jpeg, .png).", "Ongeldig bestand", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btn_logo_verwijderen_Click(object sender, RoutedEventArgs e)
        {
            img_partijen_logo.Source = null;
            img_partijen_logo.Visibility = Visibility.Collapsed;
            tb_partijen_logo.Text = "";
            tb_partijen_logo.Visibility = Visibility.Collapsed;
        }



        private async void btn_users_toevoegen_Click(object sender, RoutedEventArgs e)
        {

            UsersDatabase database = new UsersDatabase();
            List<Users> users;
            try
            {
                users = await Task.Run(() => database.GetUsers());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de gebruikers. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            char[] verbodenTekens = {
                '\\', '/', ':', '*', '?', '"', '<', '>', '|',
                '.', ',', ';', '!', '@', '#', '$', '%', '^', '&',
                '(', ')', '=', '+', '[', ']', '{', '}', '~', '`', '\''
            };

            if (verbodenTekens.Any(t => tb_users_gebruikersnaam.Text.Contains(t)))
            {
                MessageBox.Show("Voer een geldige gebruikersnaam in.", "ongeldige gebruikersnaam", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (Users _user in users)
            {
                if (_user.Gebruikersnaam.ToLower() == tb_users_gebruikersnaam.Text.Trim().ToLower())
                {
                    MessageBox.Show("Deze gebruikersnaam bestaat al. Kies een andere gebruikersnaam.", "Gebruikersnaam al in gebruik", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (_user.Email.ToLower() == tb_users_email.Text.Trim().ToLower())
                {
                    MessageBox.Show("Deze email bestaat al. Kies een andere email.", "Email al in gebruik", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            if (tb_users_gebruikersnaam.Text.Trim().Length < 3 || tb_users_gebruikersnaam.Text.Trim().Length > 15)
            {
                MessageBox.Show("De gebruikersnaam moet minimaal 3/ mag maximaal 15 tekens lang zijn.");
                return;
            }
            if (tb_users_email.Text.Trim().Length < 5 || tb_users_email.Text.Trim().Length > 40)
            {
                MessageBox.Show("De email moet minimaal 5/ mag maximaal 50 tekens lang zijn.");
                return;
            }
            if (cmb_users_machtiging.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een machtiging.");
                return;
            }
            DateTime.TryParse(dtp_users_geboorteDatum.SelectedDateTime.ToString(), out DateTime geboorteDatum);
            if (geboorteDatum == null || geboorteDatum > DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("Selecteer een geldige geboortedatum (minimaal 18 jaar oud. Tijd maakt niet uit/ mag 12 uur in de nacht zijn.).");
                return;
            }
            if (geboorteDatum < DateTime.Now.AddYears(-100))
            {
                MessageBox.Show("De geboortedatum mag niet verder dan 100 jaar in het verleden liggen.");
                return;
            }

            if (!tb_users_email.Text.Contains("@") || !tb_users_email.Text.Contains("."))
            {
                MessageBox.Show("Voer een geldige email in.", "ongeldige email", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string gebruikersnaam = tb_users_gebruikersnaam.Text.Trim();
            string email = tb_users_email.Text.Trim();
            string wachtwoord = tb_users_wachtwoord.Text.Trim();
            ComboBoxItem machtigingItem = cmb_users_machtiging.SelectedItem as ComboBoxItem;
            string machtiging = machtigingItem.Content.ToString();
            DateTime accountBijgewerkt = DateTime.Now;
            DateTime accountGemaakt = DateTime.Now;

            if (wachtwoord.Length < 8 || wachtwoord.Length > 20 || !wachtwoord.Any(char.IsUpper) || !wachtwoord.Any(char.IsLower) || !wachtwoord.Any(char.IsDigit))
            {
                MessageBox.Show("Het wachtwoord moet minimaal 8/ mag maximaal 20 tekens lang zijn, een hoofdletter, een kleine letter en een cijfer bevatten.");
                return;
            }

            try
            {
                database.ToevoegUsers(gebruikersnaam, email, wachtwoord, machtiging, geboorteDatum, accountBijgewerkt, accountGemaakt);
                MessageBox.Show("Successvol de gebruiker toegevoegd");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van de gebruiker. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


        }





        private void btn_annuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
