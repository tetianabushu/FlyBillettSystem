using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillettSysModel
{
    public class OrdreDetaljer
    {
        public OrdreDetaljer()
        {
            Passasjerer = new List<Passasjer>();
        }

        public int Id { get; set; }
        public int Pris { get; set; }
        public string BestillingsDato { get; set; }
        public string Status { get; set; }
        public bool KanRedigere { get; set; }

        public BestiltFlyRute Utreise { get; set; }
        public BestiltFlyRute Retur { get; set; }
        public List<Passasjer> Passasjerer { get; set; }

    }
    public class BestiltFlyRute
    {
        public int FlyruteId { get; set; }
        public string Fra { get; set; }
        public string FraDato { get; set; }
        public string FraTid { get; set; }
        public string Til { get; set; }
        public string TilDato { get; set; }
        public string TilTid { get; set; }
        public string FlySelskap { get; set; }
        public string Type { get; set; }

    }

    
}
