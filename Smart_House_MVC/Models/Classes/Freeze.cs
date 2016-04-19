using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_House_MVC.Models.Classes
{
    class Freeze:Fridge
    {
        public Freeze(string name, int volume)
            : base(name,volume)
        {
            this.Volume = volume;
        }

        private int volume;
        public int Volume
        {
            set
            {
                if(value <= -6 && value >= -24)
                {
                    volume = value;
                }
            }

            get
            {
                return volume;
            }
        }
    }
}
