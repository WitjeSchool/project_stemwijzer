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
    /// Interaction logic for PartijenBeheer.xaml
    /// </summary>
    public partial class PartijenBeheer : Window
    {

        private List<Partijen> allePartijen;

        int Machtiging;
        int IngelogdeUserId;

        public PartijenBeheer(int machtiging, int ingelogdeUserId)
        {
            InitializeComponent();
            Loaded += Partijenbeheer_Loaded;


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

        private async void Partijenbeheer_Loaded(object sender, RoutedEventArgs e)
        {
            PartijenDatabase database = new PartijenDatabase();
            List<Partijen> partijen;
            try
            {
                partijen = await Task.Run(() => database.GetPartijen());
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            allePartijen = partijen;
            UpdateListBox();

            zoekbalk.TextChanged += (s, ev) => UpdateListBox();
            filter_naam.SelectionChanged += (s, ev) => UpdateListBox();
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






        private ListBoxItem MaakListBoxItem(Partijen partij, bool isWhite)
        {
            ListBoxItem partijItem = new ListBoxItem();
            Grid grid = new Grid();
            grid.ShowGridLines = true;

            // Voeg kolommen toe
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_partijen";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            grid.SetBinding(FrameworkElement.WidthProperty, binding);

            void VoegTextToe(string inhoud, int kolom, string tag)
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
                    FontSize = 15,
                };
                Grid.SetColumn(tb, kolom);
                grid.Children.Add(tb);
            }
            VoegTextToe(partij.Id.ToString(), 0, "id");
            VoegTextToe(partij.Naam, 1, "naam");
            VoegTextToe(partij.Contact, 2, "contact");
            if (partij.Logo != "")
            {
                BitmapImage bitmap = new BitmapImage();
                try
                {
                    using (FileStream stream = new FileStream(partij.Logo, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad; // belangrijk!
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                    }
                    bitmap.Freeze();

                    Image img = new Image
                    {
                        Source = bitmap,
                        Width = 100,
                        Height = 100,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(10, 0, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    Grid.SetColumn(img, 3);
                    grid.Children.Add(img);
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden bij het laden van het logo. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678");
                }



            }
            else
            {
                VoegTextToe("Er is geen logo gevonden", 3, "Logo");
            }


            partijItem.Background = isWhite ? Brushes.White : new BrushConverter().ConvertFromString("#EDF2F4") as SolidColorBrush;
            partijItem.Content = grid;

            return partijItem;
        }




        private void UpdateListBox()
        {
            lb_partijen.Items.Clear();


            //CHAT GPT STUKJE word doc #4 ------------------------------------------------------------------------------------
            ListBoxItem headerItem = new ListBoxItem();
            Grid headerGrid = new Grid();
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });

            headerGrid.ShowGridLines = true;

            Binding binding = new Binding("ActualWidth");
            binding.ElementName = "lb_partijen";
            binding.Converter = (IValueConverter)this.FindResource("listboxLength");
            headerGrid.SetBinding(FrameworkElement.WidthProperty, binding);

            // Header-textblocks
            string[] headers = { "Id", "Naam", "Contact", "Logo" };
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
            lb_partijen.Items.Add(headerItem);

            //---------------------------------------------------------------------------------------------------

            string zoekterm = zoekbalk.Text.Trim().ToLower();
            //string machtigingFilter = ((ComboBoxItem)filter_machtiging.SelectedItem).Content.ToString();
            string naamSort = ((ComboBoxItem)filter_naam.SelectedItem).Content.ToString();

            IEnumerable<Partijen> gefilterd = allePartijen;

            //// Machtiging filter
            //if (machtigingFilter != "Alles")
            //{
            //    gefilterd = gefilterd.Where(u => u.Machtiging.ToLower() == machtigingFilter.ToLower());
            //}

            // Zoekterm filter (op gebruikersnaam of email bijvoorbeeld)
            if (!string.IsNullOrEmpty(zoekterm))
                gefilterd = gefilterd.Where(u =>
                    u.Naam.ToLower().Contains(zoekterm) ||
                    u.Contact.ToLower().Contains(zoekterm));

            // Sorteren op gebruikersnaam
            if (naamSort == "A-Z")
                gefilterd = gefilterd.OrderBy(u => u.Naam.ToLower());
            else if (naamSort == "Z-A")
                gefilterd = gefilterd.OrderByDescending(u => u.Naam.ToLower());

            bool white = true;

            foreach (var partij in gefilterd)
            {
                var item = MaakListBoxItem(partij, white);
                white = !white;
                lb_partijen.Items.Add(item);
            }
        }

        private async void btn_verwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lb_partijen.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een partij om te verwijderen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int partijId = 0;

            var listboxitem = lb_partijen.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out partijId);
                    break;
                }
            }
            var result = MessageBox.Show("weet je zeker dat je dit wil verwijderen", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                PartijenDatabase database = new PartijenDatabase();
                try
                {
                    database.VerwijderPartij(partijId);
                }
                catch
                {
                    MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van de partij. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    List<Partijen> partijen = await Task.Run(() => database.GetPartijen());
                    allePartijen = partijen;
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                UpdateListBox();
            }
        }

        private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (lb_partijen.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een partij om aan te passen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int partijId = 0;

            var listboxitem = lb_partijen.SelectedItem as ListBoxItem;
            var grid = listboxitem.Content as Grid;
            var textblocks = grid.Children.OfType<TextBlock>().ToList();

            foreach (var tb in textblocks)
            {
                if (tb.Tag.ToString() == "id")
                {
                    int.TryParse(tb.Text, out partijId);
                    break;
                }
            }


            AanpassenPagina aanpassenPagina = new AanpassenPagina("partijen", partijId, 0, IngelogdeUserId);
            aanpassenPagina.ShowDialog();


            PartijenDatabase database = new PartijenDatabase();
            try
            {
                List<Partijen> partijen = await Task.Run(() => database.GetPartijen());
                allePartijen = partijen;
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();
        }

        private async void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        {

            toevoegPagina toevoegenPagina = new toevoegPagina("partijen");
            toevoegenPagina.ShowDialog();

            PartijenDatabase database = new PartijenDatabase();
            try
            {
                List<Partijen> partijen = await Task.Run(() => database.GetPartijen());
                allePartijen = partijen;
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateListBox();

        }
    }
}
