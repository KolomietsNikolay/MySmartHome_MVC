using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Classes
{
    public class Fan:Device, iPower
    {
        public Fan(string name, string funct)
            : base(name)
        {
            
        }


        public bool Power { set; get; }

        public void OnOff()
        {
        }
    }
}