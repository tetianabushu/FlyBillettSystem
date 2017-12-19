namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FlyRute")]
    public partial class FlyRute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FlyRute()
        {
            FlyRute_i_Ordre = new HashSet<FlyRute_i_Ordre>();
            FlyRutePris = new HashSet<FlyRutePris>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Fra { get; set; }

        [Required]
        [StringLength(50)]
        public string Til { get; set; }

        public DateTime AvreiseTid { get; set; }

        public DateTime AnkomstTid { get; set; }

        public int LedigPlassEcon { get; set; }

        [Required]
        [StringLength(50)]
        public string Flyselskap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlyRute_i_Ordre> FlyRute_i_Ordre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlyRutePris> FlyRutePris { get; set; }
    }
}
