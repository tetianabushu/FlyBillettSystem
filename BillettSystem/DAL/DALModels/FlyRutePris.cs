namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FlyRutePris
    {
        public int Id { get; set; }

        public int prisEconClass_voksen { get; set; }

        public int prisEconClass_barn { get; set; }

        public int FlyRute_Id { get; set; }

        public virtual FlyRute FlyRute { get; set; }
    }
}
