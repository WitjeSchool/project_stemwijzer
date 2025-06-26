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
    /// Interaction logic for Verkiezingenbeheer.xaml
    /// </summary>
    public partial class Verkiezingenbeheer : Window
    {

        private List<Verkiezingen> alleVerkiezingen;

        int Machtiging;
        int IngelogdeUserId;

        public Verkiezingenbeheer(int machtiging, int ingelogdeUserId)
        {
            InitializeComponent();
            Loaded += Verkiezingenbeheer_Loaded;


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
                    break;
            }

            Machtiging = machtiging;
            IngelogdeUserId = ingelogdeUserId;


        }

        private async void Verkiezingenbeheer_Loaded(object sender, RoutedEventArgs e)
        {
            VerkiezingenDatabase database = new VerkiezingenDatabase();
            try
            {
                List<Verkiezingen> verkiezingen = await Task.Run(() => database.GetVerkiezingen());
                alleVerkiezingen = verkiezingen;
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de verkiezingen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();

            zoekbalk.TextChanged += (s, ev) => UpdateListBox();
            filter_titel.SelectionChanged += (s, ev) => UpdateListBox();
            filter_datum.SelectionChanged += (s, ev) => UpdateListBox();
            cmb_pagina.SelectionChanged += (s, ev) => VeranderPagina();
        }

        private void VeranderPagina()
        {
            string pagina = ((ComboBoxItem)cmb_pagina.SelectedItem).Content.ToString();

            switch (pagina)
            {
                case "Gebruikersbeheer":
                    MainWindow gebruikersBeheer = new MainWindow(Machtiging, IngelogdeUserId);
                    gebruikersBeheer.Top = this.Top;
                    gebruikersBeheer.Left = this.Left;
                    gebruikersBeheer.Height = this.Height;
                    gebruikersBeheer.Width = this.Width;
                    gebruikersBeheer.Show();
                    this.Close();
                    break;
                case "Partijenbeheer":
                    PartijenBeheer partijenBeheer = new PartijenBeheer(Machtiging, IngelogdeUserId);
                    partijenBeheer.Top = this.Top;
                    partijenBeheer.Left = this.Left;
                    partijenBeheer.Height = this.Height;
                    partijenBeheer.Width = this.Width;
                    partijenBeheer.Show();
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









        private ListBoxItem MaakListBoxItem(Verkiezingen verkiezing, bool isWhite)
        {
            ListBoxItem verkiezingItem = new ListBoxItem();
            Grid grid = new Grid();

            // Voeg kolommen toe
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            grid.ShowGridLines = true;

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_verkiezingen";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            grid.SetBinding(FrameworkElement.WidthProperty, binding);

            void VoegTextToe(string inhoud, int kolom, string tag)
            {
                if (tag != "id" && tag != "beschrijving")
                {
                    TextBlock tb = new TextBlock
                    {
                        Text = inhoud,
                        Tag = tag,
                        Margin = new Thickness(10, 0, 0, 0),
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        TextWrapping = TextWrapping.NoWrap,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    Grid.SetColumn(tb, kolom);
                    grid.Children.Add(tb);
                }
                else if (tag == "beschrijving")
                {
                    TextBlock tb = new TextBlock
                    {
                        Text = inhoud,
                        Tag = tag,
                        Margin = new Thickness(10, 0, 0, 0),
                        TextWrapping = TextWrapping.Wrap,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
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

            VoegTextToe(verkiezing.Titel, 0, "titel");
            VoegTextToe(verkiezing.Beschrijving, 1, "beschrijving");
            VoegTextToe(verkiezing.Start_datum.ToString(), 2, "start_datum");
            VoegTextToe(verkiezing.Eind_datum.ToString(), 3, "eind_datum");
            VoegTextToe(verkiezing.Id.ToString(), 3, "id");

            verkiezingItem.Background = isWhite ? Brushes.White : new BrushConverter().ConvertFromString("#EDF2F4") as SolidColorBrush;
            verkiezingItem.Content = grid;

            return verkiezingItem;
        }




        private void UpdateListBox()
        {
            lb_verkiezingen.Items.Clear();


            //CHAT GPT STUKJE word doc #4 ------------------------------------------------------------------------------------
            ListBoxItem headerItem = new ListBoxItem();
            Grid headerGrid = new Grid();
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            headerGrid.ShowGridLines = true;

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_verkiezingen";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            headerGrid.SetBinding(FrameworkElement.WidthProperty, binding);

            // Header-textblocks
            string[] headers = { "Titel", "Beschrijving", "Start datum", "Eind datum" };
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
            lb_verkiezingen.Items.Add(headerItem);

            //---------------------------------------------------------------------------------------------------

            string zoekterm = zoekbalk.Text.Trim().ToLower();
            //string machtigingFilter = ((ComboBoxItem)filter_machtiging.SelectedItem).Content.ToString();
            string titelSort = ((ComboBoxItem)filter_titel.SelectedItem).Content.ToString();
            string datumSort = ((ComboBoxItem)filter_datum.SelectedItem).Content.ToString();

            IEnumerable<Verkiezingen> gefilterd = alleVerkiezingen;

            // Machtiging filter
            //if (machtigingFilter != "Alles")
            //    gefilterd = gefilterd.Where(u => u.Machtiging.ToLower() == machtigingFilter.ToLower());

            // Zoekterm filter (op gebruikersnaam of email bijvoorbeeld)
            if (!string.IsNullOrEmpty(zoekterm))
                gefilterd = gefilterd.Where(u =>
                    u.Titel.ToLower().Contains(zoekterm));

            // Sorteren op gebruikersnaam
            if (titelSort == "A-Z")
                gefilterd = gefilterd.OrderBy(u => u.Titel.ToLower());
            else if (titelSort == "Z-A")
                gefilterd = gefilterd.OrderByDescending(u => u.Titel.ToLower());

            switch (datumSort)
            {
                case "start eerst/laatst":
                    gefilterd = gefilterd.OrderBy(v => v.Start_datum);
                    break;
                case "start laatst/eerst":
                    gefilterd = gefilterd.OrderByDescending(v => v.Start_datum);
                    break;
                case "eind eerst/laatst":
                    gefilterd = gefilterd.OrderBy(v => v.Eind_datum);
                    break;
                case "eind laatst/eerst":
                    gefilterd = gefilterd.OrderByDescending(v => v.Eind_datum);
                    break;
            }

            bool white = true;

            foreach (var verkiezing in gefilterd)
            {
                var item = MaakListBoxItem(verkiezing, white);
                white = !white;
                lb_verkiezingen.Items.Add(item);
            }
        }

        private async void btn_verwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lb_verkiezingen.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een verkiezing om te verwijderen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int verkiezingId = 0;

            var listboxitem = lb_verkiezingen.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out verkiezingId);
                    break;
                }
            }
            var result = MessageBox.Show("weet je zeker dat je dit wil verwijderen", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                VerkiezingenDatabase database = new VerkiezingenDatabase();
                try
                {
                    database.VerwijderVerkiezing(verkiezingId);
                }
                catch
                {
                    MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van de verkiezing. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    List<Verkiezingen> verkiezingen = await Task.Run(() => database.GetVerkiezingen());
                    alleVerkiezingen = verkiezingen;
                }
                catch
                {
                    MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de verkiezingen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                UpdateListBox();
            }
        }

        private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (lb_verkiezingen.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een partij om aan te passen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int verkiezingId = 0;

            var listboxitem = lb_verkiezingen.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out verkiezingId);
                    break;
                }
            }


            AanpassenPagina aanpassenPagina = new AanpassenPagina("verkiezingen", verkiezingId, 0, IngelogdeUserId);
            aanpassenPagina.ShowDialog();


            VerkiezingenDatabase database = new VerkiezingenDatabase();
            try
            {
                List<Verkiezingen> verkiezingen = await Task.Run(() => database.GetVerkiezingen());
                alleVerkiezingen = verkiezingen;
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de verkiezingen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();
        }

        private async void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {

            toevoegPagina toevoegenPagina = new toevoegPagina("verkiezingen");
            toevoegenPagina.ShowDialog();

            VerkiezingenDatabase database = new VerkiezingenDatabase();
            try
            {
                List<Verkiezingen> verkiezingen = await Task.Run(() => database.GetVerkiezingen());
                alleVerkiezingen = verkiezingen;
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de verkiezingen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();

        }
    }
}
