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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stemwijzer_v2
{
    /// <summary>
    /// Interaction logic for Gebruikersbeheer.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Users> alleGebruikers; // Alle originele gebruikers

        int Machtiging;
        int IngelogdeUserId;

        public MainWindow(int machtiging, int ingelogdeUserId)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            switch (machtiging)
            {
                case 3:
                    cmbi_gb.Visibility = Visibility.Collapsed;
                    cmbi_pb.Visibility = Visibility.Visible;
                    cmbi_vkb.Visibility = Visibility.Visible;
                    cmbi_vb.Visibility = Visibility.Visible;
                    cmbi_pmb.Visibility = Visibility.Collapsed; break;
                case 2:
                    cmbi_gb.Visibility = Visibility.Visible;
                    cmbi_pb.Visibility = Visibility.Collapsed;
                    cmbi_vkb.Visibility = Visibility.Collapsed;
                    cmbi_vb.Visibility = Visibility.Collapsed;
                    cmbi_pmb.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    cmbi_gb.Visibility = Visibility.Visible;
                    cmbi_pb.Visibility = Visibility.Collapsed;
                    cmbi_vkb.Visibility = Visibility.Collapsed;
                    cmbi_vb.Visibility = Visibility.Collapsed;
                    cmbi_pmb.Visibility = Visibility.Collapsed;

                    btn_verwijderen.IsEnabled = false;
                    btn_toevoegen.IsEnabled = false;
                    break;
            }

            Machtiging = machtiging;
            IngelogdeUserId = ingelogdeUserId;

        }


        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UsersDatabase database = new UsersDatabase();
            List<Users> users;
            try
            {
                users = await Task.Run(() => database.GetUsers());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van gebruikersgegevens. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            alleGebruikers = users;
            UpdateListBox();

            zoekbalk.TextChanged += (s, ev) => UpdateListBox();
            filter_gebruikersnaam.SelectionChanged += (s, ev) => UpdateListBox();
            filter_machtiging.SelectionChanged += (s, ev) => UpdateListBox();
            cmb_pagina.SelectionChanged += (s, ev) => VeranderPagina();
        }

        //foreach (var user in users)
        //{
        //    ListBoxItem userItem = new ListBoxItem();
        //    Grid grid = new Grid();
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });
        //    //grid.ShowGridLines = true;

        //    // CHATGPT stukje. word doc #1 ------------------------------------------------
        //    Binding binding = new Binding("ActualWidth");
        //    binding.ElementName = "lb_gebruikers";
        //    binding.Converter = (IValueConverter)this.FindResource("listboxLength");

        //    grid.SetBinding(FrameworkElement.WidthProperty, binding);
        //    //-----------------------------------------------------------------------------


        //    TextBlock tb_id = new TextBlock();
        //    tb_id.Tag = "id";
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_id.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_id.TextWrapping = TextWrapping.NoWrap;
        //    tb_id.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------
        //    TextBlock tb_gebruikersnaam = new TextBlock();
        //    tb_gebruikersnaam.Tag = "gebruikersnaam";
        //    tb_gebruikersnaam.Margin = new Thickness(10, 0, 0, 0);
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_gebruikersnaam.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_gebruikersnaam.TextWrapping = TextWrapping.NoWrap;
        //    tb_gebruikersnaam.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------
        //    TextBlock tb_email = new TextBlock();
        //    tb_email.Tag = "email";
        //    tb_email.Margin = new Thickness(10, 0, 0, 0);
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_email.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_email.TextWrapping = TextWrapping.NoWrap;
        //    tb_email.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------
        //    TextBlock tb_wachtwoord = new TextBlock();
        //    tb_wachtwoord.Tag = "wachtwoord";
        //    tb_wachtwoord.Margin = new Thickness(10, 0, 0, 0);
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_wachtwoord.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_wachtwoord.TextWrapping = TextWrapping.NoWrap;
        //    tb_wachtwoord.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------
        //    TextBlock tb_machtiging = new TextBlock();
        //    tb_machtiging.Tag = "machtiging";
        //    tb_machtiging.Margin = new Thickness(10, 0, 0, 0);
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_machtiging.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_machtiging.TextWrapping = TextWrapping.NoWrap;
        //    tb_machtiging.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------
        //    TextBlock tb_geboorte_datum = new TextBlock();
        //    tb_geboorte_datum.Tag = "account_bijgewerkt";
        //    tb_geboorte_datum.Margin = new Thickness(10, 0, 0, 0);
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_geboorte_datum.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_geboorte_datum.TextWrapping = TextWrapping.NoWrap;
        //    tb_geboorte_datum.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------
        //    TextBlock tb_account_bijgewerkt = new TextBlock();
        //    tb_account_bijgewerkt.Tag = "account_bijgewerkt";
        //    tb_account_bijgewerkt.Margin = new Thickness(10, 0, 0, 0);
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_account_bijgewerkt.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_account_bijgewerkt.TextWrapping = TextWrapping.NoWrap;
        //    tb_account_bijgewerkt.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------
        //    TextBlock tb_account_gemaakt = new TextBlock();
        //    tb_account_gemaakt.Tag = "account_gemaakt";
        //    tb_account_gemaakt.Margin = new Thickness(10, 0, 0, 0);
        //    // CHATGPT STUKJE. word doc #2 ---------------------------
        //    tb_account_gemaakt.TextTrimming = TextTrimming.CharacterEllipsis;
        //    tb_account_gemaakt.TextWrapping = TextWrapping.NoWrap;
        //    tb_account_gemaakt.VerticalAlignment = VerticalAlignment.Center;
        //    //--------------------------------------------------------

        //    tb_id.Text = user.Id.ToString();
        //    tb_gebruikersnaam.Text = user.Gebruikersnaam;
        //    tb_email.Text = user.Email;
        //    tb_wachtwoord.Text = user.Wachtwoord;
        //    tb_machtiging.Text = user.Machtiging;
        //    tb_geboorte_datum.Text = user.Geboorte_datum.ToString().Split(' ')[0];
        //    tb_account_bijgewerkt.Text = user.Account_bijgewerkt.ToString().Split(' ')[0];
        //    tb_account_gemaakt.Text = user.Account_gemaakt.ToString().Split(' ')[0];





        //    Grid.SetColumn(tb_id, 0);
        //    Grid.SetColumn(tb_gebruikersnaam, 1);
        //    Grid.SetColumn(tb_email, 2);
        //    Grid.SetColumn(tb_wachtwoord, 3);
        //    Grid.SetColumn(tb_machtiging, 4);
        //    Grid.SetColumn(tb_geboorte_datum, 5);
        //    Grid.SetColumn(tb_account_bijgewerkt, 6);
        //    Grid.SetColumn(tb_account_gemaakt, 7);


        //    grid.Children.Add(tb_id);
        //    grid.Children.Add(tb_gebruikersnaam);
        //    grid.Children.Add(tb_email);
        //    grid.Children.Add(tb_wachtwoord);
        //    grid.Children.Add(tb_machtiging);
        //    grid.Children.Add(tb_geboorte_datum);
        //    grid.Children.Add(tb_account_bijgewerkt);
        //    grid.Children.Add(tb_account_gemaakt);

        //    ListBoxItem laatsteitem = lb_gebruikers.Items.GetItemAt(lb_gebruikers.Items.Count - 1) as ListBoxItem;
        //    string laatstekleur = laatsteitem.Background.ToString();
        //    //MessageBox.Show(laatstekleur);
        //    if (laatstekleur == "#FFFFFFFF")
        //    {
        //        userItem.Background = new BrushConverter().ConvertFromString("#EDF2F4") as SolidColorBrush;
        //    } else
        //    {
        //        userItem.Background = Brushes.White;
        //    }

        //    userItem.Content = grid;

        //    lb_gebruikers.Items.Add(userItem);
        //}


        // chatgpt aanpassing word doc #5 ------------------------------------------------------------- 

        private void VeranderPagina()
        {
            string pagina = ((ComboBoxItem)cmb_pagina.SelectedItem).Content.ToString();

            switch (pagina)
            {
                case "Partijenbeheer":
                    PartijenBeheer partijenBeheer = new PartijenBeheer(Machtiging, IngelogdeUserId);
                    partijenBeheer.Top = this.Top;
                    partijenBeheer.Left = this.Left;
                    partijenBeheer.Height = this.Height;
                    partijenBeheer.Width = this.Width;
                    partijenBeheer.Show();
                    this.Close();
                    break;
                case "Verkiezingenbeheer":
                    Verkiezingenbeheer verkiezingenBeheer = new Verkiezingenbeheer(Machtiging, IngelogdeUserId);
                    verkiezingenBeheer.Top = this.Top;
                    verkiezingenBeheer.Left = this.Left;
                    verkiezingenBeheer.Height = this.Height;
                    verkiezingenBeheer.Width = this.Width;
                    verkiezingenBeheer.Show();
                    this.Close();
                    break;
                case "Vragenbeheer":
                    Vragenbeheer vragenBeheer = new Vragenbeheer(Machtiging, IngelogdeUserId);
                    vragenBeheer.Top = this.Top;
                    vragenBeheer.Left = this.Left;
                    vragenBeheer.Height = this.Height;
                    vragenBeheer.Width = this.Width;
                    vragenBeheer.Show();
                    this.Close();
                    break;
                case "PartijMeningenbeheer":
                    PartijMeningenBeheer partijenMeningenBeheer = new PartijMeningenBeheer(Machtiging, IngelogdeUserId);
                    partijenMeningenBeheer.Top = this.Top;
                    partijenMeningenBeheer.Left = this.Left;
                    partijenMeningenBeheer.Height = this.Height;
                    partijenMeningenBeheer.Width = this.Width;
                    partijenMeningenBeheer.Show();
                    this.Close();
                    break;
                case "Uitloggen":
                    InlogPagina inlogpagina = new InlogPagina();
                    inlogpagina.Top = this.Top;
                    inlogpagina.Left = this.Left;
                    inlogpagina.Height = this.Height;
                    inlogpagina.Width = this.Width;
                    inlogpagina.Show();
                    this.Close();
                    break;
            }
        }

        //--------------------------------------------------------------------------------------------------------------


        // chatgpt stuk word doc #3 -----------------------------------------------------------------------------------------------------------------

        private ListBoxItem MaakListBoxItem(Users user, bool isWhite)
        {
            ListBoxItem userItem = new ListBoxItem();
            Grid grid = new Grid();

            // Voeg kolommen toe
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });

            grid.ShowGridLines = true;

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_gebruikers";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            grid.SetBinding(FrameworkElement.WidthProperty, binding);

            void VoegTextToe(string inhoud, int kolom, string tag)
            {
                if (tag == "wachtwoord")
                {
                    int i = 0;
                    string inhoudOrigineel = inhoud;
                    inhoud = "";

                    foreach (char c in inhoudOrigineel)
                    {
                        if (i < 3)
                        {
                            inhoud += c;
                            i++;
                        }
                        else
                        {
                            inhoud = inhoud + "*";
                        }

                    }

                    TextBlock tb = new TextBlock
                    {
                        Text = inhoud,
                        Tag = tag,
                        Margin = new Thickness(10, 0, 0, 0),
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        TextWrapping = TextWrapping.NoWrap,
                        VerticalAlignment = VerticalAlignment.Center,
                    };
                    Grid.SetColumn(tb, kolom);
                    grid.Children.Add(tb);
                }
                else if (tag != "id")
                {
                    TextBlock tb = new TextBlock
                    {
                        Text = inhoud,
                        Tag = tag,
                        Margin = new Thickness(10, 0, 0, 0),
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        TextWrapping = TextWrapping.NoWrap,
                        VerticalAlignment = VerticalAlignment.Center,
                    };
                    Grid.SetColumn(tb, kolom);
                    grid.Children.Add(tb);
                }
                else
                {
                    TextBlock tb = new TextBlock
                    {
                        Text = inhoud,
                        Tag = tag,
                        Margin = new Thickness(0, 0, 0, 0),
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        TextWrapping = TextWrapping.NoWrap,
                        VerticalAlignment = VerticalAlignment.Center,
                        Visibility = Visibility.Collapsed
                    };
                    Grid.SetColumn(tb, kolom);
                    grid.Children.Add(tb);
                }
            }

            VoegTextToe(user.Gebruikersnaam, 0, "gebruikersnaam");
            VoegTextToe(user.Email, 1, "email");
            VoegTextToe(user.Wachtwoord, 2, "wachtwoord");
            VoegTextToe(user.Machtiging, 3, "machtiging");
            VoegTextToe(user.Geboorte_datum.ToString("yyyy-MM-dd"), 4, "geboorte_datum");
            VoegTextToe(user.Account_bijgewerkt.ToString("yyyy-MM-dd"), 5, "account_bijgewerkt");
            VoegTextToe(user.Account_gemaakt.ToString("yyyy-MM-dd"), 6, "account_gemaakt");
            VoegTextToe(user.Id.ToString(), 6, "id");

            userItem.Background = isWhite ? Brushes.White : new BrushConverter().ConvertFromString("#EDF2F4") as SolidColorBrush;
            userItem.Content = grid;

            return userItem;
        }




        private void UpdateListBox()
        {
            lb_gebruikers.Items.Clear();


            //CHAT GPT STUKJE word doc #4 ------------------------------------------------------------------------------------
            ListBoxItem headerItem = new ListBoxItem();
            Grid headerGrid = new Grid();
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.7, GridUnitType.Star) });

            headerGrid.ShowGridLines = true;

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_gebruikers";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            headerGrid.SetBinding(FrameworkElement.WidthProperty, binding);

            // Header-textblocks
            string[] headers = { "Gebruikersnaam", "Email", "Wachtwoord", "Machtiging", "Geboorte datum", "Account bijgewerkt", "Account gemaakt" };
            for (int i = 0; i < headers.Length; i++)
            {
                TextBlock tb = new TextBlock
                {
                    Text = headers[i],
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(10, 0, 0, 0),
                    Foreground = Brushes.DarkSlateGray,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                    TextWrapping = TextWrapping.NoWrap,
                };
                Grid.SetColumn(tb, i);
                headerGrid.Children.Add(tb);
            }

            headerItem.Content = headerGrid;
            headerItem.Background = Brushes.LightGray;
            headerItem.IsHitTestVisible = false; // maakt het niet-selecteerbaar
            lb_gebruikers.Items.Add(headerItem);

            //---------------------------------------------------------------------------------------------------

            string zoekterm = zoekbalk.Text.Trim().ToLower();
            string machtigingFilter = ((ComboBoxItem)filter_machtiging.SelectedItem).Content.ToString();
            string gebruikersnaamSort = ((ComboBoxItem)filter_gebruikersnaam.SelectedItem).Content.ToString();

            IEnumerable<Users> gefilterd = alleGebruikers;

            // Machtiging filter
            if (machtigingFilter != "Alles")
            {
                gefilterd = gefilterd.Where(u => u.Machtiging.ToLower() == machtigingFilter.ToLower());
            }

            // Zoekterm filter (op gebruikersnaam of email bijvoorbeeld)
            if (!string.IsNullOrEmpty(zoekterm))
                gefilterd = gefilterd.Where(u =>
                    u.Gebruikersnaam.ToLower().Contains(zoekterm) ||
                    u.Email.ToLower().Contains(zoekterm));

            // Sorteren op gebruikersnaam
            if (gebruikersnaamSort == "A-Z")
                gefilterd = gefilterd.OrderBy(u => u.Gebruikersnaam.ToLower());
            else if (gebruikersnaamSort == "Z-A")
                gefilterd = gefilterd.OrderByDescending(u => u.Gebruikersnaam.ToLower());

            bool white = true;

            foreach (var user in gefilterd)
            {
                var item = MaakListBoxItem(user, white);
                white = !white;
                lb_gebruikers.Items.Add(item);
            }
        }



        private async void btn_verwijderen_Click(object sender, RoutedEventArgs e)
        {


            if (lb_gebruikers.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een gebruiker om te verwijderen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int userId = 0;

            var listboxitem = lb_gebruikers.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out userId);
                    break;
                }
            }
            var result = MessageBox.Show("weet je zeker dat je dit wil verwijderen", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                UsersDatabase database = new UsersDatabase();
                try
                {
                    database.VerwijderUser(userId);
                }
                catch
                {
                    MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van de gebruiker. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                List<Users> gebruikers;
                try
                {
                    gebruikers = await Task.Run(() => database.GetUsers());
                    alleGebruikers = gebruikers;
                } catch
                {
                    MessageBox.Show("Er is een fout opgetreden bij het ophalen van gebruikersgegevens. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                UpdateListBox();
            }
        }

        private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (lb_gebruikers.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een gebruiker om aan te passen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int userId = 0;

            var listboxitem = lb_gebruikers.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out userId);
                    break;
                }
            }

            AanpassenPagina aanpassenPagina = new AanpassenPagina("users", userId, Machtiging, IngelogdeUserId);
            aanpassenPagina.ShowDialog();


            UsersDatabase database = new UsersDatabase();
            List<Users> gebruikers;
            try
            {
                gebruikers = await Task.Run(() => database.GetUsers());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van gebruikersgegevens. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            alleGebruikers = gebruikers;
            UpdateListBox();
        }

        private async void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            toevoegPagina toevoegenPagina = new toevoegPagina("users");
            toevoegenPagina.ShowDialog();

            UsersDatabase database = new UsersDatabase();
            List<Users> gebruikers;
            try
            {
                gebruikers = await Task.Run(() => database.GetUsers());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van gebruikersgegevens. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            alleGebruikers = gebruikers;
            UpdateListBox();
        }
        // -----------------------------------------------------------------------------------------------------------------------------------------
    }
}
