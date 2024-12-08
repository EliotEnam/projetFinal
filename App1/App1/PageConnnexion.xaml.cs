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
    public sealed partial class PageConnnexion : Page
    {
        public PageConnnexion()
        {
            this.InitializeComponent();
        }

   

        public bool validation()
        {
            bool valide = true;
            resetErreurs();

            if (stack_nom.Visibility == Visibility.Visible && string.IsNullOrWhiteSpace(tbx_nom.Text)){ 
                valide = false;
                erreur_nom.Text = "Le nom ne doit pas être vide";
            }
            if (stack_password.Visibility == Visibility.Visible && string.IsNullOrWhiteSpace(tbx_pass.Password))
            {
                valide = false;
                erreur_pass.Text = "Veuillez entrer un mot de passe";
            }

            if (string.IsNullOrWhiteSpace(tbx_id_adherent.Text))
            {
                valide = false;
                erreur_id.Text = "Veuillez entrer votre identifiant";
            }
            return valide;
        }

        private void resetErreurs()
        {
            erreur_nom.Text = String.Empty;
            erreur_pass.Text = String.Empty;
            erreur_id.Text = String.Empty;
      
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TwoState_Checked(object sender, RoutedEventArgs e)
        {
            stack_idAdherent.Visibility = Visibility.Collapsed;
            stack_nom.Visibility = Visibility.Visible;
            stack_password.Visibility = Visibility.Visible;
            tbl_texte.Text = "Entrez vos identifiants";
        }

        private void TwoState_Unchecked(object sender, RoutedEventArgs e)
        {
            stack_idAdherent.Visibility = Visibility.Visible;
            stack_nom.Visibility = Visibility.Collapsed;
            stack_password.Visibility = Visibility.Collapsed;
            tbl_texte.Text = "Entrez votre identifiant";
        }

        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {
            if (validation() == true)
            {
                resetErreurs();
                if (stack_nom.Visibility == Visibility.Visible && stack_password.Visibility == Visibility.Visible)
                {
                    string nom = tbx_nom.Text;
                }
                else if (stack_idAdherent.Visibility == Visibility.Visible)
                {
                    string id = tbx_id_adherent.Text;
                    if (SingletonListe.getInstance().connexionAdherent(id) == "")
                    {
                        tbl_error.Visibility = Visibility.Visible;    
                        tbl_error.Text = "Adherent inexistant";
                    }
                    else
                    {
                        SessionUsager.NomAdherent = SingletonListe.getInstance().connexionAdherent(id);
                        SessionUsager.IdAdherent = tbx_id_adherent.Text;
                        SessionUsager.AdherentConnecte = true;
                        tbl_error.Visibility = Visibility.Visible;
                        tbl_error.Text = SessionUsager.IdAdherent.ToString();
                        Frame.Navigate(typeof(AffichageActivAdher));
                    }

                }

            }
        }
    }
}
