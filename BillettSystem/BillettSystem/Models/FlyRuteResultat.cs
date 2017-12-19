using System;

namespace BillettSystem.Models
{
    public class FlyRuteResultat
    {
        public int Id { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
        public string UtreiseDag { get; set; }
        public string UtreiseTid { get; set; }
        public string InnreiseDag { get; set; }
        public string InnreiseTid { get; set; }
        public string FlySelskap { get; set; }
    }
}