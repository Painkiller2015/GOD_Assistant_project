using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GOD_Assistant;

public partial class GameInfoContext : DbContext
{
    public GameInfoContext()
    {
    }

    public GameInfoContext(DbContextOptions<GameInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Characteristic> Characteristics { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<GameMode> GameModes { get; set; }
    public virtual DbSet<Operator> Operators { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Volos\\OneDrive\\Desktop\\GA\\GameInfo.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Characteristic>(entity =>
        {
            entity.ToTable("Characteristic");

            entity.HasIndex(e => e.Id, "IX_Characteristic_Id").IsUnique();
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.HasIndex(e => e.Id, "IX_Class_Id").IsUnique();

            entity.HasIndex(e => e.SourseName, "IX_Class_SourseName").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ShortName).HasColumnType("INTEGER");
        });

        modelBuilder.Entity<GameMode>(entity =>
        {
            entity.ToTable("GameMode");

            entity.HasIndex(e => e.Id, "IX_GameMode_Id").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.ToTable("Operator");

            entity.HasIndex(e => e.Id, "IX_Operator_Id").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
