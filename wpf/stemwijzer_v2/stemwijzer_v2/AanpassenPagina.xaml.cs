using System;
using System.Collections.Generic;
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
using System.IO;

namespace stemwijzer_v2
{
    /// <summary>
    /// Interaction logic for AanpassenPagina.xaml
    /// </summary>
    public partial class AanpassenPagina : Window
    {

        int Machtiging;
        int IngelogdeUserId;

        public AanpassenPagina(string soort, int id, int machtiging, int ingelogdeUserId)
        {
            InitializeComponent();

            switch (soort)
            {
                case "vragen":
                    vragenAanpassen(id);
                    break;
                case "verkiezingen":
                    verkiezingenAanpassen(id);
                    break;
                case "partijen":
                    partijenAanpassen(id);
                    break;
                case "users":
                    usersAanpassen(id);
                    break;
            }

            Machtiging = machtiging;
            IngelogdeUserId = ingelogdeUserId;

        }

        // VRAGEN AANPASSEN =========================================================================================================================================================================

        private async void vragenAanpassen(int id)
        {

            this.Title = "Vraag aanpassen";
            List<VragenById> vragen;
            VragenDatabase database = new VragenDatabase();
            try
            {
                vragen = await Task.Run(() => database.GetVragenById(id));
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de vraag. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678 {id}");
                return;
            }

            VerkiezingenDatabase databasevk = new VerkiezingenDatabase();
            List<Verkiezingen> verkiezingen;
            try
            {
                verkiezingen = await Task.Run(() => databasevk.GetVerkiezingen());
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de verkiezingen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678 {id}");
                return;
            }

            grid_vragen.Visibility = Visibility.Visible;

            tb_vragen_id.Text = vragen[0].Id.ToString();
            tb_vragen_vraag.Text = vragen[0].Vraag;

            ComboBoxItem comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = vragen[0].Verkiezing;
            comboBoxItem.Tag = vragen[0].VerkiezingId;
            cmb_vragen_verkiezing.Items.Add(comboBoxItem);
            cmb_vragen_verkiezing.SelectedIndex = 0;

            foreach (var verkiezing in verkiezingen)
            {
                bool bestaatAl = false;

                foreach (ComboBoxItem item in cmb_vragen_verkiezing.Items)
                {
                    if (item.Content.ToString() == verkiezing.Titel)
                    {
                        bestaatAl = true;
                        break;
                    }
                }

                if (!bestaatAl)
                {
                    ComboBoxItem nieuwItem = new ComboBoxItem();
                    nieuwItem.Content = verkiezing.Titel;
                    nieuwItem.Tag = verkiezing.Id;
                    cmb_vragen_verkiezing.Items.Add(nieuwItem);
                }
            }
        }

        private void btn_vragen_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem geselecteerdeItem = cmb_vragen_verkiezing.SelectedItem as ComboBoxItem;
            int.TryParse(geselecteerdeItem.Tag.ToString(), out int verkiezingId);
            int.TryParse(tb_vragen_id.Text, out int id);
            string vraagTekst = tb_vragen_vraag.Text;


            if (vraagTekst.Length < 20)
            {
                MessageBox.Show("De vraag moet minimaal 20 tekens lang zijn.");
                return;
            }

            VragenDatabase database = new VragenDatabase();
            try
            {
                database.AanpasVragen(id, vraagTekst, verkiezingId);
                MessageBox.Show("De vraag is succesvol aangepast.");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het aanpassen van de vraag. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                return;
            }
        }


        // ==========================================================================================================================================================================================================

        // VERKIEZINGEN AANPASSEN =========================================================================================================================================================================

        private async void verkiezingenAanpassen(int id)
        {

            this.Title = "Verkiezing aanpassen";

            VerkiezingenDatabase database = new VerkiezingenDatabase();
            List<VerkiezingenById> verkiezingen;
            try
            {
                verkiezingen = await Task.Run(() => database.GetVerkiezingenById(id));
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de verkiezing. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678 {id}");
                return;
            }

            grid_verkiezingen.Visibility = Visibility.Visible;



            tb_verkiezingen_id.Text = verkiezingen[0].Id.ToString();
            tb_verkiezingen_verkiezing.Text = verkiezingen[0].Verkiezing;
            tb_verkiezingen_beschrijving.Text = verkiezingen[0].Beschrijving;

            dtp_verkiezingen_startDatum.SelectedDateTime = verkiezingen[0].Start_datum;
            dtp_verkiezingen_eindDatum.SelectedDateTime = verkiezingen[0].Eind_datum;


        }

        private void btn_verkiezingen_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tb_verkiezingen_id.Text, out int id);
            string verkiezingNaam = tb_verkiezingen_verkiezing.Text;
            string beschrijving = tb_verkiezingen_beschrijving.Text;

            if (verkiezingNaam.Length < 5)
            {
                MessageBox.Show("De verkiezing moet minimaal 5 tekens lang zijn.");
                return;
            }

            if (beschrijving.Length < 50)
            {
                MessageBox.Show("De beschrijving moet minimaal 50 tekens lang zijn.");
                return;
            }

            if (!DateTime.TryParse(dtp_verkiezingen_startDatum.SelectedDateTime.ToString(), out DateTime startDatum))
            {
                MessageBox.Show("De startdatum moet een geldige datum zijn.");
                return;
            }

            if (!DateTime.TryParse(dtp_verkiezingen_eindDatum.SelectedDateTime.ToString(), out DateTime eindDatum))
            {
                MessageBox.Show("De einddatum moet een geldige datum zijn.");
                return;
            }

            if (startDatum < DateTime.Now)
            {
                MessageBox.Show("De startdatum kan niet in het verleden liggen.");
                return;
            }

            if (eindDatum < DateTime.Now)
            {
                MessageBox.Show("De einddatum kan niet in het verleden liggen.");
                return;
            }

            if (eindDatum > startDatum.AddYears(1))
            {
                MessageBox.Show("De einddatum mag niet meer dan 1 jaar na de startdatum liggen.");
                return;
            }

            if (startDatum > DateTime.Now.AddYears(15) || eindDatum > DateTime.Now.AddYears(15))
            {
                MessageBox.Show("De start- en einddatum mogen niet meer dan 15 jaar in de toekomst liggen.");
                return;
            }

            if (startDatum >= eindDatum)
            {
                MessageBox.Show("De startdatum moet voor de einddatum liggen.");
                return;
            }

            VerkiezingenDatabase database = new VerkiezingenDatabase();
            try
            {
                database.AanpasVerkiezingen(id, verkiezingNaam, beschrijving, startDatum, eindDatum);
                MessageBox.Show("De verkiezing is succesvol aangepast.");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het aanpassen van de verkiezing. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678 {id}");
                return;
            }

        }

        // ==========================================================================================================================================================================================================


        // PARTIJEN AANPASSEN ===================================================================================================================================================================================


        private async void partijenAanpassen(int id)
        {


            this.Title = "Partij aanpassen";


            PartijenDatabase database = new PartijenDatabase();
            List<PartijenById> partijen;
            try
            {
                partijen = await Task.Run(() => database.GetPartijenById(id));
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de partij. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678 {id}");
                return;
            }

            grid_partijen.Visibility = Visibility.Visible;



            tb_partijen_id.Text = partijen[0].Id.ToString();
            tb_partijen_contact.Text = partijen[0].Contact;
            tb_partijen_partij.Text = partijen[0].Partij;

            if (partijen[0].Logo == "")
            {

            }
            else
            {
                ComboBoxItem comboBoxItemLogo = new ComboBoxItem();
                Image logoImage = new Image();
                // CHATGPT stukje word doc #6 -----------------------------------------------------------------------
                BitmapImage bitmap = new BitmapImage();
                try
                {
                    using (FileStream stream = new FileStream(partijen[0].Logo, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad; // belangrijk!
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                    }
                    bitmap.Freeze();
                    logoImage.Source = bitmap;
                    //---------------------------------------------------------------------------------------------
                    logoImage.Width = 95;
                    logoImage.Height = 95;
                    comboBoxItemLogo.Content = logoImage;
                    comboBoxItemLogo.Tag = partijen[0].Logo;
                    comboBoxItemLogo.HorizontalContentAlignment = HorizontalAlignment.Center;
                    cmb_partijen_logo.Items.Add(comboBoxItemLogo);
                    cmb_partijen_logo.SelectedIndex = 0;
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden bij het laden van het logo. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                }

            }
            foreach (string bestand in Directory.GetFiles("..\\..\\PartijLogos"))
            {
                bool alToegevoegd = false;

                foreach (ComboBoxItem item in cmb_partijen_logo.Items.OfType<ComboBoxItem>())
                {
                    if (item.Tag.ToString() == bestand)
                    {
                        alToegevoegd = true;
                        break;
                    }
                }

                if (!alToegevoegd)
                {
                    ComboBoxItem comboBoxItemLogo1 = new ComboBoxItem();
                    Image logoImage1 = new Image();
                    // CHATGPT stukje word doc #6 -----------------------------------------------------------------------
                    BitmapImage bitmap1 = new BitmapImage();
                    try
                    {
                        using (FileStream stream = new FileStream(bestand, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            bitmap1.BeginInit();
                            bitmap1.CacheOption = BitmapCacheOption.OnLoad; // belangrijk!
                            bitmap1.StreamSource = stream;
                            bitmap1.EndInit();
                        }
                        bitmap1.Freeze();
                    }
                    catch
                    {
                        MessageBox.Show("Er is een fout opgetreden bij het laden van het logo. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                    }
                    logoImage1.Source = bitmap1;
                    // ---------------------------------------------------------------------------------------------
                    logoImage1.Width = 95;
                    logoImage1.Height = 95;
                    comboBoxItemLogo1.Content = logoImage1;
                    comboBoxItemLogo1.Tag = bestand;
                    comboBoxItemLogo1.HorizontalContentAlignment = HorizontalAlignment.Center;
                    cmb_partijen_logo.Items.Add(comboBoxItemLogo1);
                }

            }

        }


        private void btn_partijen_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tb_partijen_id.Text, out int id);
            string contact = tb_partijen_contact.Text;
            string partijNaam = tb_partijen_partij.Text;

            if (tb_partijen_partij.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Selecteer een partij.");
                return;
            }
            if (cmb_partijen_logo.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een logo.");
                return;
            }

            ComboBoxItem geselecteerdeLogoItem = cmb_partijen_logo.SelectedItem as ComboBoxItem;


            string logoPad = geselecteerdeLogoItem.Tag.ToString();

            PartijenDatabase database = new PartijenDatabase();
            try
            {
                database.AanpasPartijen(id, partijNaam, contact, logoPad);
                MessageBox.Show("De partij is succesvol aangepast.");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het aanpassen van de partij. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678 {id}");
                return;
            }
        }

        private void btn_logo_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            LogoToevoegenPagina logoToevoegenPagina = new LogoToevoegenPagina();
            logoToevoegenPagina.ShowDialog();

            foreach (string bestand in Directory.GetFiles("..\\..\\PartijLogos"))
            {
                bool alToegevoegd = false;

                foreach (ComboBoxItem item in cmb_partijen_logo.Items.OfType<ComboBoxItem>())
                {
                    if (item.Tag.ToString() == bestand)
                    {
                        alToegevoegd = true;
                        break;
                    }
                }

                if (!alToegevoegd)
                {
                    ComboBoxItem comboBoxItemLogo1 = new ComboBoxItem();
                    Image logoImage1 = new Image();
                    // CHATGPT stukje word doc #6 -----------------------------------------------------------------------
                    BitmapImage bitmap1 = new BitmapImage();
                    try
                    {
                        using (FileStream stream = new FileStream(bestand, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            bitmap1.BeginInit();
                            bitmap1.CacheOption = BitmapCacheOption.OnLoad; // belangrijk!
                            bitmap1.StreamSource = stream;
                            bitmap1.EndInit();
                        }
                        bitmap1.Freeze();
                    }
                    catch
                    {
                        MessageBox.Show("Er is een fout opgetreden bij het laden van het logo. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                    }
                    logoImage1.Source = bitmap1;
                    // ---------------------------------------------------------------------------------------------
                    logoImage1.Width = 95;
                    logoImage1.Height = 95;
                    comboBoxItemLogo1.Content = logoImage1;
                    comboBoxItemLogo1.Tag = bestand;
                    comboBoxItemLogo1.HorizontalContentAlignment = HorizontalAlignment.Center;
                    cmb_partijen_logo.Items.Add(comboBoxItemLogo1);
                }
            }

        }

        private void btn_logo_verwijderen_Click(object sender, RoutedEventArgs e)
        {
            var geselecteerdeItem = cmb_partijen_logo.SelectedItem as ComboBoxItem;

            string pad = geselecteerdeItem.Tag.ToString();

            var result = MessageBox.Show("Weet je zeker dat je dit logo wilt verwijderen?", "Logo verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                File.Delete(pad);
                cmb_partijen_logo.Items.Remove(geselecteerdeItem);
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het verwijderen van het logo. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                return;
            }

            foreach (string bestand in Directory.GetFiles("..\\..\\PartijLogos"))
            {
                bool alToegevoegd = false;

                foreach (ComboBoxItem item in cmb_partijen_logo.Items.OfType<ComboBoxItem>())
                {
                    if (item.Tag.ToString() == bestand)
                    {
                        alToegevoegd = true;
                        break;
                    }
                }

                if (!alToegevoegd)
                {
                    ComboBoxItem comboBoxItemLogo1 = new ComboBoxItem();
                    Image logoImage1 = new Image();

                    // CHATGPT stukje word doc #6 -----------------------------------------------------------------------
                    BitmapImage bitmap1 = new BitmapImage();
                    using (FileStream stream = new FileStream(bestand, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        bitmap1.BeginInit();
                        bitmap1.CacheOption = BitmapCacheOption.OnLoad; // belangrijk!
                        bitmap1.StreamSource = stream;
                        bitmap1.EndInit();
                    }
                    bitmap1.Freeze();

                    logoImage1.Source = bitmap1;
                    // ---------------------------------------------------------------------------------------------
                    logoImage1.Width = 95;
                    logoImage1.Height = 95;
                    comboBoxItemLogo1.Content = logoImage1;
                    comboBoxItemLogo1.Tag = bestand;
                    comboBoxItemLogo1.HorizontalContentAlignment = HorizontalAlignment.Center;
                    cmb_partijen_logo.Items.Add(comboBoxItemLogo1);
                }
            }

        }


        // ==========================================================================================================================================================================================================


        // USERS AANPASSEN ===================================================================================================================================================================================




        private async void usersAanpassen(int id)
        {

            this.Title = "Gebruiker aanpassen";


            UsersDatabase database = new UsersDatabase();
            List<UsersById> users;
            try
            {
                users = await Task.Run(() => database.GetUsersById(id));
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de gebruiker. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678 {id}");
                return;
            }

            grid_users.Visibility = Visibility.Visible;


            tb_users_id.Text = users[0].Id.ToString();
            tb_users_gebruikersnaam.Text = users[0].Gebruikersnaam;
            tb_users_email.Text = users[0].Email;
            tb_users_wachtwoord.Text = users[0].Wachtwoord;



            cmb_users_machtiging.Items.Add(users[0].Machtiging);
            cmb_users_machtiging.SelectedIndex = 0;



            dtp_users_geboorteDatum.SelectedDateTime = users[0].Geboorte_datum;
            dtp_users_bijgewerktDatum.SelectedDateTime = users[0].Account_bijgewerkt;
            dtp_users_gemaaktDatum.SelectedDateTime = users[0].Account_gemaakt;

            if (Machtiging == 1)
            {

                if (users[0].Machtiging == "gebruiker" || users[0].Machtiging == "medewerker")
                {
                    tb_users_gebruikersnaam.IsEnabled = false;
                    tb_users_email.IsEnabled = false;
                    tb_users_wachtwoord.IsEnabled = false;
                    dtp_users_geboorteDatum.IsEnabled = false;
                }
                string[] machtigingenOwner = { "owner", "admin", "gebruiker" };
                foreach (string machtiging in machtigingenOwner)
                {
                    if (machtiging != users[0].Machtiging)
                    {
                        cmb_users_machtiging.Items.Add(machtiging);
                    }
                }

            }
            else if (Machtiging == 2)
            {
                if (users[0].Machtiging == "owner" || users[0].Machtiging == "admin")
                {
                    if (users[0].Id != IngelogdeUserId)
                    {
                        tb_users_gebruikersnaam.IsEnabled = false;
                        tb_users_email.IsEnabled = false;
                        tb_users_wachtwoord.IsEnabled = false;
                        dtp_users_geboorteDatum.IsEnabled = false;
                        cmb_users_machtiging.IsEnabled = false;
                    }
                }
                else
                {
                    string[] machtigingenAdmin = { "medewerker", "gebruiker" };
                    foreach (string machtiging in machtigingenAdmin)
                    {
                        if (machtiging != users[0].Machtiging)
                        {
                            cmb_users_machtiging.Items.Add(machtiging);
                        }
                    }
                }
            }
            else
            {
                string[] machtigingen = { "owner", "admin", "medewerker", "gebruiker" };
                foreach (string machtiging in machtigingen)
                {
                    if (machtiging != users[0].Machtiging)
                    {
                        cmb_users_machtiging.Items.Add(machtiging);
                    }
                }
            }
        }



        private void btn_users_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tb_users_id.Text, out int id);
            string gebruikersnaam = tb_users_gebruikersnaam.Text;
            string email = tb_users_email.Text;
            string wachtwoord = tb_users_wachtwoord.Text;
            string machtiging = cmb_users_machtiging.SelectedItem.ToString();
            DateTime accountBijgewerkt = DateTime.Now;

            char[] verbodenTekens = new char[]
            {
                ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
                ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '`', '{', '|', '}', '~'
            };


            if (gebruikersnaam.Length < 5 || gebruikersnaam.Length > 15 || gebruikersnaam.Any(c => verbodenTekens.Contains(c)))
            {
                MessageBox.Show("De gebruikersnaam moet minimaal 5 / mag maximaal 15 tekens lang zijn en geen andere tekens dan '_' bevatten");
                return;
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains(".") || email.Length > 40)
            {
                MessageBox.Show("De email moet minimaal 5 / mag maximaal 40 tekens lang zijn en een geldig email formaat hebben.");
                return;
            }

            if (wachtwoord.Length < 8 || wachtwoord.Length > 20 || !wachtwoord.Any(char.IsUpper) || !wachtwoord.Any(char.IsLower) || !wachtwoord.Any(char.IsDigit))
            {
                MessageBox.Show("Het wachtwoord moet minimaal 8 / mag maximaal 20 tekens lang zijn, een hoofdletter, een kleine letter en een cijfer bevatten.");
                return;
            }

            if (cmb_users_machtiging.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een machtiging.");
                return;
            }



            if (DateTime.TryParse(dtp_users_geboorteDatum.SelectedDateTime.ToString(), out DateTime geboorteDatum))
            {
                if (geboorteDatum > DateTime.Now)
                {
                    MessageBox.Show("De geboortedatum kan niet in de toekomst liggen.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("De geboortedatum moet een geldige datum zijn.");
                return;
            }


            UsersDatabase database = new UsersDatabase();
            try
            {
                database.AanpasUsers(id, gebruikersnaam, email, wachtwoord, machtiging, geboorteDatum, accountBijgewerkt);
                MessageBox.Show("De gebruiker is succesvol aangepast.");
                this.Close();
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het aanpassen van de gebruiker. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                return;
            }


        }



        // ==========================================================================================================================================================================================================

        private void btn_annuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
