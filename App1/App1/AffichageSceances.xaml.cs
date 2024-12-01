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

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Sceance sceance = btn.DataContext as Sceance;
            lv_liste.SelectedItem = sceance;
            SingletonListe.getInstance().supprimer(sceance.IdSce.ToString(), "supprimerSceance");
            lv_liste.ItemsSource = (SingletonListe.getInstance().afficherSceances());
        }
    }
}
