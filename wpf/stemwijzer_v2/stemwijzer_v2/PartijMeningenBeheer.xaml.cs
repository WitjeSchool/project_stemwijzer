using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Interaction logic for PartijMeningenBeheer.xaml
    /// </summary>
    public partial class PartijMeningenBeheer : Window
    {
        //private List<PartijMeningen> allePartijMeningen;

        //int Machtiging;
        //int IngelogdeUserId;

        public PartijMeningenBeheer(int machtiging, int ingelogdeUserId)
        {
            InitializeComponent();
            //Loaded += PartijMeningenbeheer_Loaded;


            //switch (machtiging)
            //{
            //    case 3:
            //        cmbi_gb.Visibility = Visibility.Collapsed;
            //        cmbi_pb.Visibility = Visibility.Visible;
            //        cmbi_vkb.Visibility = Visibility.Visible;
            //        cmbi_vb.Visibility = Visibility.Visible;
            //        cmbi_pmb.Visibility = Visibility.Visible;
            //        break;
            //    case 2:
            //        cmbi_gb.Visibility = Visibility.Visible;
            //        cmbi_pb.Visibility = Visibility.Collapsed;
            //        cmbi_vkb.Visibility = Visibility.Collapsed;
            //        cmbi_vb.Visibility = Visibility.Collapsed;
            //        cmbi_pmb.Visibility = Visibility.Collapsed;
            //        break;
            //    case 1:
            //        cmbi_gb.Visibility = Visibility.Visible;
            //        cmbi_pb.Visibility = Visibility.Collapsed;
            //        cmbi_vkb.Visibility = Visibility.Collapsed;
            //        cmbi_vb.Visibility = Visibility.Collapsed;
            //        cmbi_pmb.Visibility = Visibility.Collapsed;
            //        break;
            //}

            //Machtiging = machtiging;
            //IngelogdeUserId = ingelogdeUserId;


        }

        //private async void PartijMeningenbeheer_Loaded(object sender, RoutedEventArgs e)
        //{
        //    PartijMeningenDatabase database = new PartijMeningenDatabase();
        //    List<PartijMeningen> partijMeningen;
        //    try
        //    {
        //        partijMeningen = await Task.Run(() => database.GetPartijMeningen());
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijMeningen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }
        //    allePartijMeningen = partijMeningen;
        //    UpdateListBox();

        //    zoekbalk.TextChanged += (s, ev) => UpdateListBox();
        //    filter_mening.SelectionChanged += (s, ev) => UpdateListBox();
        //    cmb_pagina.SelectionChanged += (s, ev) => VeranderPagina();
        //}

        //private void VeranderPagina()
        //{
        //    string pagina = ((ComboBoxItem)cmb_pagina.SelectedItem).Content.ToString();

        //    switch (pagina)
        //    {
        //        case "Gebruikersbeheer":
        //            MainWindow gebruikersBeheer = new MainWindow(Machtiging, IngelogdeUserId);
        //            gebruikersBeheer.Top = this.Top;
        //            gebruikersBeheer.Left = this.Left;
        //            gebruikersBeheer.Height = this.Height;
        //            gebruikersBeheer.Width = this.Width;
        //            gebruikersBeheer.Show();
        //            this.Close();
        //            break;
        //        case "Verkiezingenbeheer":
        //            Verkiezingenbeheer verkiezingenBeheer = new Verkiezingenbeheer(Machtiging, IngelogdeUserId);
        //            verkiezingenBeheer.Top = this.Top;
        //            verkiezingenBeheer.Left = this.Left;
        //            verkiezingenBeheer.Height = this.Height;
        //            verkiezingenBeheer.Width = this.Width;
        //            verkiezingenBeheer.Show();
        //            this.Close();
        //            break;
        //        case "Vragenbeheer":
        //            Vragenbeheer vragenBeheer = new Vragenbeheer(Machtiging, IngelogdeUserId);
        //            vragenBeheer.Top = this.Top;
        //            vragenBeheer.Left = this.Left;
        //            vragenBeheer.Height = this.Height;
        //            vragenBeheer.Width = this.Width;
        //            vragenBeheer.Show();
        //            this.Close();
        //            break;
        //        case "Partijenbeheer":
        //            PartijenBeheer partijenBeheer = new PartijenBeheer(Machtiging, IngelogdeUserId);
        //            partijenBeheer.Top = this.Top;
        //            partijenBeheer.Left = this.Left;
        //            partijenBeheer.Height = this.Height;
        //            partijenBeheer.Width = this.Width;
        //            partijenBeheer.Show();
        //            this.Close();
        //            break;
        //        case "Uitloggen":
        //            InlogPagina inlogpagina = new InlogPagina();
        //            inlogpagina.Top = this.Top;
        //            inlogpagina.Left = this.Left;
        //            inlogpagina.Height = this.Height;
        //            inlogpagina.Width = this.Width;
        //            inlogpagina.Show();
        //            this.Close();
        //            break;
        //    }

        //}






        //private ListBoxItem MaakListBoxItem(PartijMeningen partijMening, bool isWhite)
        //{
        //    ListBoxItem partijMeningItem = new ListBoxItem();
        //    Grid grid = new Grid();
        //    grid.ShowGridLines = true;

        //    // Voeg kolommen toe
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

        //    Binding binding = new Binding("ActualWidth");
        //    binding.ElementName = "lb_partijMeningen";
        //    binding.Converter = (IValueConverter)this.FindResource("listboxLength");
        //    grid.SetBinding(FrameworkElement.WidthProperty, binding);

        //    void VoegTextToe(string inhoud, int kolom, string tag)
        //    {

        //        if (tag != "id")
        //        {
        //            TextBlock tb = new TextBlock
        //            {
        //                Text = inhoud,
        //                Tag = tag,
        //                Margin = new Thickness(10, 0, 0, 0),
        //                TextTrimming = TextTrimming.CharacterEllipsis,
        //                TextWrapping = TextWrapping.NoWrap,
        //                VerticalAlignment = VerticalAlignment.Center,
        //                HorizontalAlignment = HorizontalAlignment.Center,
        //                FontSize = 15,
        //            };
        //            Grid.SetColumn(tb, kolom);
        //            grid.Children.Add(tb);

        //        }
        //        else
        //        {
        //            TextBlock tb = new TextBlock
        //            {
        //                Text = inhoud,
        //                Tag = tag,
        //                Margin = new Thickness(0, 0, 0, 0),
        //                TextTrimming = TextTrimming.CharacterEllipsis,
        //                TextWrapping = TextWrapping.NoWrap,
        //                VerticalAlignment = VerticalAlignment.Center,
        //                Visibility = Visibility.Collapsed
        //            };
        //            Grid.SetColumn(tb, kolom);
        //            grid.Children.Add(tb);
        //        }
        //    }

        //    VoegTextToe(partijMening.PartijId.ToString(), 0, "partijId");
        //    VoegTextToe(partijMening.VraagId.ToString(), 1, "vraagId");
        //    VoegTextToe(partijMening.Mening, 2, "mening");
        //    VoegTextToe(partijMening.Id.ToString(), 2, "id");


        //    partijMeningItem.Background = isWhite ? Brushes.White : new BrushConverter().ConvertFromString("#EDF2F4") as SolidColorBrush;
        //    partijMeningItem.Content = grid;

        //    return partijMeningItem;
        //}




        //private void UpdateListBox()
        //{
        //    lb_partijMeningen.Items.Clear();


        //    //CHAT GPT STUKJE word doc #4 ------------------------------------------------------------------------------------
        //    ListBoxItem headerItem = new ListBoxItem();
        //    Grid headerGrid = new Grid();
        //    headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        //    headerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

        //    headerGrid.ShowGridLines = true;

        //    Binding binding = new Binding("ActualWidth");
        //    binding.ElementName = "lb_partijMeningen";
        //    binding.Converter = (IValueConverter)this.FindResource("listboxLength");
        //    headerGrid.SetBinding(FrameworkElement.WidthProperty, binding);

        //    // Header-textblocks
        //    string[] headers = { "Partij", "Vraag", "Mening" };
        //    for (int i = 0; i < headers.Length; i++)
        //    {
        //        TextBlock tb = new TextBlock
        //        {
        //            Text = headers[i],
        //            FontWeight = FontWeights.Bold,
        //            VerticalAlignment = VerticalAlignment.Center,
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //            Margin = new Thickness(10, 0, 0, 0),
        //            Foreground = Brushes.DarkSlateGray,
        //            TextTrimming = TextTrimming.CharacterEllipsis,
        //            TextWrapping = TextWrapping.NoWrap,

        //        };
        //        Grid.SetColumn(tb, i);
        //        headerGrid.Children.Add(tb);
        //    }

        //    headerItem.Content = headerGrid;
        //    headerItem.Background = Brushes.LightGray;
        //    headerItem.IsHitTestVisible = false; // maakt het niet-selecteerbaar
        //    lb_partijMeningen.Items.Add(headerItem);

        //    //---------------------------------------------------------------------------------------------------

        //    string zoekterm = zoekbalk.Text.Trim().ToLower();
        //    //string machtigingFilter = ((ComboBoxItem)filter_machtiging.SelectedItem).Content.ToString();
        //    string meningSort = ((ComboBoxItem)filter_mening.SelectedItem).Content.ToString();

        //    IEnumerable<PartijMeningen> gefilterd = allePartijMeningen;

            

        //    // Mening-tekst filter
        //    if (meningSort != "Geen filter")
        //    {
        //        gefilterd = gefilterd.Where(u => u.Mening.ToLower() == meningSort.ToLower());
        //    }

        //    bool white = true;

        //    foreach (var partijMening in gefilterd)
        //    {
        //        var item = MaakListBoxItem(partijMening, white);
        //        white = !white;
        //        lb_partijMeningen.Items.Add(item);
        //    }

        //}

        //private async void btn_verwijderen_Click(object sender, RoutedEventArgs e)
        //{
        //    if (lb_partijMeningen.SelectedItem == null)
        //    {
        //        MessageBox.Show("Selecteer een partij om te verwijderen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }


        //    int partijMeningId = 0;

        //    var listboxitem = lb_partijMeningen.SelectedItem as ListBoxItem;
        //    var grid = listboxitem.Content as Grid;
        //    var textblocks = grid.Children.OfType<TextBlock>().ToList();

        //    foreach (var tb in textblocks)
        //    {
        //        if (tb.Tag.ToString() == "id")
        //        {
        //            int.TryParse(tb.Text, out partijMeningId);
        //            break;
        //        }
        //    }
        //    var result = MessageBox.Show("weet je zeker dat je dit wil verwijderen", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //    if (result == MessageBoxResult.Yes)
        //    {
        //        PartijMeningenDatabase database = new PartijMeningenDatabase();
        //        try
        //        {
        //            database.VerwijderPartijMeningen(partijMeningId);
        //        }
        //        catch
        //        {
        //            MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van de partij. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return;
        //        }
        //        try
        //        {
        //            List<PartijMeningen> partijMeningen = await Task.Run(() => database.GetPartijMeningen());
        //            allePartijMeningen = partijMeningen;
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijMeningen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return;
        //        }
        //        UpdateListBox();
        //    }
        //}

        //private async void btn_aanpassen_Click(object sender, RoutedEventArgs e)
        //{
        //    if (lb_partijMeningen.SelectedItem == null)
        //    {
        //        MessageBox.Show("Selecteer een partij om aan te passen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }


        //    int partijId = 0;

        //    var listboxitem = lb_partijMeningen.SelectedItem as ListBoxItem;
        //    var grid = listboxitem.Content as Grid;
        //    var textblocks = grid.Children.OfType<TextBlock>().ToList();

        //    foreach (var tb in textblocks)
        //    {
        //        if (tb.Tag.ToString() == "id")
        //        {
        //            int.TryParse(tb.Text, out partijId);
        //            break;
        //        }
        //    }


        //    AanpassenPagina aanpassenPagina = new AanpassenPagina("partijMeningen", partijId, 0, IngelogdeUserId);
        //    aanpassenPagina.ShowDialog();


        //    PartijMeningenDatabase database = new PartijMeningenDatabase();
        //    try
        //    {
        //        List<PartijMeningen> partijMeningen = await Task.Run(() => database.GetPartijMeningen());
        //        allePartijMeningen = partijMeningen;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijMeningen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }
        //    UpdateListBox();
        //}

        //private async void btn_toevoegen_Click(object sender, RoutedEventArgs e)
        //{

        //    toevoegPagina toevoegenPagina = new toevoegPagina("partijMeningen");
        //    toevoegenPagina.ShowDialog();

        //    PartijMeningenDatabase database = new PartijMeningenDatabase();
        //    try
        //    {
        //        List<PartijMeningen> partijMeningen = await Task.Run(() => database.GetPartijMeningen());
        //        allePartijMeningen = partijMeningen;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Er is een fout opgetreden bij het ophalen van partijMeningen. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }
        //    UpdateListBox();

        //}
    }
}
