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
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = (SingletonListe.getInstance().afficherAdherents());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btn_ajout_adherent_Click(object sender, RoutedEventArgs e)
        {
            AjoutAherentDialog dialog = new AjoutAherentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = $"Ajout d'adhérent";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            SingletonListe.getInstance().afficherActivites();
        }
    }
}
