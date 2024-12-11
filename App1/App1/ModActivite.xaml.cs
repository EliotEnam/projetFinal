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
    public sealed partial class ModActivite : ContentDialog
    {
        int _id = 0;
        public ModActivite(string [] activite )
        {
            this.InitializeComponent();
            tbx_nom.Text = activite[0];
            _id = Convert.ToInt32(activite[1]);
            tbx_co.Text = activite[3];
            tbx_cv.Text = activite[4];
            SingletonListe.getInstance().ListeCategorie(cbx_categorie);
            cbx_categorie.SelectedValue = activite[5];

        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (validation() == true)
            {
                resetErreurs();
                string nom = tbx_nom.Text;
                double co = Convert.ToDouble(tbx_co.Text);
                double cv = Convert.ToDouble(tbx_cv.Text);
                int cat = SingletonListe.getInstance().getIdCategorie(cbx_categorie.SelectedValue.ToString());

                SingletonListe.getInstance().modActivite(_id, nom, co, cv, cat);

            }
        }

        public bool validation()
        {
            bool valide = true;
            double coutO;
            double coutV;
            int nb;
            bool co = Double.TryParse(tbx_co.Text, out coutO);
            bool cv = Double.TryParse(tbx_cv.Text, out coutV);

            resetErreurs();

            if (tbx_nom.Text.Trim() == String.Empty)
            {
                valide = false;
                erreur_nom.Text = "Le nom ne doit pas être vide";
            }
            if (co == true)
            {
                if (tbx_co.Text.Trim() == String.Empty || Convert.ToInt32(tbx_co.Text.ToString()) < 1)
                {
                    valide = false;
                    erreur_co.Text = "Le coût d'organisation est obligatoire et\n > 0";
                }

            }
            else
            {
                erreur_co.Text = "Le coût d,organisation doit être en\n chiffre avec des (,) si nécéssaires";
                valide = false;

            }
            if (cv == true)
            {
                if (tbx_cv.Text.Trim() == String.Empty || Convert.ToInt32(tbx_cv.Text.ToString()) < 1)
                {
                    valide = false;
                    erreur_cv.Text = "Le coût de vente est obligatoire et > 0";
                }


            }
            else
            {
                erreur_cv.Text = "Le coût de vente doit être en\n chiffre avec des (,) si nécéssaires";
                valide = false;

            }
            if (cv == true && co == true)
            {
                if (tbx_co.Text.Trim() != String.Empty || Convert.ToInt32(tbx_co.Text.ToString()) > 1)
                {
                    if (tbx_cv.Text.Trim() != String.Empty || Convert.ToInt32(tbx_cv.Text.ToString()) > 1)
                    {
                        if (Convert.ToInt32(tbx_cv.Text.ToString()) < Convert.ToInt32(tbx_co.Text.ToString()))
                        {
                            valide = false;
                            erreur_cv.Text = "Le coût de vente ne peut pas être inférieur\nau coût d'organisation";
                        }
                    }
                }
            }

            return valide;
        }

        private void resetChamps()
        {
            tbx_nom.Text = String.Empty;
            tbx_co.Text = String.Empty;
            tbx_cv.Text = String.Empty;

            cbx_categorie.Text = String.Empty;

        }

        private void resetErreurs()
        {
            erreur_nom.Text = String.Empty;
            erreur_co.Text = String.Empty;
            erreur_cv.Text = String.Empty;
            erreur_cat.Text = String.Empty;

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

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
