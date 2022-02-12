namespace bivaa_server_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("devices")]
    public partial class devices
    {
        [Key]
        public int device_ID { get; set; }

        [Required]
        [StringLength(45)]
        public string device_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? last_inspection { get; set; }
    }
}
