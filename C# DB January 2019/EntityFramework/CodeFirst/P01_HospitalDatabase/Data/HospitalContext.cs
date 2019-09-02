namespace P01_HospitalDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Patient(modelBuilder);

            Doctor(modelBuilder);

            Visitation(modelBuilder);

            Diagnose(modelBuilder);

            Medicament(modelBuilder);

            PatientMedicament(modelBuilder);
        }

        private void Doctor(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Doctor>()
                 .HasKey(d => d.DoctorId);

            modelBuilder
                .Entity<Doctor>()
                .HasMany(v => v.Visitations)
                .WithOne(v => v.Doctor);

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();
        }

        private void PatientMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(ck => new
                {
                    ck.PatientId,
                    ck.MedicamentId
                });

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(p => p.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(f => f.PatientId);

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(m => m.Medicament)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(f => f.MedicamentId);
        }

        private void Medicament(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Medicament>()
               .HasKey(p => p.MedicamentId);

            modelBuilder
                .Entity<Medicament>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();
        }

        private void Diagnose(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Diagnose>()
                .HasKey(p => p.DiagnoseId);

            modelBuilder
                .Entity<Diagnose>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Diagnose>()
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void Visitation(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Visitation>()
                .HasKey(p => p.VisitationId);

            modelBuilder
                .Entity<Visitation>()
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void Patient(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
        }
    }
}
