using GeneralAppCore.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneralAppCore.EF.Context;

public partial class EducationContext : DbContext
{
    public EducationContext()
    {
    }

    public EducationContext(DbContextOptions<EducationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendancy> Attendancies { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    //public virtual DbSet<StudentPrice> StudentPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=Education;Integrated Security=true;Encrypt = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendancy>(entity =>
        {
            entity.HasKey(e => e.AttendanceId);

            entity.Property(e => e.Creadate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendancies)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendancies_Students");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.Property(e => e.Creadate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LessonName).HasMaxLength(50);

            entity.HasOne(d => d.Student).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lessons_Students");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsFixedLength();

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Groups");
        });

        modelBuilder.Entity<StudentPrice>(entity =>
        {
            entity.HasKey(e => e.StudentPriceId).HasName("PK_StudentPrice");

            entity.Property(e => e.StudentPriceId).ValueGeneratedNever();
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentPrices)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentPrices_Students");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

