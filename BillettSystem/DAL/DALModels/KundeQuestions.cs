namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KundeQuestions
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Kategori { get; set; }

        [Required]
        [StringLength(150)]
        public string QuestionTittel { get; set; }

        [Required]
        [StringLength(50)]
        public string Epost { get; set; }

        [Required]
        [StringLength(2000)]
        public string QuestionText { get; set; }

        public DateTime DatoSendt { get; set; }

        public int Behandlet { get; set; }

        [Required]
        [StringLength(50)]
        public string Navn { get; set; }
    }
}
