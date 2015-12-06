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
using Huelamp.Controllers;

namespace Huelamp
{
    public sealed partial class MainPage : Page
    {
        private List<Huelampwaardes> huelampen;
        public static ApplicationData APP_DATA = ApplicationData.Current;
        public static ApplicationDataContainer LOCAL_SETTINGS = APP_DATA.LocalSettings;
        public Huelampmanager hlManger;
        NetworkController nc;

        public MainPage()
        {
            this.InitializeComponent();
            hlManger = new Huelampmanager();
            fillSettingBoxes();
            nc = new NetworkController(this);
            huelampen = hlManger.GetHuelampen();
        }

        private void Infolamp_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        // methodes voor alle settings
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

        public void fillSettingBoxes()
        {
            string ip;
            int port;
            string username;
            RetrieveSettings(out ip, out port, out username);
            IpBox.Text = ip;
            PortBox.Text = port + "";
            UsernameBox.Text = username;
        }
        // button methodes
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(IpBox.Text) && !string.IsNullOrEmpty(PortBox.Text) && !string.IsNullOrEmpty(UsernameBox.Text))
            {
                SetSettings(IpBox.Text, Convert.ToInt32(PortBox.Text), UsernameBox.Text);
                SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
                Settings.Visibility = Visibility.Collapsed;
                nc.initializeNC();

                    huelampen = hlManger.GetHuelampen();

            }
            else
            {
                //display error that user hasn't filled all the boxes
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Visibility == Visibility.Visible)
                Settings.Visibility = Visibility.Collapsed;
            else
                Settings.Visibility = Visibility.Visible;
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (Lamps.Visibility == Visibility.Visible)
                Lamps.Visibility = Visibility.Collapsed;
            else
                Lamps.Visibility = Visibility.Visible;
        }
        public void loadLamps()
        {
            huelampen = hlManger.GetHuelampen();
        }
    }

}