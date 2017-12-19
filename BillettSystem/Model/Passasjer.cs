using System.ComponentModel.DataAnnotations;

namespace BillettSysModel
{
    public class Passasjer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fornavn må oppgis")]
        //[RegularExpression("([A-zÀ-ž-\s]){2,})")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string Etternavn { get; set; }

        [Required(ErrorMessage = "Voksen eller barn må oppgis")]
        public string ErVoksen { get; set; }

        public string Adresse { get; set; }

        [Required(ErrorMessage = "Bagasje må oppgis")]
        public int Bagasje { get; set; }
    }
}
