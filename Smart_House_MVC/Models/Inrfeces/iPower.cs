using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House_MVC.Models.Interfaces
{
    interface iPower
    {
         bool Power { set; get; }
         void OnOff();
    }
}
