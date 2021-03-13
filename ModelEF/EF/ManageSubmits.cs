namespace ModelEF.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ManageSubmits : DbContext
    {
        public ManageSubmits()
            : base("name=ManageSubmits")
        {
        }

        public virtual DbSet<COMMENT> COMMENTS { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<FILE> FILES { get; set; }
        public virtual DbSet<ROLE> ROLES { get; set; }
        public virtual DbSet<SUBMITTION> SUBMITTIONS { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FILE>()
                .Property(e => e.File_Path)
                .IsUnicode(false);

            modelBuilder.Entity<ROLE>()
                .Property(e => e.Role_Name)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.SUBMITTIONS)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.Created_By);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.SUBMITTIONS1)
                .WithOptional(e => e.USER1)
                .HasForeignKey(e => e.Update_By);
        }
    }
}
