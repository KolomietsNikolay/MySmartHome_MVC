using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart_House_MVC.Models.Interfaces;

namespace Smart_House_MVC.Models.Classes
{
    public class Door : Device, iClouses
    {
        private bool clouses;
        private string urlButtonOpen;

        public Door(string name, string url, string urlB)
            : base(name)
        {
            this.urlImage = url;
            this.urlButtonOpen = urlB;
            clouses = true;
        }

        public bool Clouses
        {
            set;
            get;
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
        public string UrlButtonOpen 
        {
            get 
            {
                return urlButtonOpen;
            }
            set
            {
                urlButtonOpen = value;
            }
        }

        public void OpenClose()
        {
            if (clouses)
            {
                urlButtonOpen = "~/Content/open.png";
                urlImage = "~/Content/openDoor.jpg";
                clouses = false;
            }
            else
            {
                urlButtonOpen = "~/Content/close.png";
                urlImage = "~/Content/closeDoor.jpg";
                clouses = true;
            }
        }
    }
}