using Smart_House_MVC.Models.Classes;
using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smart_House_MVC.Controllers
{
    public class DeviceController : Controller
    {
        //
        // GET: /Device/

        public ActionResult OpenClose(int i=1)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];
            
            if(dv[i] is Door)
            {
                (dv[i] as Door).OpenClose();
            }

            return Redirect("/Home/Index");
        }

        public ActionResult OnOff(int i=1)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];

            if(dv[i] is iPower)
            {
                ((iPower)(dv[i])).OnOff();
            }

            return Redirect("/Home/Index");
        }

        public ActionResult Volume(int i=1,bool type= false)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];

            if(type)
            {
                ((iVolume)dv[i]).VolumePlus();
            }
            else
            {
                ((iVolume)dv[i]).VolumeMinus();
            }
            return Redirect("/Home/Index");
        }

        public ActionResult Delete(int i=0)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];

            dv.Remove(i);

            return Redirect("/Home/Index");
        }
    }
}
