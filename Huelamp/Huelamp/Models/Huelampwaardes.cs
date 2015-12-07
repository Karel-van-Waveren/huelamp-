using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huelamp.Models
{
    public class Huelampwaardes
    {
        public int id { get; set; }
        public Boolean on { get; set; }
        public int brightness { get; set; }
        public int hue { get; set; }
        public int saturation { get; set; }
        public string naam { get; set; }
        public Boolean isVisible { get; set; }
    }


}