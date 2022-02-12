using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace bivaa_server_new
{
    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=Model1")
        {
        }

        public virtual DbSet<devices> devices { get; set; }
        public virtual DbSet<exam> exam { get; set; }
        public virtual DbSet<exam_type> exam_type { get; set; }
        public virtual DbSet<roles> roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<devices>()
                .Property(e => e.device_name)
                .IsUnicode(false);

            modelBuilder.Entity<exam>()
                .Property(e => e.exam_name)
                .IsUnicode(false);

            modelBuilder.Entity<exam>()
                .Property(e => e.form_label)
                .IsUnicode(false);

            modelBuilder.Entity<exam>()
                .Property(e => e.responsible)
                .IsUnicode(false);

            modelBuilder.Entity<exam>()
                .Property(e => e.exam_type)
                .IsUnicode(false);

            modelBuilder.Entity<exam_type>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<exam_type>()
                .HasMany(e => e.exam)
                .WithOptional(e => e.exam_type1)
                .HasForeignKey(e => e.exam_type);

            modelBuilder.Entity<roles>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
