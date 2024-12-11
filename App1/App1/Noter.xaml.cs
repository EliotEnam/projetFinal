using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Crypto;
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
    public sealed partial class Noter : ContentDialog
    {
        int idSceance;
      
        public Noter(int idSce)
        {
            this.InitializeComponent();
            tbl_texte.Text = "Une scéance est notée sur cinq. ";
            tbl_slider_value.Text = "Ma note:  " + Math.Round(Convert.ToDouble(slider.Value), 2).ToString();
            idSceance = idSce;
        
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            tbl_slider_value.Text = "Ma note:  " + Math.Round(Convert.ToDouble(slider.Value),2).ToString();
        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            SingletonListe.getInstance().noteParticipation(idSceance, SessionUsager.IdAdherent, Math.Round(Convert.ToDouble(slider.Value), 2));
        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            

        }
    }
}
