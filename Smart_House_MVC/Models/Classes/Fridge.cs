using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Classes
{
    public class Fridge : Device, iVolume, iPower
    {
        private DateTime rozmoroz;
        private bool nujdaRozmoroz;
        private string urlButtonOnOff;
        private bool power;
        private int volume;
        private int levelFreeze;
        private int moroz;

       public Fridge(string name, string url, string urlB)
            : base(name)
        {
            this.urlImage = url;
            this.urlButtonOnOff = urlB;
            this.volume = 8;
            this.moroz = -10;
            this.levelFreeze = 2;
            rozmoroz = DateTime.Now;
            ispol = 0;
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

        public bool NujdaRozmoroz
        {
            set
            {
                nujdaRozmoroz = value;
            }
            get
            {
                return nujdaRozmoroz;
            }
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

        public int Volume
        {
            set
            {
                if (value >= 4 && value <= 16)
                    volume = value;
            }
            get
            {
                return this.volume;
            }
        }
        
        public int Moroz
        {
            private set
            {
                moroz = value;
            }
            get
            {
                return moroz;
            }
        }

        

        public void OnOff()
        {
            if (power)
            {
                urlImage = "~/Content/fridgeOff.jpg";
                urlButtonOnOff = "~/Content/offFridge.png";
                power = false;
                ispol += (DateTime.Now.TimeOfDay.TotalHours - start.TimeOfDay.TotalHours) * (170 + levelFreeze * 10);
            }
            else
            {
                urlImage = "~/Content/fridge1.jpg";
                urlButtonOnOff = "~/Content/onFridge.png";
                power = true;
                start = DateTime.Now;
                if (DateTime.Now.Day == 1 && start.Date.Day != 1) ispol = 0;
            }
            Proverka();
        }

        private void Proverka()
        {
           if(DateTime.Now.Date >= rozmoroz.Date)
           {
               nujdaRozmoroz = true;
           }
           else
           {
               nujdaRozmoroz = false;
           }
        }

        public void LevelChanch(int lev) 
        {
            ispol += (DateTime.Now.TimeOfDay.TotalHours - start.TimeOfDay.TotalHours) * (170 + levelFreeze * 10);
            start = DateTime.Now;
            switch(lev)
            {
                case 1:
                    Volume = 4;
                    moroz = -4;
                    levelFreeze = lev;
                    break;
                case 2:
                    Volume = 8;
                    moroz = -10;
                    levelFreeze = lev;
                    break;
                case 3:
                    Volume = 12;
                    moroz = -16;
                    levelFreeze = lev;
                    break;
                case 4:
                    Volume = 16;
                    moroz = -22;
                    levelFreeze = lev;
                    break;
                default:
                    Volume = 8;
                    moroz = -10;
                    levelFreeze = 2;
                    break;
            }
            Proverka();
        }
        public void VolumeMinus() 
        {
        }
        public void VolumePlus()
        {

        }

        public int LevelGet()
        {
            return levelFreeze;
        }

        public string Rozmorozka()
        {
            return rozmoroz.Date.ToString();
        }

        public void Razmorozil()
        {
            nujdaRozmoroz = false;
            rozmoroz = DateTime.Now.AddDays(30);
        }
    }
}