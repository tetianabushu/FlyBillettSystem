namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdreLinje")]
    public partial class OrdreLinje
    {
        public int Id { get; set; }

        public int ErVoksen { get; set; }

        public int antallBagasjePerLinje { get; set; }

        public int Ordre_Id { get; set; }

        public int GjestKundeTabell_Id { get; set; }

        public virtual GjestKundeTabell GjestKundeTabell { get; set; }

        public virtual Ordre Ordre { get; set; }
    }
}
