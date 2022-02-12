namespace bivaa_server_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("diagonstics.roles")]
    public partial class roles
    {
        [Key]
        [StringLength(45)]
        public string role { get; set; }
    }
}
