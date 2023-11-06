using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdoptionMVC.Models;

public partial class AdoptionDbContext : DbContext
{
    public AdoptionDbContext()
    {
    }

    public AdoptionDbContext(DbContextOptions<AdoptionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BERTHA;Database=AdoptionDB;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animals__3213E83F7B0093B5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Breed).HasMaxLength(30);
            entity.Property(e => e.Description).HasMaxLength(30);
            entity.Property(e => e.Img)
                .HasMaxLength(400)
                .HasColumnName("img");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
