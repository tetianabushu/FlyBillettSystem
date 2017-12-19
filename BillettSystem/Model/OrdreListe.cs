using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillettSysModel
{
    public class OrdreListe
    {
        public OrdreListe()
        {
            Ordrer = new List<Ordre>();
        }
        public List<Ordre> Ordrer { get; set; }
    }
}
