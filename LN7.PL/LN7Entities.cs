using System;
using System.Collections.Generic;
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

    public virtual DbSet<tblBodyType> tblBodyTypes { get; set; }

    public virtual DbSet<tblCoatColor> tblCoatColors { get; set; }

    public virtual DbSet<tblCoatLength> tblCoatLengths { get; set; }

    public virtual DbSet<tblCoatType> tblCoatTypes { get; set; }

    public virtual DbSet<tblDog> tblDogs { get; set; }

    public virtual DbSet<tblDogGroup> tblDogGroups { get; set; }

    public virtual DbSet<tblEarLength> tblEarLengths { get; set; }

    public virtual DbSet<tblEarType> tblEarTypes { get; set; }

    public virtual DbSet<tblLegLength> tblLegLengths { get; set; }

    public virtual DbSet<tblMuzzleLength> tblMuzzleLengths { get; set; }

    public virtual DbSet<tblMuzzleType> tblMuzzleTypes { get; set; }

    public virtual DbSet<tblOrigin> tblOrigins { get; set; }

    public virtual DbSet<tblQuestion> tblQuestions { get; set; }

    public virtual DbSet<tblTailLength> tblTailLengths { get; set; }

    public virtual DbSet<tblTailType> tblTailTypes { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    public virtual DbSet<tblWeightClass> tblWeightClasses { get; set; }
    public virtual DbSet<tblPlayerStat> tblPlayerStats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                 //FOR USE WITH LOCAL DB
                 //=> optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LN7.DB;Integrated Security=True");
                 //FOR USE WITH REMOTE DB
                  => optionsBuilder.UseSqlServer("Server=tcp:lucky7db.database.windows.net,1433;Initial Catalog=cardsale;Persist Security Info=False;User ID=lucky7db;Password=Password23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblBodyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblBodyT__3214EC07E2E68788");

            entity.ToTable("tblBodyType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblCoatColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCoatC__3214EC0743860644");

            entity.ToTable("tblCoatColor");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblCoatLength>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCoatL__3214EC075369B484");

            entity.ToTable("tblCoatLength");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblCoatType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCoatT__3214EC07CD05FF47");

            entity.ToTable("tblCoatType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblDog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDog__3214EC07FAD9597E");

            entity.ToTable("tblDog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BreedName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagepath)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DogGroup);
            entity.Property(e => e.BodyType);
            entity.Property(e => e.CoatColor);
            entity.Property(e => e.CoatType);
            entity.Property(e => e.CoatLength);
            entity.Property(e => e.EarType);
            entity.Property(e => e.EarLength);
            entity.Property(e => e.LegLength);
            entity.Property(e => e.BodyType);
            entity.Property(e => e.MuzzleType);
            entity.Property(e => e.MuzzleLength);
            entity.Property(e => e.Origin);
            entity.Property(e => e.TailType);
            entity.Property(e => e.TailLength);
            entity.Property(e => e.WeightClass);
        });

        modelBuilder.Entity<tblDogGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDogGr__3214EC07B892B026");

            entity.ToTable("tblDogGroup");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblEarLength>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblEarLe__3214EC0750907DC2");

            entity.ToTable("tblEarLength");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblEarType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblEarTy__3214EC07278CCC61");

            entity.ToTable("tblEarType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblLegLength>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblLegLe__3214EC07A5E8DA9C");

            entity.ToTable("tblLegLength");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMuzzleLength>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMuzzl__3214EC07455F9BD9");

            entity.ToTable("tblMuzzleLength");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMuzzleType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMuzzl__3214EC07DE23F0BB");

            entity.ToTable("tblMuzzleType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblOrigin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrigi__3214EC0750BB06EE");

            entity.ToTable("tblOrigin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblQuest__3214EC07269041E8");

            entity.ToTable("tblQuestion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Question)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Trait_Id);
            entity.Property(e => e.Answer);
        });

        modelBuilder.Entity<tblTailLength>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTailL__3214EC07A5C92C2E");

            entity.ToTable("tblTailLength");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblTailType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTailT__3214EC0729CB127C");

            entity.ToTable("tblTailType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC071C72DE0F");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.First_Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Last_Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Is_Admin).IsRequired();
        });

        modelBuilder.Entity<tblWeightClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblWeigh__3214EC07E3488F34");

            entity.ToTable("tblWeightClass");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblPlayerStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PPK__tblPlaye__3214EC07414367A5");

            entity.ToTable("tblPlayerStat");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.PlayDate).HasColumnType("datetime");
            entity.Property(e => e.Result).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
