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
    public sealed partial class ModAdherent : ContentDialog
    {
        string _id;
        public ModAdherent( string [] adherent)
        {
            this.InitializeComponent();
            dateNaiss.MaxYear = DateTime.Today.AddYears(-18);
            _id = adherent[0];
            tbx_nom.Text = adherent[1];
            tbx_prenom.Text = adherent[2];
            tbx_adresse.Text = adherent[3];
            tbl_texte.Text = $"{tbl_texte.Text} {_id}";   
            dateNaiss.SelectedDate = DateTime.Parse(adherent[4]);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (validation() == true)
            {
                resetErreurs();
                string nom = tbx_nom.Text;
                string prenom = tbx_prenom.Text;
                string dateNaiss1 = dateNaiss.Date.ToString("yyyy-MM-dd");
                string adresse = tbx_adresse.Text;
                SingletonListe.getInstance().modAdherent(_id,nom,prenom,adresse,dateNaiss1);

            }
        }

        public bool validation()
        {
            bool valide = true;
            resetErreurs();


            if (tbx_nom.Text.Trim() == String.Empty)
            {
                valide = false;
                erreur_nom.Text = "Le nom ne doit pas être vide";
            }
            if (tbx_prenom.Text.Trim() == String.Empty)
            {
                valide = false;
                erreur_prenom.Text = "Le prénom ne doit pas être vide";
            }

            if (tbx_adresse.Text.Trim() == String.Empty)
            {
                valide = false;
                erreur_adresse.Text = "L'adresse ne doit pas être vide";
            }
            if (dateNaiss == null)
            {
                valide = false;
                erreur_dateNais.Text = "Veullez entrer une date de Naissance";
            }
            return valide;
        }

        private void resetChamps()
        {
            tbx_nom.Text = String.Empty;
            tbx_prenom.Text = String.Empty;
            tbx_adresse.Text = String.Empty;
            dateNaiss = null;
        }

        private void resetErreurs()
        {
            erreur_nom.Text = String.Empty;
            erreur_prenom.Text = String.Empty;
            erreur_dateNais.Text = String.Empty;
            erreur_adresse.Text = String.Empty;
        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (args.Result == ContentDialogResult.Primary)
            {
                if (validation() == false)
                    args.Cancel = true;
            }
            else
                args.Cancel = false;

        }
    }
}
