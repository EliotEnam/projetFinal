using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Statistiques : Page
    {
        public Statistiques()
        {
            this.InitializeComponent();
            SingletonListe.getInstance().afficherActivites();
            lv_liste.ItemsSource = SingletonListe.getInstance().Liste;
            tbl_benefice_moyen.Text = $"Le bénéfice moyen par activité est de {SingletonListe.getInstance().vues("benefice_moyen")}$" ;
            tbl_prix_moyen.Text = $"Le prix moyen par activité est de {SingletonListe.getInstance().vues("prix_moyen")}$";
            tbl_note_moyenne_toute_activ.Text = $"La note moyenne d'une activité est de {SingletonListe.getInstance().vues("moyenne_note_appreciation_activite")}";
            tbl_nbr_activ.Text = $"{SingletonListe.getInstance().vues("nbr_activ")} activités";
            tbl_nbr_adherent.Text = $"{SingletonListe.getInstance().vues("nbr_adher")} adhérents";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var window = App.MainWindow;
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "Activites";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();



            List<Activite> liste = new List<Activite>();
            liste.AddRange(SingletonListe.getInstance().Liste);



            // La fonction ToString de la classe Client retourne: nom + ";" + prenom
            if (monFichier != null)
                await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
            SingletonListe.getInstance().afficherActivites();
            lv_liste.ItemsSource = SingletonListe.getInstance().Liste;

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var window = App.MainWindow;
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "Adherents";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();



            List<Adherent> liste = new List<Adherent>();
            liste.AddRange(SingletonListe.getInstance().afficherAdherents());



            // La fonction ToString de la classe Client retourne: nom + ";" + prenom
            if (monFichier != null)
                await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
            SingletonListe.getInstance().afficherActivites();
            lv_liste.ItemsSource = SingletonListe.getInstance().Liste;
        }
    }
}
