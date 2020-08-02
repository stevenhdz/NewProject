using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class soporte4Context : DbContext
    {
        public soporte4Context()
        {
        }

        public soporte4Context(DbContextOptions<soporte4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Analista> Analista { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Garantia> Garantia { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=soporte4;User Id=sa;Password=hacker2012.L;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analista>(entity =>
            {
                entity.HasKey(e => e.NombreTecnico)
                    .HasName("PK__Analista__ACE810ABE93D0E7A");

                entity.Property(e => e.NombreTecnico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAnalista)
                    .HasColumnName("idAnalista")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

             modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Rol)
                    .HasName("PK__Rol_1");

                entity.Property(e => e.Rol)
                    .HasColumnName("Rol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Categoria1)
                    .HasName("PK__Categori__08015F8A98078CD8");

                entity.Property(e => e.Categoria1)
                    .HasColumnName("Categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("idCAtegoria")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdCorreo)
                    .HasName("PK__Contacto__D247A90932FE9248");

                entity.Property(e => e.IdCorreo).HasColumnName("idCorreo");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Garantia>(entity =>
            {
                entity.HasKey(e => e.Garantia1)
                    .HasName("PK__Garantia__E36D7ADF64C2A0A6");

                entity.Property(e => e.Garantia1)
                    .HasColumnName("Garantia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdGarantia)
                    .HasColumnName("idGarantia")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Marca1)
                    .HasName("PK__Marca__32E2BA4F49D22C3B");

                entity.Property(e => e.Marca1)
                    .HasColumnName("Marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdMarca)
                    .HasColumnName("idMarca")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.Modelo1)
                    .HasName("PK__Modelo__D83E61C1AC2B3940");

                entity.Property(e => e.Modelo1)
                    .HasColumnName("Modelo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdModelo)
                    .HasColumnName("idModelo")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PK__Registro__62FC8F589DB127C0");

                entity.Property(e => e.IdRegistro).HasColumnName("idRegistro");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionRespuesta)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaEntrada)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaSalida).HasColumnType("datetime");

                entity.Property(e => e.Garantia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTecnico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Seriales)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValorTotal).HasColumnType("money");

                entity.Property(e => e.ValorUnidad).HasColumnType("money");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registro_Categoria");

                entity.HasOne(d => d.GarantiaNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.Garantia)
                    .HasConstraintName("FK_Registro_Garantia");

                entity.HasOne(d => d.MarcaNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.Marca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registro_Marca");

                entity.HasOne(d => d.ModeloNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.Modelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registro_Modelo");

                entity.HasOne(d => d.NombreTecnicoNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.NombreTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registro_Analista");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
