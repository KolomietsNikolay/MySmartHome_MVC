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

        public ActionResult Chanel(int i = 1, bool type = false)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];

            if (type)
            {
                ((iChanels)dv[i]).ChanelNext();
            }
            else
            {
                ((iChanels)dv[i]).ChanelBack();
            }
            return Redirect("/Home/Index");
        }

        public ActionResult Level(int i=1,int lev=2)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];

            ((Fridge)dv[i]).LevelChanch(lev);

            return Redirect("/Home/Index");
        }

        public ActionResult Inform(int i=1)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];

            ViewData["razm"] = i;

            return View(dv[i]);
        }

        public ActionResult Rozmorozil(int i = 1)
        {
            IDictionary<int, Device> dv;
            dv = (SortedDictionary<int, Device>)Session["dv"];

            ((Fridge)dv[i]).Razmorozil();

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
