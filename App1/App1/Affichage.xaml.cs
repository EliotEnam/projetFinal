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
            int index = SingletonListe.getInstance().Liste.IndexOf(activite);
            string[] table = { activite.Nom, activite.IdActivite.ToString(), activite.IdCategorie.ToString(), activite.CoutOrgCli.ToString(), activite.CoutVentCli.ToString(), index.ToString() };

            ModActivite dialog = new ModActivite(table);
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Modifier";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            SingletonListe.getInstance().afficherActivites();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Activite activite = btn.DataContext as Activite;
            lvListe.SelectedItem = activite;
            SingletonListe.getInstance().supprimer(activite.IdActivite.ToString(),"supprimerActivite");
            SingletonListe.getInstance().afficherActivites();
        }
    }
}
