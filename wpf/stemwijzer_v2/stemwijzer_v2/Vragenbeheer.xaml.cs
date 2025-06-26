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
    /// Interaction logic for Vragenbeheer.xaml
    /// </summary>
    public partial class Vragenbeheer : Window
    {

        private List<Vragen> alleVragen;

        int Machtiging;
        int IngelogdeUserId;

        public Vragenbeheer(int machtiging, int ingelogdeUserId)
        {
            InitializeComponent();
            Loaded += Vragenbeheer_Loaded;


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

        private async void Vragenbeheer_Loaded(object sender, RoutedEventArgs e)
        {
            VragenDatabase database = new VragenDatabase();
            try
            {
                List<Vragen> vragen = await Task.Run(() => database.GetVragen());
                alleVragen = vragen;
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de vragen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();

            zoekbalk.TextChanged += (s, ev) => UpdateListBox();
            cmb_pagina.SelectionChanged += (s, ev) => VeranderPagina();
            filter_id.SelectionChanged += (s, ev) => UpdateListBox();
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
                case "Verkiezingenbeheer":
                    Verkiezingenbeheer verkiezingenBeheer = new Verkiezingenbeheer(Machtiging, IngelogdeUserId);
                    verkiezingenBeheer.Top = this.Top;
                    verkiezingenBeheer.Left = this.Left;
                    verkiezingenBeheer.Height = this.Height;
                    verkiezingenBeheer.Width = this.Width;
                    verkiezingenBeheer.Show();
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






        private ListBoxItem MaakListBoxItem(Vragen vraag, bool isWhite)
        {
            ListBoxItem vraagItem = new ListBoxItem();
            Grid grid = new Grid();
            grid.ShowGridLines = true;

            // Voeg kolommen toe
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_vragen";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            grid.SetBinding(FrameworkElement.WidthProperty, binding);

            void VoegTextToe(string inhoud, int kolom, string tag)
            {


                TextBlock tb = new TextBlock
                {
                    Text = inhoud,
                    Tag = tag,
                    Margin = new Thickness(10, 0, 0, 0),
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 15,
                };
                Grid.SetColumn(tb, kolom);
                grid.Children.Add(tb);
            }

            VoegTextToe(vraag.Id.ToString(), 0, "id");
            VoegTextToe(vraag.Verkiezing, 1, "verkiezing");
            VoegTextToe(vraag.Vraag, 2, "vraag");

            vraagItem.Background = isWhite ? Brushes.White : new BrushConverter().ConvertFromString("#EDF2F4") as SolidColorBrush;
            vraagItem.Content = grid;

            return vraagItem;
        }




        private void UpdateListBox()
        {
            lb_vragen.Items.Clear();


            //CHAT GPT STUKJE word doc #4 ------------------------------------------------------------------------------------
            ListBoxItem headerItem = new ListBoxItem();
            Grid headerGrid = new Grid();
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });

            headerGrid.ShowGridLines = true;

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_vragen";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            headerGrid.SetBinding(FrameworkElement.WidthProperty, binding);

            // Header-textblocks
            string[] headers = { "Id", "Verkiezing", "Vraag" };
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
            lb_vragen.Items.Add(headerItem);

            //---------------------------------------------------------------------------------------------------

            string zoekterm = zoekbalk.Text.Trim().ToLower();
            string idSort = ((ComboBoxItem)filter_id.SelectedItem).Content.ToString();
            //string machtigingFilter = ((ComboBoxItem)filter_machtiging.SelectedItem).Content.ToString();
            //string naamSort = ((ComboBoxItem)filter_naam.SelectedItem).Content.ToString();

            IEnumerable<Vragen> gefilterd = alleVragen;

            //// Machtiging filter
            //if (machtigingFilter != "Alles")
            //{
            //    gefilterd = gefilterd.Where(u => u.Machtiging.ToLower() == machtigingFilter.ToLower());
            //}

            // Zoekterm filter (op gebruikersnaam of email bijvoorbeeld)
            if (!string.IsNullOrEmpty(zoekterm))
                gefilterd = gefilterd.Where(u =>
                    u.Vraag.ToLower().Contains(zoekterm) ||
                    u.Id.ToString().Contains(zoekterm));

            // Sorteren op gebruikersnaam
            //if (naamSort == "A-Z")
            //    gefilterd = gefilterd.OrderBy(u => u.Naam.ToLower());
            //else if (naamSort == "Z-A")
            //    gefilterd = gefilterd.OrderByDescending(u => u.Naam.ToLower());


            if (idSort == "Oplopend")
                gefilterd = gefilterd.OrderBy(u => u.Id);
            else if (idSort == "Aflopend")
                gefilterd = gefilterd.OrderByDescending(u => u.Id);


            bool white = true;

            foreach (var vraag in gefilterd)
            {
                var item = MaakListBoxItem(vraag, white);
                white = !white;
                lb_vragen.Items.Add(item);
            }
        }

        private async void btn_verwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lb_vragen.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een vraag om te verwijderen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int vraagId = 0;

            var listboxitem = lb_vragen.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out vraagId);
                    break;
                }
            }
            var result = MessageBox.Show("weet je zeker dat je dit wil verwijderen", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                VragenDatabase database = new VragenDatabase();
                try
                {
                    database.VerwijderVraag(vraagId);
                }
                catch
                {
                    MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van de vraag. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    List<Vragen> vragen = await Task.Run(() => database.GetVragen());
                    alleVragen = vragen;
                }
                catch
                {
                    MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de vragen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                UpdateListBox();
            }
        }

        private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (lb_vragen.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een vraag om aan te passen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int vraagId = 0;

            var listboxitem = lb_vragen.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out vraagId);
                    break;
                }
            }


            AanpassenPagina aanpassenPagina = new AanpassenPagina("vragen", vraagId, 0, IngelogdeUserId);
            aanpassenPagina.ShowDialog();


            VragenDatabase database = new VragenDatabase();
            try
            {
                List<Vragen> vragen = await Task.Run(() => database.GetVragen());
                alleVragen = vragen;
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de vragen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();
        }

        private async void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {
            toevoegPagina toevoegenPagina = new toevoegPagina("vragen");
            toevoegenPagina.ShowDialog();

            VragenDatabase database = new VragenDatabase();
            try
            {
                List<Vragen> vragen = await Task.Run(() => database.GetVragen());
                alleVragen = vragen;
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de vragen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();
        }
    }
}
