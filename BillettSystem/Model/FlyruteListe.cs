using System;
using System.Collections.Generic;

namespace BillettSysModel
{
    public class FlyruteListe
    {
        public FlyruteListe ()
        {
            Flyruter = new List<Flyrute>();
        }

        public List<Flyrute> Flyruter { get; set; }
    }
}
