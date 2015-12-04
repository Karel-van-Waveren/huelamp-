using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huelamp.Models
    {
        public class Huelampwaardes
        {
            public Boolean on { get; set; }
            public int brightness { get; set; }
            public int hue { get; set; }
            public int saturation { get; set; }
            public string naam { get; set; }
            public Boolean isVisible { get; set; }
        }

        public class Huelampmanager
        {
            public static List<Huelampwaardes> GetHuelampen()
            {
                var huelampen = new List<Huelampwaardes>();
                huelampen.Add(new Huelampwaardes { on = true, brightness = 255, hue = 25355, saturation = 255, naam = "lamp1"});
                huelampen.Add(new Huelampwaardes { on = true, brightness = 125, hue = 55355, saturation = 55, naam = "lamp2"});
                huelampen.Add(new Huelampwaardes { on = false, brightness = 12, hue = 65433, saturation = 124, naam = "lamp3" });
                return huelampen;
            }
        }
    }