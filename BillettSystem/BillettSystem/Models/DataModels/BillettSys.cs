namespace BillettSystem.Models.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BillettSys : DbContext
    {
        public BillettSys()
            : base("name=BillettSys")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Bruker> Bruker { get; set; }
        public virtual DbSet<FlyRute> FlyRute { get; set; }
        public virtual DbSet<FlyRute_i_Ordre> FlyRute_i_Ordre { get; set; }
        public virtual DbSet<FlyRutePris> FlyRutePris { get; set; }
        public virtual DbSet<GjestKundeTabell> GjestKundeTabell { get; set; }
        public virtual DbSet<Ordre> Ordre { get; set; }
        public virtual DbSet<OrdreLinje> OrdreLinje { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bruker>()
                .Property(e => e.Fornavn)
                .IsUnicode(false);

            modelBuilder.Entity<Bruker>()
                .Property(e => e.Etternavn)
                .IsUnicode(false);

            modelBuilder.Entity<Bruker>()
                .Property(e => e.Epost)
                .IsUnicode(false);

            modelBuilder.Entity<Bruker>()
                .Property(e => e.Brukernavn)
                .IsUnicode(false);

            modelBuilder.Entity<FlyRute>()
                .Property(e => e.Fra)
                .IsUnicode(false);

            modelBuilder.Entity<FlyRute>()
                .Property(e => e.Til)
                .IsUnicode(false);

            modelBuilder.Entity<FlyRute>()
                .Property(e => e.Flyselskap)
                .IsUnicode(false);

            modelBuilder.Entity<FlyRute>()
                .HasMany(e => e.FlyRute_i_Ordre)
                .WithRequired(e => e.FlyRute)
                .HasForeignKey(e => e.FlyRute_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FlyRute>()
                .HasMany(e => e.FlyRutePris)
                .WithRequired(e => e.FlyRute)
                .HasForeignKey(e => e.FlyRute_Id);

            modelBuilder.Entity<GjestKundeTabell>()
                .Property(e => e.Fornavn)
                .IsUnicode(false);

            modelBuilder.Entity<GjestKundeTabell>()
                .Property(e => e.Etternavn)
                .IsUnicode(false);

            modelBuilder.Entity<GjestKundeTabell>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<GjestKundeTabell>()
                .Property(e => e.epost)
                .IsUnicode(false);

            modelBuilder.Entity<GjestKundeTabell>()
                .HasMany(e => e.OrdreLinje)
                .WithRequired(e => e.GjestKundeTabell)
                .HasForeignKey(e => e.GjestKundeTabell_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordre>()
                .Property(e => e.ordreStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Ordre>()
                .HasMany(e => e.FlyRute_i_Ordre)
                .WithRequired(e => e.Ordre)
                .HasForeignKey(e => e.Ordre_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordre>()
                .HasMany(e => e.GjestKundeTabell)
                .WithRequired(e => e.Ordre)
                .HasForeignKey(e => e.Ordre_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordre>()
                .HasMany(e => e.OrdreLinje)
                .WithRequired(e => e.Ordre)
                .HasForeignKey(e => e.Ordre_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
