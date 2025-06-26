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
    /// Interaction logic for LogoToevoegenPagina.xaml
    /// </summary>
    public partial class LogoToevoegenPagina : Window
    {

        string file = "";

        public LogoToevoegenPagina()
        {
            InitializeComponent();
        }

        private void btn_kiesBestand_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files |*.jpg;*.jpeg;*.png",
                Title = "Kies een logo"
            };
            if (dialog.ShowDialog() == true)
            {
                if (dialog.FileName.EndsWith(".jpg") || dialog.FileName.EndsWith(".jpeg") || dialog.FileName.EndsWith(".png"))
                {
                    img_bestandPreview.Visibility = Visibility.Visible;
                    img_bestandPreview.Source = new BitmapImage(new Uri(dialog.FileName));

                    tb_bestandPath.Visibility = Visibility.Visible;
                    tb_bestandPath.Text = "pad: " + dialog.FileName;

                    file = dialog.FileName;
                }
                else
                {
                    MessageBox.Show("Selecteer een geldig afbeeldingsbestand (.jpg, .jpeg, .png).", "Ongeldig bestand", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btn_voltooien_Click(object sender, RoutedEventArgs e)
        {


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


            if (tb_afbNaam.Text.Replace(" ", "") == "" || tb_afbNaam.Text.Length <= 1 || verbodenTekens.Any(t => tb_afbNaam.Text.Contains(t)))
            {
                MessageBox.Show("Voer een (geldige) naam in voor de afbeelding.", "Geen (geldige) naam opgegeven", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (string item in files)
            {
                if (item.ToLower().Contains(tb_afbNaam.Text.Replace(" ", "").ToLower()))
                {
                    MessageBox.Show("Deze naam is al in gebruik. Kies een andere naam.", "Naam al in gebruik", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            try
            {
                File.Copy(file, $"..\\..\\PartijLogos\\{tb_afbNaam.Text.Trim().Replace(" ", "")}.{file.Split('.').Last()}", false);
            }
            catch
            {
                MessageBox.Show($"Er is een fout opgetreden bij opslaan van het bestand. Probeer het opnieuw of bel een service medewerker om het probleem op te lossen. 0612345678", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Close();
        }

        private void btn_annuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
