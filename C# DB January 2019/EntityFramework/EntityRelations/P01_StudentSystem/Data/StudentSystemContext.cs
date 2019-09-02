namespace P01_StudentSystem.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Student(modelBuilder);

            Course(modelBuilder);

            Resource(modelBuilder);

            Homework(modelBuilder);

            StudentCourse(modelBuilder);
        }

        private void StudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder
                .Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(c => c.CourseEnrollments);

            modelBuilder
               .Entity<StudentCourse>()
               .HasOne(sc => sc.Course)
               .WithMany(s => s.StudentsEnrolled);
        }

        private void Homework(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<Homework>()
              .HasKey(pk => pk.HomeworkId);

            modelBuilder
                .Entity<Homework>()
                .Property(x => x.Content)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Homework>()
                .Property(x => x.ContentType)
                .IsRequired();

            modelBuilder
                .Entity<Homework>()
                .Property(x => x.SubmissionTime)
                .IsRequired();

            modelBuilder
                .Entity<Homework>()
                .HasOne(x => x.Student)
                .WithMany(x => x.HomeworkSubmissions);

            modelBuilder
                .Entity<Homework>()
                .HasOne(x => x.Course)
                .WithMany(x => x.HomeworkSubmissions);
        }

        private void Resource(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<Resource>()
              .HasKey(pk => pk.ResourceId);

            modelBuilder
                .Entity<Resource>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Resource>()
                .Property(c => c.Url)
                .IsRequired();
        }

        private void Course(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Course>()
               .HasKey(pk => pk.CourseId);

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(c => c.Course);

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Resources)
                .WithOne(c => c.Course);

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Description)
                .IsUnicode();

            modelBuilder
                .Entity<Course>()
                .Property(c => c.StartDate)
                .IsRequired();

            modelBuilder
                   .Entity<Course>()
                   .Property(c => c.EndDate)
                   .IsRequired();

            modelBuilder
                    .Entity<Course>()
                    .Property(c => c.Price)
                    .IsRequired();
        }

        private void Student(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .HasKey(pk => pk.StudentId);

            modelBuilder
                .Entity<Student>()
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(h => h.Student);

            modelBuilder
                .Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .Property(s => s.RegisteredOn)
                .IsRequired();
        }
    }
}
