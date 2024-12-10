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
    public partial class MainWindow : Window
    {
        public NavigationView MainNavView => nav;
        public XamlRoot XamlRoot { get; private set; }

   
        public MainWindow()
        {
            this.InitializeComponent();
            Activite.Visibility = Visibility.Collapsed;
            Adherent.Visibility = Visibility.Collapsed;
            Sceance.Visibility = Visibility.Collapsed;
            Stat.Visibility = Visibility.Collapsed;
            MesSceances.Visibility = Visibility.Collapsed;
            deconnexion.Visibility = Visibility.Collapsed;

            MaNav.leNav = nav;

            mainFrame.Navigate(typeof(PageConnnexion));
            
        }


        private async void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            refresh();
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
                case "deconnexion":
                 
                        SessionUsager.TerminerSession();
                        refresh();
                    compte.Content = "Compte";
                        mainFrame.Navigate(typeof(PageConnnexion));
             

                  
                    break;
                default:
                    break;
            }
        }

        public void refresh()
        {
            if (SessionUsager.AdminConnecte == true)
            {
                Activite.Visibility = Visibility.Visible;
                Adherent.Visibility = Visibility.Visible;
                Sceance.Visibility = Visibility.Visible;
                Stat.Visibility = Visibility.Visible;
                Accueil.Visibility = Visibility.Collapsed;
                connexion.Visibility = Visibility.Collapsed;
                compte.Visibility = Visibility.Visible;
                compte.Content = SessionUsager.NomAdmin;
                deconnexion.Visibility = Visibility.Visible;
            }
            if (SessionUsager.AdherentConnecte == true)
            {
                MesSceances.Visibility = Visibility.Visible;
                connexion.Visibility = Visibility.Collapsed;
                compte.Visibility = Visibility.Visible;
                compte.Content = SessionUsager.NomAdherent;
                deconnexion.Visibility = Visibility.Visible;

            }
            if (SessionUsager.AdherentConnecte == false && SessionUsager.AdminConnecte == false ) 
            {
                Activite.Visibility = Visibility.Collapsed;
                Adherent.Visibility = Visibility.Collapsed;
                Sceance.Visibility = Visibility.Collapsed;
                Stat.Visibility = Visibility.Collapsed;
                MesSceances.Visibility = Visibility.Collapsed;
                connexion.Visibility = Visibility.Visible;
                Accueil.Visibility= Visibility.Visible;
                deconnexion.Visibility = Visibility.Collapsed;
            }

        }


    }
}
