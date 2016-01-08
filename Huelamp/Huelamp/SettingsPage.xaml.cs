using Huelamp.Controllers;
using Huelamp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Huelamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public static ApplicationData APP_DATA = ApplicationData.Current;
        public static ApplicationDataContainer LOCAL_SETTINGS = APP_DATA.LocalSettings;
        private ObservableCollection<Huelampwaardes> huelampen;
        public Huelampmanager hlManger;


        public SettingsPage()
        {
            this.InitializeComponent();
            fillSettingBoxes();
    
        }

        public static void SetSettings(string ip, int port, string username)
        {
            SettingsPage.LOCAL_SETTINGS.Values["ip"] = ip;
            SettingsPage.LOCAL_SETTINGS.Values["port"] = port;
            SettingsPage.LOCAL_SETTINGS.Values["user"] = username;
        }

        public static void RetrieveSettings(out string ip, out int port, out string username)
        {
            string tempIP = SettingsPage.LOCAL_SETTINGS.Values["ip"] as string;
            int tempPort = Convert.ToInt32(SettingsPage.LOCAL_SETTINGS.Values["port"]);
            string tempUsername = SettingsPage.LOCAL_SETTINGS.Values["user"] as string;

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
              

                Frame frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(MainPage));
            }
            else
            {
                //display error that user hasn't filled all the boxes

            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
