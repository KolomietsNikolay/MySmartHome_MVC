﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House_MVC.Models.Interfaces
{
    interface iVolume
    {
        int Volume { set; get; }
        void VolumePlus();
        void VolumeMinus();

    }
}
