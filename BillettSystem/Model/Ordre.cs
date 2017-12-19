using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillettSysModel
{
    public class Ordre
    {
        public int OrdreId { get; set; }
        public string DatoBetaling { get; set; }
        public string Type { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }

        public int pris { get; set; }

        public bool KanEndre { get; set; }
        public string Status { get; set; }
    }
}
