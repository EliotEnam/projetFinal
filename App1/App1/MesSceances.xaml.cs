using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
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
    public sealed partial class MesSceances : Page
    {
        public MesSceances()
        {
            this.InitializeComponent();
      
            lv_liste.ItemsSource = SingletonListe.getInstance().afficherSeancesParAdherent(SessionUsager.IdAdherent);
            

        }

        private async void btn_inscription_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Sceance sceance = btn.DataContext as Sceance;
            DateTime dateAuj = DateTime.Now;
            DateTime dateSceance = DateTime.Parse(sceance.Date.ToString());
            if(sceance.NoteParAdherent != 0)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "Je comprends";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = $"Vous avez deja donné la note de {sceance.NoteParAdherent} à cette scéacnce";

                ContentDialogResult result = await dialog.ShowAsync();
            }
            else if ((dateSceance.Date < dateAuj.Date))
            {

                Noter dialog = new Noter(sceance.IdSce);
                dialog.XamlRoot = this.XamlRoot;
                dialog.PrimaryButtonText = "Noter";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Close;
                ContentDialogResult resultat = await dialog.ShowAsync();
            }
            else
            {      
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "Je comprends";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = $"Cette scéance n'a pas encore eu lieu. Vous ne pouvez pas encore la noter";

                ContentDialogResult result = await dialog.ShowAsync();

            }
        }
    }
}
