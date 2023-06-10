using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba_cft.Models;

public partial class PruebaCftContext : DbContext
{
    public PruebaCftContext()
    {
    }

    public PruebaCftContext(DbContextOptions<PruebaCftContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Asignaturasestudiante> Asignaturasestudiantes { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {


        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asignaturas");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Codigo).HasMaxLength(30);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Asignaturasestudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asignaturasestudiantes");

            entity.HasIndex(e => e.AsignaturaId, "fk_Estudiantes_has_Asignaturas_Asignaturas1_idx");

            entity.HasIndex(e => e.EstudianteId, "fk_Estudiantes_has_Asignaturas_Estudiantes_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AsignaturaId).HasColumnType("int(11)");
            entity.Property(e => e.EstudianteId).HasColumnType("int(11)");

            entity.HasOne(d => d.Asignatura).WithMany(p => p.Asignaturasestudiantes)
                .HasForeignKey(d => d.AsignaturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Estudiantes_has_Asignaturas_Asignaturas1");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Asignaturasestudiantes)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Estudiantes_has_Asignaturas_Estudiantes");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estudiantes");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Edad).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Rut).HasMaxLength(45);
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notas");

            entity.HasIndex(e => e.AsignaturaId, "fk_Notas_Asignaturas1_idx");

            entity.HasIndex(e => e.EstudianteId, "fk_Notas_Estudiantes1_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AsignaturaId).HasColumnType("int(11)");
            entity.Property(e => e.EstudianteId).HasColumnType("int(11)");

            entity.HasOne(d => d.Asignatura).WithMany(p => p.Nota)
                .HasForeignKey(d => d.AsignaturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Notas_Asignaturas1");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Nota)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Notas_Estudiantes1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
