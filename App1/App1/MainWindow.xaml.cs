using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public XamlRoot XamlRoot { get; private set; }

        public MainWindow()
        {
            this.InitializeComponent();
            Activite.Visibility = Visibility.Collapsed;
            Adherent.Visibility = Visibility.Collapsed;
            Sceance.Visibility = Visibility.Collapsed;
            Stat.Visibility = Visibility.Collapsed;
            mainFrame.Navigate(typeof(PageConnnexion));
            if (SessionUsager.AdminConnecte == true) { 
                Activite.Visibility = Visibility.Visible;
                Adherent.Visibility = Visibility.Visible;
                Sceance.Visibility = Visibility.Visible;
                Stat.Visibility = Visibility.Visible;
            }
        }


        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "Activite":
                    mainFrame.Navigate(typeof(Affichage));
                    break;
                case "Adherent":
                    mainFrame.Navigate(typeof(BlankPage1));
                    break;
                case "Sceance":
                    mainFrame.Navigate(typeof(AffichageSceances));
                    break;
                case "Stat":
                    mainFrame.Navigate(typeof(Statistiques));
                    break;
                case "Accueil":
                    mainFrame.Navigate(typeof(AffichageActivAdher));
                    break;
                case "MesSceances":
                    mainFrame.Navigate(typeof(MesSceances));
                    break;
                case "connexion":
                    mainFrame.Navigate(typeof(PageConnnexion));
                    break;
                default:
                    break;
            }
        }


    }
}
