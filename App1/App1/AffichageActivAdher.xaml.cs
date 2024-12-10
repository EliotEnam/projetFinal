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
    public sealed partial class AffichageActivAdher : Page
    {
        public AffichageActivAdher()
        {
            this.InitializeComponent();
            SingletonListe.getInstance().afficherActivites();
            lvListe.ItemsSource = SingletonListe.getInstance().Liste;
          
            //SingletonListe.getInstance().ListeActivite(cbx_activ);
        }

        //private void cbx_activ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //int id = SingletonListe.getInstance().getIdActivite(cbx_activ.SelectedValue.ToString());
        //    //lv_liste.ItemsSource = SingletonListe.getInstance().afficherSeancesParActiv(id);
        //}

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if(cbx_oui_non.SelectedValue.ToString() == "Non")
        //    {
        //        stack_activ.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        stack_activ.Visibility = Visibility.Visible;
        //    }

        //}

        private async void btn_inscription_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Sceance sceance = btn.DataContext as Sceance;
            lv_liste.SelectedItem = sceance;
            DateTime dateAuj = DateTime.Now;
            DateTime dateSceance = DateTime.Parse(sceance.Date.ToString());
            if(SessionUsager.IdAdherent == null)
            {

                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "J'ai compris";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = $"Veuillez-vous connecter";

                ContentDialogResult result = await dialog.ShowAsync();
          
            }
            else if(sceance.Nbplace == 0)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "J'ai compris";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = $"Il n'y a plus de place disponible pour cette scéance. Veuillez-en choisir une autre";

                ContentDialogResult result = await dialog.ShowAsync();
            }
            else if ((dateSceance.Date < dateAuj.Date))
            {
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "Je comprends";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = $"Cette scéance a deja eu lieu";

                ContentDialogResult result = await dialog.ShowAsync();
            }
            else if (SingletonListe.getInstance().adherenDejaParticip(SessionUsager.IdAdherent, sceance.IdAct) == "OUI")
            {

                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "Je comprends";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = $"Vous êtes déja inscrit à cette activité";

                ContentDialogResult result = await dialog.ShowAsync();
            }
            else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "Je le confirme";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = $"Confirmez votre inscription à la scéance du {sceance.Date} \n à {sceance.Heure.Substring(0, 2)}H";

                ContentDialogResult result = await dialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    SingletonListe.getInstance().ajoutParticipSceance(sceance.IdSce, SessionUsager.IdAdherent);
                }
            }
        }

        private void lvListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
     
            if(lvListe.SelectedItem != null)
            {
                Activite activite = lvListe.SelectedItem as Activite;
                lv_liste.ItemsSource = SingletonListe.getInstance().afficherSeancesParActiv(activite.IdActivite);
                stack_activ.Visibility = Visibility.Collapsed;
                stack_sce.Visibility = Visibility.Visible;
            }

        }

        private void btn_sce_Click(object sender, RoutedEventArgs e)
        {
            stack_activ.Visibility = Visibility.Visible;
            stack_sce.Visibility = Visibility.Collapsed;
            SingletonListe.getInstance().afficherActivites();
            lvListe.ItemsSource = SingletonListe.getInstance().Liste;
        }
    }
}
