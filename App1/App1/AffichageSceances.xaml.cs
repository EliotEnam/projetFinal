using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AffichageSceances : Page
    {
        public AffichageSceances()
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = (SingletonListe.getInstance().afficherSceances());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Sceance sceance = btn.DataContext as Sceance;
            lv_liste.SelectedItem = sceance;
            string[] table = { sceance.IdSce.ToString(), sceance.Date, sceance.Heure, sceance.Nbplace.ToString()};

            ModSceance dialog = new ModSceance(table);
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Modifier";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            lv_liste.ItemsSource = SingletonListe.getInstance().afficherSceances();
        }

        private async void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Sceance sceance = btn.DataContext as Sceance;
            lv_liste.SelectedItem = sceance;
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Mon titre";
            dialog.PrimaryButtonText = "Oui";
            dialog.SecondaryButtonText = "Non";
            dialog.DefaultButton = ContentDialogButton.Secondary;
            dialog.Content = $"Êtes-vous sûr de vouloir suprimer la scéance du {sceance.Date} de l'activité {SingletonListe.getInstance().getNomActivite(sceance.IdAct)} ?";

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                SingletonListe.getInstance().supprimer(sceance.IdSce.ToString(), "supprimerSceance");
                lv_liste.ItemsSource = (SingletonListe.getInstance().afficherSceances());
            }
        }
    }
}
