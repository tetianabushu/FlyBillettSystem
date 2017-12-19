namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bruker")]
    public partial class Bruker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Fornavn { get; set; }

        [Required]
        [StringLength(100)]
        public string Etternavn { get; set; }

        [Required]
        [StringLength(80)]
        public string Epost { get; set; }

        [Required]
        [StringLength(80)]
        public string Brukernavn { get; set; }

        public byte[] Passord { get; set; }

        public string Salt { get; set; }
    }
}
