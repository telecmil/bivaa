namespace bivaa_server_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("exam")]
    public partial class exam
    {
        public int ID { get; set; }

        [Required]
        [StringLength(45)]
        public string exam_name { get; set; }

        [Required]
        [StringLength(45)]
        public string form_label { get; set; }

        [Required]
        [StringLength(45)]
        public string responsible { get; set; }

        public int? prep_time_est { get; set; }

        public int? exam_time_est { get; set; }

        public int? device { get; set; }

        [StringLength(45)]
        public string exam_type { get; set; }

        public virtual exam_type exam_type1 { get; set; }
    }
}
