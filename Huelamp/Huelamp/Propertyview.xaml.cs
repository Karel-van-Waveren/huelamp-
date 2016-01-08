using Huelamp.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Huelamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Propertyview : Page
    {
        public Color kleur { get; set; }
        bool off;
        Huelampwaardes huelamp;

        public Propertyview()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            {
                Frame frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(MainPage));
            };
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

        private void Sliderbright_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            huelamp.brightness = e.NewValue;
            update();
        }

        private void Slidersat_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            huelamp.saturation = e.NewValue;
            update();
        }

        private void Sliderhue_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            huelamp.hue = e.NewValue;
            update();
        }

        private void LampToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (huelamp != null)
            {
                huelamp.on = LampToggle.IsOn;
                off = !LampToggle.IsOn;
                huelamp.nc.onoffLamp(huelamp);
                update();
            }
        }

        void update()
        {
            huelamp.setLamp();
            kleur = huelamp.FillRectangle();
            if (off)
                kleur = Color.FromArgb(255, 0, 0, 0);
            color1.Color = kleur;
            color2.Color = kleur;
        }

    }
}
