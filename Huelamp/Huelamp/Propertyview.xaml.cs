using Huelamp.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Huelamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Propertyview : Page
    {
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

        }

        private void Sliderbright_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void Slidersat_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void Sliderhue_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
    }
}
