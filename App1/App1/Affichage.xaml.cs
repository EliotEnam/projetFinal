using Microsoft.UI;
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
using System.Diagnostics;
using System.Drawing;
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
    public sealed partial class Affichage : Page
    {
        int _id =0;
        public Affichage()
        {
 
            this.InitializeComponent();
            SingletonListe.getInstance().afficherActivites();
            lvListe.ItemsSource = SingletonListe.getInstance().Liste;
        }

        private async void ajoutActivite_Click(object sender, RoutedEventArgs e)
        {
            AjoutActiviteDialog dialog = new AjoutActiviteDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            SingletonListe.getInstance().afficherActivites();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Activite activite = btn.DataContext as Activite;
            lvListe.SelectedItem = activite;
            string nomCat = SingletonListe.getInstance().getNomCategorie(activite.IdCategorie);
            string[] table = { activite.Nom, activite.IdActivite.ToString(), activite.IdCategorie.ToString(), activite.CoutOrgCli.ToString(), activite.CoutVentCli.ToString(), nomCat };

            ModActivite dialog = new ModActivite(table);
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Modifier";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            SingletonListe.getInstance().afficherActivites();

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Activite activite = btn.DataContext as Activite;
            lvListe.SelectedItem = activite;
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Mon titre";
            dialog.PrimaryButtonText = "Oui";
            dialog.SecondaryButtonText = "Non";
            dialog.DefaultButton = ContentDialogButton.Secondary;
            dialog.Content = $"Êtes-vous sûr de vouloir l'activite {activite.Nom}\n et sa/ses {activite.NbSceance} sceance(s) ?";

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                SingletonListe.getInstance().supprimer(activite.IdActivite.ToString(), "supprimerActivite");
                SingletonListe.getInstance().afficherActivites();
            }
               
        }

   

        private void btn_sce_Click(object sender, RoutedEventArgs e)
        {
            stack_activ.Visibility = Visibility.Visible;
            stack_sce.Visibility = Visibility.Collapsed;
            SingletonListe.getInstance().afficherActivites();
            lvListe.ItemsSource = SingletonListe.getInstance().Liste;

        }

        private async void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Sceance sceance = btn.DataContext as Sceance;
            lv_liste.SelectedItem = sceance;
            string[] table = { sceance.IdSce.ToString(), sceance.Date, sceance.Heure, sceance.Nbplace.ToString() };

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
                lv_liste.ItemsSource = SingletonListe.getInstance().afficherSeancesParActiv(_id);
            }
               
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Activite activite = btn.DataContext as Activite;
            lvListe.SelectedItem = activite;
            _id = activite.IdActivite;
            lv_liste.ItemsSource = SingletonListe.getInstance().afficherSeancesParActiv(activite.IdActivite);
            stack_activ.Visibility = Visibility.Collapsed;
            stack_sce.Visibility = Visibility.Visible;
  
        }
    }
}
