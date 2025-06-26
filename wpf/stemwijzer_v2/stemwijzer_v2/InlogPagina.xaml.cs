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

namespace stemwijzer_v2
{
    /// <summary>
    /// Interaction logic for InlogPagina.xaml
    /// </summary>
    public partial class InlogPagina : Window
    {

        int machtigingNmr;
        int IngelogdeUserId;

        public InlogPagina()
        {
            InitializeComponent();

            cmb_pagina.SelectionChanged += (s, ev) => VeranderPagina();
        }

        private async void btn_inloggen_Click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;

            if (btn.Content.ToString() == "Inloggen")
            {

                UsersDatabase database = new UsersDatabase();
                List<Inloggen> inloggen;
                try
                {
                    inloggen = await Task.Run(() => database.GetUserLogin());
                } catch
                {
                    MessageBox.Show("Er is een fout opgetreden bij het ophalen van gebruikersgegevens. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                string gebruikersnaam_email = tb_gebruikersnaam_email.Text;
                string wachtwoord = pb_wachtwoord.Password;

                if (gebruikersnaam_email.Contains("@"))
                {
                    int i = 0;
                    foreach (var user in inloggen)
                    {
                        if (user.Email == gebruikersnaam_email && user.Wachtwoord == wachtwoord)
                        {

                            if (user.Machtiging == "gebruiker")
                            {
                                MessageBox.Show("Je hebt geen toegang tot deze applicatie. Neem contact op met de beheerder.", "Toegang geweigerd", MessageBoxButton.OK, MessageBoxImage.Warning);
                                tb_gebruikersnaam_email.Text = "";
                                pb_wachtwoord.Password = "";
                                return;
                            }

                            tb_gebruikersnaam_email.Visibility = Visibility.Collapsed;
                            pb_wachtwoord.Visibility = Visibility.Collapsed;
                            btn_inloggen.Content = "Uitloggen";
                            tb_uitloggen_inloggen.Foreground = Brushes.Green;
                            tb_uitloggen_inloggen.Text = "Ingelogd";

                            tb_gebruikersnaam_email.Text = "";
                            pb_wachtwoord.Password = "";
                            checkMachtiging(user.Machtiging);
                            return;
                        }
                        i++;

                        if (i == inloggen.Count)
                        {
                            MessageBox.Show("Ongeldige email of wachtwoord. Probeer opnieuw.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                }
                else
                {

                    int i = 0;
                    foreach (var user in inloggen)
                    {
                        if (user.Gebruikersnaam == gebruikersnaam_email && user.Wachtwoord == wachtwoord)
                        {

                            if (user.Machtiging == "gebruiker")
                            {
                                MessageBox.Show("Je hebt geen toegang tot deze applicatie. Neem contact op met de beheerder.", "Toegang geweigerd", MessageBoxButton.OK, MessageBoxImage.Warning);
                                tb_gebruikersnaam_email.Text = "";
                                pb_wachtwoord.Password = "";
                                return;
                            }

                            tb_gebruikersnaam_email.Visibility = Visibility.Collapsed;
                            pb_wachtwoord.Visibility = Visibility.Collapsed;
                            btn_inloggen.Content = "Uitloggen";
                            tb_uitloggen_inloggen.Foreground = Brushes.Green;
                            tb_uitloggen_inloggen.Text = "Ingelogd";

                            tb_gebruikersnaam_email.Text = "";
                            pb_wachtwoord.Password = "";
                            IngelogdeUserId = user.Id;
                            checkMachtiging(user.Machtiging);
                            return;
                        }
                        i++;

                        if (i == inloggen.Count)
                        {
                            MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord. Probeer opnieuw.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }

            }
            else
            {
                tb_gebruikersnaam_email.Visibility = Visibility.Visible;
                pb_wachtwoord.Visibility = Visibility.Visible;
                btn_inloggen.Content = "Inloggen";
                tb_uitloggen_inloggen.Foreground = Brushes.Red;
                tb_uitloggen_inloggen.Text = "Uitgelogd";

                cmbi_gb.Visibility = Visibility.Collapsed;
                cmbi_pb.Visibility = Visibility.Collapsed;
                cmbi_vkb.Visibility = Visibility.Collapsed;
                cmbi_vb.Visibility = Visibility.Collapsed;

                return;
            }
        }



        private void checkMachtiging(string machtiging)
        {
            switch (machtiging)
            {
                case "medewerker":
                    cmbi_gb.Visibility = Visibility.Collapsed;
                    cmbi_pb.Visibility = Visibility.Visible;
                    cmbi_vkb.Visibility = Visibility.Visible;
                    cmbi_vb.Visibility = Visibility.Visible;
                    cmbi_pmb.Visibility = Visibility.Collapsed;
                    machtigingNmr = 3;
                    break;
                case "admin":
                    cmbi_gb.Visibility = Visibility.Visible;
                    cmbi_pb.Visibility = Visibility.Collapsed;
                    cmbi_vkb.Visibility = Visibility.Collapsed;
                    cmbi_vb.Visibility = Visibility.Collapsed;
                    cmbi_pmb.Visibility = Visibility.Collapsed;
                    machtigingNmr = 2;
                    break;
                case "owner":
                    cmbi_gb.Visibility = Visibility.Visible;
                    cmbi_pb.Visibility = Visibility.Collapsed;
                    cmbi_vkb.Visibility = Visibility.Collapsed;
                    cmbi_vb.Visibility = Visibility.Collapsed;
                    cmbi_pmb.Visibility = Visibility.Collapsed;
                    machtigingNmr = 1;
                    break;
            }
        }


        private void VeranderPagina()
        {
            string pagina = ((ComboBoxItem)cmb_pagina.SelectedItem).Content.ToString();

            switch (pagina)
            {
                case "Partijenbeheer":
                    PartijenBeheer partijenBeheer = new PartijenBeheer(machtigingNmr, IngelogdeUserId);
                    partijenBeheer.Top = this.Top;
                    partijenBeheer.Left = this.Left;
                    partijenBeheer.Height = this.Height;
                    partijenBeheer.Width = this.Width;
                    partijenBeheer.Show();
                    this.Close();
                    break;
                case "Verkiezingenbeheer":
                    Verkiezingenbeheer verkiezingenBeheer = new Verkiezingenbeheer(machtigingNmr, IngelogdeUserId);
                    verkiezingenBeheer.Top = this.Top;
                    verkiezingenBeheer.Left = this.Left;
                    verkiezingenBeheer.Height = this.Height;
                    verkiezingenBeheer.Width = this.Width;
                    verkiezingenBeheer.Show();
                    this.Close();
                    break;
                case "Vragenbeheer":
                    Vragenbeheer vragenBeheer = new Vragenbeheer(machtigingNmr, IngelogdeUserId);
                    vragenBeheer.Top = this.Top;
                    vragenBeheer.Left = this.Left;
                    vragenBeheer.Height = this.Height;
                    vragenBeheer.Width = this.Width;
                    vragenBeheer.Show();
                    this.Close();
                    break;
                case "PartijMeningenbeheer":
                    PartijMeningenBeheer partijenMeningenBeheer = new PartijMeningenBeheer(machtigingNmr, IngelogdeUserId);
                    partijenMeningenBeheer.Top = this.Top;
                    partijenMeningenBeheer.Left = this.Left;
                    partijenMeningenBeheer.Height = this.Height;
                    partijenMeningenBeheer.Width = this.Width;
                    partijenMeningenBeheer.Show();
                    this.Close();
                    break;
                case "Gebruikersbeheer":
                    MainWindow gebruikersBeheer = new MainWindow(machtigingNmr, IngelogdeUserId);
                    gebruikersBeheer.Top = this.Top;
                    gebruikersBeheer.Left = this.Left;
                    gebruikersBeheer.Height = this.Height;
                    gebruikersBeheer.Width = this.Width;
                    gebruikersBeheer.Show();
                    this.Close();
                    break;
            }
        }


    }
}