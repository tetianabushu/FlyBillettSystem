namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GjestKundeTabell")]
    public partial class GjestKundeTabell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GjestKundeTabell()
        {
            OrdreLinje = new HashSet<OrdreLinje>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Fornavn { get; set; }

        [Required]
        [StringLength(50)]
        public string Etternavn { get; set; }

        [Required]
        [StringLength(100)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string epost { get; set; }

        public int Ordre_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdreLinje> OrdreLinje { get; set; }

        public virtual Ordre Ordre { get; set; }
    }
}
