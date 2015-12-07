using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Huelamp.Models
{
    public class Huelampwaardes: INotifyPropertyChanging
    {
        public double id { get; set; }
        public double brightness { get; set; }
        public double hue { get; set; }
        public double saturation { get; set; }
        public string naam { get; set; }
        public Boolean isVisible { get; set; }
        public Boolean on { get; set; }
        public Color kleur { get { return FillRectangle(); } set { FillRectangle(); } }

        public Color FillRectangle()
        {
            Color c = new Color();
            c.A = 255;
            c.R = Convert.ToByte(0);
            c.G = Convert.ToByte(255);
            c.B = Convert.ToByte(0);
            return c;
        }


        public event PropertyChangingEventHandler PropertyChanging;
    }
}