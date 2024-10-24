using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace crm_admin.Models;

public partial class AdminSoftliContext : DbContext
{
    public AdminSoftliContext()
    {
    }

    public AdminSoftliContext(DbContextOptions<AdminSoftliContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AceptacionesCotizacion> AceptacionesCotizacions { get; set; }

    public virtual DbSet<Archivo> Archivos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClientesActividad> ClientesActividads { get; set; }

    public virtual DbSet<Cotizacione> Cotizaciones { get; set; }

    public virtual DbSet<DetalleCotizacion> DetalleCotizacions { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Interaccione> Interacciones { get; set; }

    public virtual DbSet<OrdenesCompra> OrdenesCompras { get; set; }

    public virtual DbSet<PreciosServiciosPreestablecido> PreciosServiciosPreestablecidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<QuejasSugerencia> QuejasSugerencias { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5113.site4now.net;Initial Catalog=db_aae91b_adminsoftli;User Id=db_aae91b_adminsoftli_admin;Password=10012003;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AceptacionesCotizacion>(entity =>
        {
            entity.HasKey(e => e.IdAceptacion).HasName("PK__aceptaci__5439A8404986EB4B");

            entity.ToTable("aceptaciones_cotizacion");

            entity.Property(e => e.IdAceptacion).HasColumnName("id_aceptacion");
            entity.Property(e => e.Comentarios)
                .HasColumnType("text")
                .HasColumnName("comentarios");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaAceptacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_aceptacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.AceptacionesCotizacions)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__aceptacio__id_cl__68487DD7");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.AceptacionesCotizacions)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK__aceptacio__id_co__6754599E");
        });

        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.IdArchivo).HasName("PK__archivos__9B6964437C3E7BDD");

            entity.ToTable("archivos");

            entity.Property(e => e.IdArchivo).HasColumnName("id_archivo");
            entity.Property(e => e.FechaSubida)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_subida");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_archivo");
            entity.Property(e => e.RutaArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_archivo");
            entity.Property(e => e.TipoArchivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_archivo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__archivos__id_cli__5BE2A6F2");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK__archivos__id_cot__5AEE82B9");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__archivos__id_usu__5CD6CB2B");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__677F38F578B8720C");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Email, "UQ__clientes__AB6E6164E447BAE8").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<ClientesActividad>(entity =>
        {
            entity.HasKey(e => e.IdActividadCliente).HasName("PK__clientes__7E75FEEFA21021E6");

            entity.ToTable("clientes_actividad");

            entity.Property(e => e.IdActividadCliente).HasColumnName("id_actividad_cliente");
            entity.Property(e => e.EstadoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_cliente");
            entity.Property(e => e.FechaUltimaInteraccion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_interaccion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.TotalCotizaciones)
                .HasDefaultValue(0)
                .HasColumnName("total_cotizaciones");
            entity.Property(e => e.TotalGastado)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_gastado");
            entity.Property(e => e.TotalOrdenesCompra)
                .HasDefaultValue(0)
                .HasColumnName("total_ordenes_compra");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClientesActividads)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__clientes___id_cl__70DDC3D8");
        });

        modelBuilder.Entity<Cotizacione>(entity =>
        {
            entity.HasKey(e => e.IdCotizacion).HasName("PK__cotizaci__9713D1745748D082");

            entity.ToTable("cotizaciones");

            entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");
            entity.Property(e => e.ArchivoCotizacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("archivo_cotizacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCotizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_cotizacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Impuestos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("impuestos");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cotizaciones)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__cotizacio__id_cl__5070F446");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cotizaciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__cotizacio__id_us__5165187F");
        });

        modelBuilder.Entity<DetalleCotizacion>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__detalle___4F1332DE4C927331");

            entity.ToTable("detalle_cotizacion");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DescripcionPersonalizada)
                .HasColumnType("text")
                .HasColumnName("descripcion_personalizada");
            entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK__detalle_c__id_co__5629CD9C");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__detalle_c__id_pr__571DF1D5");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__detalle_c__id_se__5812160E");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__88B513943400A147");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.EmailEmpleado, "UQ__empleado__9815ABE010D4DBFC").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.ApellidoEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido_empleado");
            entity.Property(e => e.EmailEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_empleado");
            entity.Property(e => e.FechaContratacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_contratacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_empleado");
            entity.Property(e => e.Puesto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("puesto");
            entity.Property(e => e.TelefonoEmpleado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_empleado");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__empleados__id_us__412EB0B6");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__empresas__4A0B7E2CE6618058");

            entity.ToTable("empresas");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.DireccionEmpresa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion_empresa");
            entity.Property(e => e.EmailEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_empresa");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_empresa");
            entity.Property(e => e.TelefonoEmpresa)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_empresa");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_empresas_clientes");
        });

        modelBuilder.Entity<Interaccione>(entity =>
        {
            entity.HasKey(e => e.IdInteraccion).HasName("PK__interacc__0152426C64E817F6");

            entity.ToTable("interacciones");

            entity.Property(e => e.IdInteraccion).HasColumnName("id_interaccion");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaInteraccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_interaccion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.TipoInteraccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_interaccion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__interacci__id_cl__6C190EBB");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__interacci__id_us__6D0D32F4");
        });

        modelBuilder.Entity<OrdenesCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra).HasName("PK__ordenes___71B729AF1834301A");

            entity.ToTable("ordenes_compra");

            entity.Property(e => e.IdOrdenCompra).HasColumnName("id_orden_compra");
            entity.Property(e => e.ArchivoOrdenCompra)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("archivo_orden_compra");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaGeneracion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__ordenes_c__id_cl__619B8048");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK__ordenes_c__id_co__60A75C0F");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__ordenes_c__id_us__628FA481");
        });

        modelBuilder.Entity<PreciosServiciosPreestablecido>(entity =>
        {
            entity.HasKey(e => e.IdPrecio).HasName("PK__precios___A70EF6ED0346A07D");

            entity.ToTable("precios_servicios_preestablecidos");

            entity.Property(e => e.IdPrecio).HasColumnName("id_precio");
            entity.Property(e => e.FechaVigenciaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_vigencia_fin");
            entity.Property(e => e.FechaVigenciaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_vigencia_inicio");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.PreciosServiciosPreestablecidos)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__precios_s__id_se__4D94879B");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0D06157CC2");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.DescripcionProducto)
                .HasColumnType("text")
                .HasColumnName("descripcion_producto");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasColumnName("stock");
        });

        modelBuilder.Entity<QuejasSugerencia>(entity =>
        {
            entity.HasKey(e => e.IdQuejaSugerencia).HasName("PK__quejas_s__A4A9E1C313AE240B");

            entity.ToTable("quejas_sugerencias");

            entity.Property(e => e.IdQuejaSugerencia).HasColumnName("id_queja_sugerencia");
            entity.Property(e => e.ComentariosRespuesta)
                .HasColumnType("text")
                .HasColumnName("comentarios_respuesta");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.QuejasSugerencia)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__quejas_su__id_cl__76969D2E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.QuejasSugerencia)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__quejas_su__id_us__778AC167");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__servicio__6FD07FDC551A374D");

            entity.ToTable("servicios");

            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.DescripcionServicio)
                .HasColumnType("text")
                .HasColumnName("descripcion_servicio");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FrecuenciaRecurrencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Mensual")
                .HasColumnName("frecuencia_recurrencia");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_servicio");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Recurrente)
                .HasDefaultValue(false)
                .HasColumnName("recurrente");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD4721B8EB");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164FC81089A").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__usuarios__D4D22D74543A167C").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
