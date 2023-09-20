using System;
using System.Collections.Generic;
using LN7.PL;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace LN7.PL;

public partial class LN7Entities : DbContext
{
    public LN7Entities()
    {
    }

    public LN7Entities(DbContextOptions<LN7Entities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblUser> tblUsers { get; set; }
    public virtual DbSet<tblQuestion> tblQuestions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LN7.DB;Integrated Security=true");
            //FOR USE WITH REMOTE DB
            //=> optionsBuilder.UseSqlServer("Server=tcp:lucky7db.database.windows.net,1433;Initial Catalog=lucky7db;Persist Security Info=False;User ID=lucky7db;Password=Password23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC0700F40F07");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.date_created).HasColumnType("datetime");
            entity.Property(e => e.is_admin).HasColumnType("bit");
            entity.Property(e => e.first_name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.last_name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<tblQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblQuestion__3214EC0700F40F07");
            entity.ToTable("tblQuestion");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Question).HasMaxLength(50).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
