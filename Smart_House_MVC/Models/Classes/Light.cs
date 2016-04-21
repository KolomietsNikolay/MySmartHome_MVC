using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart_House_MVC.Models.Interfaces;

namespace Smart_House_MVC.Models.Classes
{
    public class Light : Device, iPower, iVolume
    {
        private int volume;
        private bool power;
        private string urlButtonOnOff;
        private DateTime start;

        public Light(string name, string url, string urlB, int volume)
            : base(name)
        {
            this.urlImage = url;
            this.urlButtonOnOff = urlB;
            this.volume = volume;
            ispol = 0;
        }

        public string UrlImage
        {
            get
            {
                return urlImage;
            }
            set
            {
                urlImage = value;
            }
        }
        public string UrlButtonOnOff
        {
            get
            {
                return urlButtonOnOff;
            }
            set
            {
                urlButtonOnOff = value;
            }
        }

        public bool Power
        {
            set
            {
                power = value;
            }
            get
            {
                return power;
            }
        }

        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    volume = value;
            }

        }

        public void VolumePlus()
        {
            if (power && volume <= 100)
            {
                ispol += (DateTime.Now.TimeOfDay.TotalHours - start.TimeOfDay.TotalHours) * volume;
                start = DateTime.Now;
            }
            Volume += 10;
            Refresh();
        }

        public void VolumeMinus()
        {
            if (power)
            {
                ispol += (DateTime.Now.TimeOfDay.TotalHours - start.TimeOfDay.TotalHours) * volume;
                start = DateTime.Now;
            }
            Volume -= 10;
            Refresh();
        }

        public void OnOff()
        {
            if (power)
            {
                urlButtonOnOff = "~/Content/off.png";
                urlImage = "~/Content/offLight.png";
                ispol += (DateTime.Now.Date.TimeOfDay.TotalHours - start.Date.TimeOfDay.TotalHours) * volume;
                power = false;
            }
            else if (volume > 0)
            {
                start = DateTime.Now;
                if (DateTime.Now.Day == 1 && start.Date.Day != 1) ispol = 0;
                power = true;
                UrlButtonOnOff = "~/Content/on.jpg";
                Refresh();
            }
        }

        private void Refresh()
        {
            if (power)
            {
                if (volume > 0 && volume <= 40)
                {
                    urlImage = "~/Content/onLight2.png";
                }
                else if (volume > 40 && volume <= 80)
                {
                    urlImage = "~/Content/onLight1.png";
                }
                else if (volume > 80)
                {
                    urlImage = "~/Content/onLight.png";
                }
                else if (volume == 0)
                {
                    OnOff();
                }
            }
        }
    }
}