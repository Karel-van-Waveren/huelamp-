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
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Huelamp
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Huelampwaardes> huelampen;
        public static ApplicationData APP_DATA = ApplicationData.Current;
        public static ApplicationDataContainer LOCAL_SETTINGS = APP_DATA.LocalSettings;
        public Huelampmanager hlManger;
        NetworkController nc;
        int i = 0;

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new Huelampwaardes();
            hlManger = new Huelampmanager();
            fillSettingBoxes();
            nc = new NetworkController(this);
            huelampen = hlManger.GetHuelampen();
        }

        private List<FrameworkElement> GetChildren(DependencyObject parent)
        {
            List<FrameworkElement> controls = new List<FrameworkElement>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is FrameworkElement)
                {
                    controls.Add(child as FrameworkElement);
                }
                controls.AddRange(GetChildren(child));
            }

            return controls;
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
                nc.initializeNC();
                huelampen = hlManger.GetHuelampen();
                SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
            }
            else
            {
                //display error that user hasn't filled all the boxes

            }
        }
        private void LightListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Huelampwaardes huelamp = e.ClickedItem as Huelampwaardes;
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(Propertyview), huelamp);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }
        public void loadLamps()
        {
            huelampen = hlManger.GetHuelampen();
            Lamps.UpdateLayout();
        }

    }

}