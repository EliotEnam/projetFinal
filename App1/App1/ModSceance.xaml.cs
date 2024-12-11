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
using System.Security.Cryptography;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModSceance : ContentDialog
    {
        int _id;
        public ModSceance(string [] sceance)
        {
            this.InitializeComponent();
            _id = Convert.ToInt32(sceance[0]);
            tbl_texte.Text= tbl_texte.Text + " " + _id;
            dateSceance.SelectedDate = DateTime.Parse(sceance[1]);
            tbx_nb.Text= sceance[3];
            TimeSpan heure = new TimeSpan(Convert.ToInt32(sceance[2].Substring(0, 2)), Convert.ToInt32(sceance[2].Substring(3, 2)), Convert.ToInt32(sceance[2].Substring(6, 2))  
);

            heureSceance.SelectedTime = heure;
            tbl_sous.Text = "Pour des raisons d'intégrité, il n'est pas possible de changer l'activité \n à laquelle appartient la scéance";
     
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (validation() == true)
            {
                resetErreurs();
                int nb = Convert.ToInt32(tbx_nb.Text);
                string dateSce = dateSceance.Date.ToString("yyyy-MM-dd");
                string heureSce = heureSceance.SelectedTime.Value.ToString(@"hh\:mm\:ss");
                SingletonListe.getInstance().modSceance(_id, dateSce, heureSce, nb);
            }
        }

        public bool validation()
        {
            bool valide = true;
            int nbPl;
            bool nb = Int32.TryParse(tbx_nb.Text, out nbPl);
            resetErreurs();
            if (nb == true)
            {
                if (tbx_nb.Text.Trim() == String.Empty )
                {
                    valide = false;
                    erreur_nb.Text = "Ce champ est obligatoire";
                }
                if(Convert.ToInt32(tbx_nb.Text) < 0)
                {
                    valide = false;
                    erreur_nb.Text = "Le nombre de place ne peut pas être négatif";
                }

            }
            else
            {
                erreur_nb.Text = "Ce champ doit contenir des chiffres";
                valide = false;
            }
            if(dateSceance.SelectedDate == null)
            {
                valide = false ;
                erreur_dateSceance.Text = "Entrez une date";
            }
            if (heureSceance.SelectedTime == null)
            {
                valide = false;
                erreur_dateSceance.Text = "Entrez une heure";
            }

            return valide;
        }

        private void resetChamps()
        {
            tbx_nb.Text = String.Empty;
            heureSceance.SelectedTime = null;
            dateSceance = null;
        }

        private void resetErreurs()
        {
            erreur_dateSceance.Text = String.Empty;
            erreur_heure.Text = String.Empty;
            erreur_nb.Text = String.Empty;
        
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
