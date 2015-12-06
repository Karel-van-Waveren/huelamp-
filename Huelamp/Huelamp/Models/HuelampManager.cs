using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huelamp.Models
{
    public class Huelampmanager
    {

        List<Huelampwaardes> huelampen = new List<Huelampwaardes>();
        public Huelampmanager()
        {

        }

        public void addHuelamp(JToken lamp)
        {
            var state = lamp["state"];
            huelampen.Add(new Huelampwaardes
            {
                on = (state["on"].ToString() == "true") ? true : false,
                brightness = int.Parse(state["bri"].ToString()),
                hue = int.Parse(state["hue"].ToString()),
                saturation = int.Parse(state["sat"].ToString())
            });
            Debug.WriteLine("added " + lamp["name"].ToString());

        }

        public List<Huelampwaardes> GetHuelampen()
        {
            //huelampen.Add(new Huelampwaardes { on = true, brightness = 255, hue = 25355, saturation = 255, naam = "lamp1" });
            //huelampen.Add(new Huelampwaardes { on = true, brightness = 125, hue = 55355, saturation = 55, naam = "lamp2" });
            //huelampen.Add(new Huelampwaardes { on = false, brightness = 12, hue = 65433, saturation = 124, naam = "lamp3" });
            return huelampen;
        }
    }
}
