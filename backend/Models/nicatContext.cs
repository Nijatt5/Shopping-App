using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace backend.Models
{
    public partial class nicatContext : DbContext
    {
        public nicatContext()
        {
        }

        public nicatContext(DbContextOptions<nicatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Category2> Category2s { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Insan> Insans { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NICAT\\SQLEXPRESS;Database=nicat;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Category2>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Category__19093A0B2050A842");

                entity.ToTable("Category2");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseConfirm).HasMaxLength(20);

                entity.Property(e => e.CourseDescription).HasMaxLength(200);

                entity.Property(e => e.CourseImg).HasMaxLength(50);

                entity.Property(e => e.CourseName).HasMaxLength(30);
            });

            modelBuilder.Entity<Insan>(entity =>
            {
                entity.ToTable("Insan");

                entity.Property(e => e.InsanName).HasMaxLength(30);

                entity.Property(e => e.InsanPassword).HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserDescription).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);

                entity.Property(e => e.UserSurname).HasMaxLength(200);

                entity.Property(e => e.UsersConfirm).HasMaxLength(200);

                entity.HasOne(d => d.UsersCategory)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UsersCategoryId)
                    .HasConstraintName("FK__Users__UsersCate__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
