using Smart_House_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House_MVC.Models.Classes
{
    public class TV : Device, iVolume, iPower, iChanels
    {
        public TV(string name, string funct, int volume)
            : base(name)
        {
            this.Volume = volume;
            chanels = new SortedDictionary<int, string>();
            chanels.Add(0, "ICTV");
            chanels.Add(1, "Интер");
            chanels.Add(2, "Украина");
            chanels.Add(3, "Новый канал");
            chanels.Add(4, "ТЕТ");
            chanels.Add(5, "M1");

            ChanelMax = chanels.Count;
            Chanel = 0;
        }


        private SortedDictionary<int, string> chanels;

        public bool Power { set; get; }
        private int volume;
        private int chanel;
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

        public void chanelNext()
        {
            Chanel++;
            if (Chanel >= ChanelMax)
            {
                chanel = 0;
            }
        }

        public void chanelBack()
        {
            chanel--;
            if (chanel < 0)
            {
                chanel = ChanelMax-1;
            }
        }

        public void findChanel(string str)
        {
            ChanelMax++;
            chanels.Add(ChanelMax, str);
        }

        public string ChanelName()
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

        public void OnOff()
        {
        }

        public void VolumePlus()
        {
        }
        public void VolumeMinus()
        {
        }
    }
}