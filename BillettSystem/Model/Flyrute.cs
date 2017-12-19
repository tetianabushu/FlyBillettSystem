using System.ComponentModel.DataAnnotations;

namespace BillettSysModel
{
    public class Flyrute
    {        
        public int Id { get; set; }
                
        [Required(ErrorMessage = "Fly selskap må oppgis")]
        public string FlySelskap { get; set; }

        [Required(ErrorMessage = "Fra by må oppgis")]
        public string  Fra { get; set; }

        [Required(ErrorMessage = "Til by må oppgis")]
        public string Til { get; set; }

        [Required(ErrorMessage = "Avreisedag må oppgis")]
        public string AvreiseDag { get; set; }

        [Required(ErrorMessage = "Avreisetid må oppgis")]
        public string AvreiseTid { get; set; }

        [Required(ErrorMessage = "Akomstdag må oppgis")]
        public string AnkomstDag { get; set; }

        [Required(ErrorMessage = "Ankomsttid må oppgis")]
        public string AnkomstTid { get; set; }

        [Required(ErrorMessage = "Billettpris voksen må oppgis")]
        public int BillettprisVoksen { get; set; }

        [Required(ErrorMessage = "Billettpris barn må oppgis")]
        public int BillettprisBarn { get; set; }

        [Required(ErrorMessage = "Antall ledige plasser må oppgis")]
        public int AntallLedigePlasser { get; set; }

        public bool KanEndre { get; set; }
    }
}
