namespace DAL.DALModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionAnswer")]
    public partial class QuestionAnswer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Kategori { get; set; }

        [Required]
        [StringLength(250)]
        public string Question { get; set; }

        [Required]
        [StringLength(4000)]
        public string Answer { get; set; }
    }
}
