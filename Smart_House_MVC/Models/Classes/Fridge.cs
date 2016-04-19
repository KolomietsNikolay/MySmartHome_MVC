using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Classes
{
    public class Fridge : Device, iVolume, iPower, iFreeze
    {
        private DateTime rozmoroz;
        private Freeze moroz;

        public Fridge(string name, int volume)
            : base(name)
        {
            this.Volume = volume;
            start = DateTime.Now;
            rozmoroz = DateTime.Now;
        }

        public void creatFreze()
        {
            if(moroz == null)
            moroz = new Freeze(Name, -12); 
        }

        public bool Power { set; get; }
        private int volume;
        public int Volume
        {
            set
            {
                if (value >= 3 && value <= 10)
                    volume = value;
            }
            get
            {
                return this.volume;
            }
        }
        public int Moroz
        {
            get
            {
                return moroz.Volume;
            }
            set
            {
                moroz.Volume = value;
            }
        }

        public void OnOff()
        {
        }

        public void VolumePlus() 
        {
        }
        public void VolumeMinus() 
        {
        }

        public double GetEnergy()
        {
            return ((DateTime.Now - start.Date).Hours) * 75;
        }
    }
}