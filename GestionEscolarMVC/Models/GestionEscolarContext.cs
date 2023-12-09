using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolarMVC.Models;

public partial class GestionEscolarContext : DbContext
{
    public GestionEscolarContext()
    {
    }

    public GestionEscolarContext(DbContextOptions<GestionEscolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<DetalleCalif> DetalleCalifs { get; set; }

    public virtual DbSet<DetalleMaestro> DetalleMaestros { get; set; }

    public virtual DbSet<Maestro> Maestros { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; DataBase=GestionEscolar;Integrated Security=true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Idalumno).HasName("PK__Alumno__2A8067BFD43F36F3");

            entity.ToTable("Alumno");

            entity.Property(e => e.Idalumno)
                .ValueGeneratedNever()
                .HasColumnName("IDAlumno");
            entity.Property(e => e.Apellido).IsUnicode(false);
            entity.Property(e => e.Correo).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
        });

        modelBuilder.Entity<DetalleCalif>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleC__3214EC273416DED9");

            entity.ToTable("DetalleCalif");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Idalumno).HasColumnName("IDAlumno");
            entity.Property(e => e.Idmateria).HasColumnName("IDMateria");
        });

        modelBuilder.Entity<DetalleMaestro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleM__3214EC27BEB1F8C0");

            entity.ToTable("DetalleMaestro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Idmaestro).HasColumnName("IDMaestro");
            entity.Property(e => e.Idmateria).HasColumnName("IDMateria");
        });

        modelBuilder.Entity<Maestro>(entity =>
        {
            entity.HasKey(e => e.Idmaestro).HasName("PK__Maestro__1D916A4205868F48");

            entity.ToTable("Maestro");

            entity.Property(e => e.Idmaestro)
                .ValueGeneratedNever()
                .HasColumnName("IDMaestro");
            entity.Property(e => e.Apellido).IsUnicode(false);
            entity.Property(e => e.Correo).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Idmateria).HasName("PK__Materia__DBEC84744C0DBDA3");

            entity.Property(e => e.Idmateria)
                .ValueGeneratedNever()
                .HasColumnName("IDMateria");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Horario).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
