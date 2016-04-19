using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House_MVC.Models.Interfaces
{
    interface iChanels
    {
         int Chanel { get; set; }
         void findChanel(string str);
         void chanelNext();
         void chanelBack();
    }
}
