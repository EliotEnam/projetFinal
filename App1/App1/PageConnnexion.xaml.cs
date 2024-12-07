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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TwoState_Checked(object sender, RoutedEventArgs e)
        {
            stack_idAdherent.Visibility = Visibility.Collapsed;
            stack_nom.Visibility = Visibility.Visible;
            stack_password.Visibility = Visibility.Visible;
        }

        private void TwoState_Unchecked(object sender, RoutedEventArgs e)
        {
            stack_idAdherent.Visibility = Visibility.Visible;
            stack_nom.Visibility = Visibility.Collapsed;
            stack_password.Visibility = Visibility.Collapsed;
        }

        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
