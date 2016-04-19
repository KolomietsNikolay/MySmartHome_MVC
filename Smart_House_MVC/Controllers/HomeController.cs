using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart_House_MVC.Models.Classes;
using System.Collections;

namespace Smart_House_MVC.Controllers
{
    public class HomeController : Controller
    {
        private IDictionary<int, Device> dv;
        //
        // GET: /Home/
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                dv = new SortedDictionary<int, Device>();
                dv.Add(1, new Door("Входная дверь.", "~/Content/closeDoor.jpg", "~/Content/close.png"));
                dv.Add(2, new Light("Свет коридор.", "~/Content/offLight.png", "~/Content/off.png",50));
                dv.Add(3, new TV("Тел. спальня.", "~/Content/tv.jpg", "~/Content/powerClick.jpg", 50));

                Session["dv"] = dv;
                Session["id"] = 4;
            }
            else
            {
                dv = (SortedDictionary<int, Device>)Session["dv"];
            }

            return View(dv);
        }
        

        public ActionResult Add(string type, string name)
        {
            dv = (SortedDictionary<int, Device>)Session["dv"];
            int id = (int)Session["id"];
            switch (type)
            {
                case "Door":
                    dv.Add(id, new Door(name, "~/Content/closeDoor.jpg", "~/Content/close.png"));
                    break;
                case "Light":
                    dv.Add(id, new Light(name, "~/Content/offLight.png", "~/Content/off.png", 50));
                    break;
                case "TV":
                    dv.Add(id, new TV(name, "~/Content/tv.jpg", "~/Content/powerClick.jpg", 50));
                    break;
                case "Fridge":
                    break;
            }

            id++;
            Session["id"] = id;

            return Redirect("/Home/Index");
        }

        public ActionResult AddDevice()
        {
            return View();
        }
    }
}
