using Huelamp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Huelamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Propertyview : Page
    {
        MainPage mp;
        Huelampwaardes huelamp;
        public Propertyview()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            huelamp = e.Parameter as Huelampwaardes;
            this.DataContext = huelamp;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            huelamp.setLamp();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(MainPage));
        }

        private void Sliderbright_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            huelamp.brightness = e.NewValue;
            Debug.WriteLine(huelamp.id + "edited");
        }

        private void Slidersat_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            huelamp.saturation = e.NewValue;
            Debug.WriteLine(huelamp.id + "edited");
        }

        private void Sliderhue_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            huelamp.hue = e.NewValue;
            Debug.WriteLine(huelamp.id + "edited");
        }
    }
}
