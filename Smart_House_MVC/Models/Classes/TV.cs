using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Classes
{
    public class TV : Device, iVolume, iPower, iChanels
    {
        private string urlImage;
        private string urlButon;
        private int volume;
        private int chanel;
        private SortedDictionary<int, string> chanels;
        private SortedDictionary<int, string> teleprogram;
        private bool power;

        public TV(string name, string url, string urlB,int volume)
            : base(name)
        {
            this.Volume = volume;
            this.urlImage = url;
            this.urlButon = urlB;
            this.power = false;

            chanels = new SortedDictionary<int, string>();
            chanels.Add(0, "ICTV");
            chanels.Add(1, "Интер");
            chanels.Add(2, "Украина");
            chanels.Add(3, "Нов.канал");
            chanels.Add(4, "ТЕТ");
            chanels.Add(5, "1+1");

            teleprogram = new SortedDictionary<int, string>();
            teleprogram.Add(0, "https://tv.yandex.ua/187/channels/1502");
            teleprogram.Add(1, "https://tv.yandex.ua/187/channels/1489");
            teleprogram.Add(2, "https://tv.yandex.ua/187/channels/1463");
            teleprogram.Add(3, "https://tv.yandex.ua/187/channels/1515");
            teleprogram.Add(4, "https://tv.yandex.ua/187/channels/1559");
            teleprogram.Add(5, "https://tv.yandex.ua/187/channels/1480");

            ChanelMax = chanels.Count;
            Chanel = 3;
        }


        

        public bool Power 
        {
            set
            {
                power = value;
            }
            get
            {
                return power;
            }
        }

        public string UrlImage 
        {
            set
            {
                urlImage = value;
            }
            get
            {
                return urlImage;
            }
        }
        public string UrlButon 
        {
            set
            {
                urlButon = value;
            }
            get
            {
                return urlButon;
            }
        }

        public int Volume
        {
            set
            {
                if (value >= 0 && value <= 100)
                    volume = value;
            }
            get
            {
                return this.volume;
            }
        }
        public int Chanel
        {
            set
            {
                chanel = value;
            }
            get
            {
                return this.chanel;
            }
        }

        public int ChanelMax { get; set; }

        public void ChanelNext()
        {
            if (!power) return;
            chanel++;
            if (chanel >= ChanelMax)
            {
                chanel = 0;
            }
        }

        public void ChanelBack()
        {
            if (!power) return;
            chanel--;
            if (chanel < 0)
            {
                chanel = ChanelMax-1;
            }
        }

        public void FindChanel(string str, string urlTele = "https://tv.yandex.ua/187?grid=main&period=now")
        {
            ChanelMax++;
            chanels.Add(ChanelMax, str);
            teleprogram.Add(ChanelMax, urlTele);
        }

        public string UrlTelekenal()
        {

            if (power)
            {
                try
                {
                    return teleprogram[chanel];
                }
                catch (Exception ex)
                {
                    return "Not Find";
                }
            }
            else
            {
                return "https://tv.yandex.ua/187?grid=main&period=now";
            }
        }

        public string ChanelName()
        {
            if (power)
            {
                try
                {
                    return chanels[chanel];
                }
                catch (Exception ex)
                {
                    return "Not Find";
                }
            }
            else 
            {
                return "TV is off";
            }
        }

        public void OnOff()
        {
            if(power)
            {
                urlImage = "~/Content/tv.jpg";
                power = false;
                ispol += ((DateTime.Now - start.Date).Hours * 75);
            }
            else
            {
                urlImage = "~/Content/tvOn.png";
                power = true;
                start = DateTime.Now;
                if (DateTime.Now.Day == 1 && start.Date.Day !=1) ispol = 0;
            }
        }

        public void VolumePlus()
        {
            if(power)
            {
                Volume += 10;
            }
        }
        public void VolumeMinus()
        {
            if (power)
            {
                Volume -= 10;
            }
        }
    }
}