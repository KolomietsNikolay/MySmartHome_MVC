using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Smart_House_MVC.Models.Classes
{

    public abstract class Device
    {
        private string name;
        protected string urlImage;
        protected DateTime start;
        protected double ispol;
        public Device(string name)
        {
            this.Name = name;
        }

        public Device()
        {

        }

        public string Name { set; get; }

        public double GetElectroPitanie()
        {
            return ispol;
        }
    }
}