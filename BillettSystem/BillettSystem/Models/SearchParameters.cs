using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BillettSystem.Models
{
    public class SearchParameters
    {
        [Display(Name = "Reise fra")]
        [Required(ErrorMessage = "Reise fra må oppgis")]
        [RegularExpression(@"([A-zÀ-ž-\s])+", ErrorMessage = "Ikke gyldig by")]
        public string Fra { get; set; }
        [Display(Name = "Reise til")]
        [Required(ErrorMessage = "Reise til må oppgis")]
        [RegularExpression(@"([A-zÀ-ž-\s])+", ErrorMessage = "Ikke gyldig by")]
        public string Til { get; set; }
        [Display(Name = "Utreise dato")]
        [Required(ErrorMessage = "Utreise dato må oppgis")]
        public string DatoFra { get; set; }

        [Display(Name = "Retur dato")]
        [Required(ErrorMessage = "Retur dato må oppgis")]
        public string DatoTil { get; set; }

    }
}