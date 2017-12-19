namespace BillettSystem.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FlyRute_i_Ordre
    {
        public int Id { get; set; }

        public int rekkefølge { get; set; }

        public int FlyRute_Id { get; set; }

        public int Ordre_Id { get; set; }

        public virtual FlyRute FlyRute { get; set; }

        public virtual Ordre Ordre { get; set; }
    }
}
