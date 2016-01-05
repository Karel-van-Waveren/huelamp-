using Huelamp.Controllers;
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
    public class Huelampwaardes
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
            return ColorUtil.HsvToRgb(hue, saturation, brightness);
        }
        
    }
}