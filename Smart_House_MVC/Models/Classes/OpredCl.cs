using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Classes
{
    public class OpredCl
    {
        private Device dv;
        public OpredCl(Device dv) {
            this.dv = dv;
        }

        public string Cl
        {
            set { Cl = value; }
            get
            {
                if (dv is Door) return "Door";
                if (dv is Fridge) return "Fridge";
                if (dv is Light) return "Light";
                if (dv is TV) return "TV";
                return "Device";
            }
        }

        public string Name { get; set; }
    }
}