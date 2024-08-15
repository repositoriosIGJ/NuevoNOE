using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.Model.Seguridad;


namespace NUEVO.NOE.API.Models;

public partial class SeguridadDbContext : DbContext
{
    public SeguridadDbContext()
    {
    }

    public SeguridadDbContext(DbContextOptions<SeguridadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Funcion> Funciones { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<RolFuncion> RolFunciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_area");

            entity.ToTable("Area");

            entity.Property(e => e.Acronimo).HasMaxLength(60);
            entity.Property(e => e.Descripcion).HasMaxLength(60);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Areas)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK_area_dpto");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dpto");
            entity.ToTable("Departamento");
            entity.Property(e => e.Acronimo).HasMaxLength(10);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.HasMany(d => d.Roles)
                  .WithOne(p => p.Departamento)
                  .HasForeignKey(p => p.IdDepartamento)
                  .HasConstraintName("FK_Rol_Departamento");
        });

        modelBuilder.Entity<Funcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_funcion");

            entity.ToTable("Funcion");

            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Tooltip).HasMaxLength(255);
            entity.Property(e => e.Url).HasMaxLength(255);
        });
        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_rol");
            entity.ToTable("Rol");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.HasOne(d => d.Departamento)
                  .WithMany(p => p.Roles)
                  .HasForeignKey(d => d.IdDepartamento)
                  .HasConstraintName("FK_Rol_Departamento");
        });


        modelBuilder.Entity<RolFuncion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RolFuncion");

            entity.Property(e => e.Funid).HasColumnName("funid");
            entity.Property(e => e.Rolid).HasColumnName("rolid");

            entity.HasOne(d => d.Funcion).WithMany()
                .HasForeignKey(d => d.Funid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_rol_funciones_funcion");

            entity.HasOne(d => d.Rol).WithMany()
                .HasForeignKey(d => d.Rolid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_rol_funciones_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_usuario");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.IdDpto).HasColumnName("id_dpto");
            entity.Property(e => e.Ipbloqueo).HasMaxLength(20);
            entity.Property(e => e.NameActiveDirectory).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Ultimoacceso).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(20);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDpto)
                .HasConstraintName("FK_usuario_dpto");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsuarioRol");

            entity.Property(e => e.Fechaalta)
                .HasColumnType("datetime")
                .HasColumnName("fechaalta");
            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Usrid).HasColumnName("usrid");

            entity.HasOne(d => d.Rol).WithMany()
                .HasForeignKey(d => d.Rolid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_usuario_roles_usuario");

            entity.HasOne(d => d.Usr).WithMany()
                .HasForeignKey(d => d.Usrid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_usuario_roles_usuario1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
