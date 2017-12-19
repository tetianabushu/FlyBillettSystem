using System.Collections.Generic;

namespace BillettSystem.Models
{
    public class Reise
    {
        public Reise()
        {
            AlleFlyRuter = new List<FlyRuteResultat>();
            BagasjePris = 0;
    }

        public List<FlyRuteResultat> AlleFlyRuter { get; set; }
        public int TotaltPris { get; set; }
        public int BagasjePris { get; set; }
        public int AntallVoksen { get; set; }
        public int AntallBarn { get; set; }       

    }
}