namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordre")]
    public partial class Ordre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordre()
        {
            FlyRute_i_Ordre = new HashSet<FlyRute_i_Ordre>();
            GjestKundeTabell = new HashSet<GjestKundeTabell>();
            OrdreLinje = new HashSet<OrdreLinje>();
        }

        public int Id { get; set; }

        public DateTime datoBetaling { get; set; }

        public int pris { get; set; }

        [Required]
        [StringLength(30)]
        public string ordreStatus { get; set; }

        public int bagasjePris { get; set; }

        public int enVei { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlyRute_i_Ordre> FlyRute_i_Ordre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GjestKundeTabell> GjestKundeTabell { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdreLinje> OrdreLinje { get; set; }
    }
}
