using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Huelamp.Models;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Huelamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Huelampwaardes> huelampen;
        public static ApplicationData APP_DATA = ApplicationData.Current;
        public static ApplicationDataContainer LOCAL_SETTINGS = APP_DATA.LocalSettings;

        public MainPage()
        {
        this.InitializeComponent();
        huelampen = Huelampmanager.GetHuelampen();
            
        }

    private void Infolamp_Tapped(object sender, TappedRoutedEventArgs e)
    {

    }
        // deze methode in de classe zetten waar je je settings invult
        public static void SetSettings(string ip, int port, string username)
        {
            MainPage.LOCAL_SETTINGS.Values["ip"] = ip;
            MainPage.LOCAL_SETTINGS.Values["port"] = port;
            MainPage.LOCAL_SETTINGS.Values["user"] = username;
        }

        public static void RetrieveSettings(out string ip, out int port, out string username)
        {
            string tempIP = MainPage.LOCAL_SETTINGS.Values["ip"] as string;
            int tempPort = Convert.ToInt32(MainPage.LOCAL_SETTINGS.Values["port"]);
            string tempUsername = MainPage.LOCAL_SETTINGS.Values["user"] as string;

            if (string.IsNullOrEmpty(tempIP))
                tempIP = "localhost";
            if (tempPort == 0)
                tempPort = 8000;
            if (string.IsNullOrEmpty(tempUsername))
                tempUsername = "MenK Hue";

            ip = tempIP;
            port = tempPort;
            username = tempUsername;
        }
}
}