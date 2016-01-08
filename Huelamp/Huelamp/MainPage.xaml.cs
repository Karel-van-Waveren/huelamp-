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
using Windows.UI.Core;

namespace Huelamp
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Huelampwaardes> huelampen;
        public Huelampmanager hlManger;
        NetworkController nc;

        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            {
                Frame frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(SettingsPage));
            };
            this.DataContext = new Huelampwaardes();
            hlManger = new Huelampmanager();
            huelampen = hlManger.GetHuelampen();
            nc = new NetworkController(this);
            nc.initializeNC();
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
      
        private void LightListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Huelampwaardes huelamp = e.ClickedItem as Huelampwaardes;
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(Propertyview), huelamp);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
        public void loadLamps()
        {
            huelampen = hlManger.GetHuelampen();
            Lamps.UpdateLayout();
        }

    }

}