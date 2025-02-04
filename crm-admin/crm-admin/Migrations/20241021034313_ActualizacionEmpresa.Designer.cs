﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crm_admin.Models;

#nullable disable

namespace crm_admin.Migrations
{
    [DbContext(typeof(AdminSoftliContext))]
    [Migration("20241021034313_ActualizacionEmpresa")]
    partial class ActualizacionEmpresa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("crm_admin.Models.AceptacionesCotizacion", b =>
                {
                    b.Property<int>("IdAceptacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_aceptacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAceptacion"));

                    b.Property<string>("Comentarios")
                        .HasColumnType("text")
                        .HasColumnName("comentarios");

                    b.Property<string>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Pendiente")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaAceptacion")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_aceptacion");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdCotizacion")
                        .HasColumnType("int")
                        .HasColumnName("id_cotizacion");

                    b.HasKey("IdAceptacion")
                        .HasName("PK__aceptaci__5439A8404986EB4B");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdCotizacion");

                    b.ToTable("aceptaciones_cotizacion", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Archivo", b =>
                {
                    b.Property<int>("IdArchivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_archivo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArchivo"));

                    b.Property<DateTime?>("FechaSubida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_subida")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdCotizacion")
                        .HasColumnType("int")
                        .HasColumnName("id_cotizacion");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<string>("NombreArchivo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre_archivo");

                    b.Property<string>("RutaArchivo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ruta_archivo");

                    b.Property<string>("TipoArchivo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo_archivo");

                    b.HasKey("IdArchivo")
                        .HasName("PK__archivos__9B6964437C3E7BDD");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdCotizacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("archivos", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("apellido");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ciudad");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_registro")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Pais")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("pais");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefono");

                    b.HasKey("IdCliente")
                        .HasName("PK__clientes__677F38F578B8720C");

                    b.HasIndex(new[] { "Email" }, "UQ__clientes__AB6E6164E447BAE8")
                        .IsUnique();

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.ClientesActividad", b =>
                {
                    b.Property<int>("IdActividadCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_actividad_cliente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdActividadCliente"));

                    b.Property<string>("EstadoCliente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("estado_cliente");

                    b.Property<DateTime?>("FechaUltimaInteraccion")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_ultima_interaccion");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("TotalCotizaciones")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("total_cotizaciones");

                    b.Property<decimal?>("TotalGastado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("total_gastado");

                    b.Property<int?>("TotalOrdenesCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("total_ordenes_compra");

                    b.HasKey("IdActividadCliente")
                        .HasName("PK__clientes__7E75FEEFA21021E6");

                    b.HasIndex("IdCliente");

                    b.ToTable("clientes_actividad", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Cotizacione", b =>
                {
                    b.Property<int>("IdCotizacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_cotizacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCotizacion"));

                    b.Property<string>("ArchivoCotizacion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("archivo_cotizacion");

                    b.Property<string>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Pendiente")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaCotizacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_cotizacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<decimal?>("Impuestos")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("impuestos");

                    b.Property<decimal?>("Subtotal")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("subtotal");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("total");

                    b.HasKey("IdCotizacion")
                        .HasName("PK__cotizaci__9713D1745748D082");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("cotizaciones", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.DetalleCotizacion", b =>
                {
                    b.Property<int>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detalle");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalle"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<string>("DescripcionPersonalizada")
                        .HasColumnType("text")
                        .HasColumnName("descripcion_personalizada");

                    b.Property<int?>("IdCotizacion")
                        .HasColumnType("int")
                        .HasColumnName("id_cotizacion");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int")
                        .HasColumnName("id_producto");

                    b.Property<int?>("IdServicio")
                        .HasColumnType("int")
                        .HasColumnName("id_servicio");

                    b.Property<decimal?>("PrecioUnitario")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("precio_unitario");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("total");

                    b.HasKey("IdDetalle")
                        .HasName("PK__detalle___4F1332DE4C927331");

                    b.HasIndex("IdCotizacion");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdServicio");

                    b.ToTable("detalle_cotizacion", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_empleado");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("ApellidoEmpleado")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("apellido_empleado");

                    b.Property<string>("EmailEmpleado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email_empleado");

                    b.Property<DateTime?>("FechaContratacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_contratacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre_empleado");

                    b.Property<string>("Puesto")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("puesto");

                    b.Property<string>("TelefonoEmpleado")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefono_empleado");

                    b.HasKey("IdEmpleado")
                        .HasName("PK__empleado__88B513943400A147");

                    b.HasIndex("IdUsuario");

                    b.HasIndex(new[] { "EmailEmpleado" }, "UQ__empleado__9815ABE010D4DBFC")
                        .IsUnique();

                    b.ToTable("empleados", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Interaccione", b =>
                {
                    b.Property<int>("IdInteraccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_interaccion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInteraccion"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<DateTime?>("FechaInteraccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_interaccion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<string>("TipoInteraccion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo_interaccion");

                    b.HasKey("IdInteraccion")
                        .HasName("PK__interacc__0152426C64E817F6");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("interacciones", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.OrdenesCompra", b =>
                {
                    b.Property<int>("IdOrdenCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_orden_compra");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrdenCompra"));

                    b.Property<string>("ArchivoOrdenCompra")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("archivo_orden_compra");

                    b.Property<string>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Pendiente")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaGeneracion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_generacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdCotizacion")
                        .HasColumnType("int")
                        .HasColumnName("id_cotizacion");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("total");

                    b.HasKey("IdOrdenCompra")
                        .HasName("PK__ordenes___71B729AF1834301A");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdCotizacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ordenes_compra", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.PreciosServiciosPreestablecido", b =>
                {
                    b.Property<int>("IdPrecio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_precio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrecio"));

                    b.Property<DateTime?>("FechaVigenciaFin")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_vigencia_fin");

                    b.Property<DateTime?>("FechaVigenciaInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_vigencia_inicio");

                    b.Property<int?>("IdServicio")
                        .HasColumnType("int")
                        .HasColumnName("id_servicio");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("precio");

                    b.HasKey("IdPrecio")
                        .HasName("PK__precios___A70EF6ED0346A07D");

                    b.HasIndex("IdServicio");

                    b.ToTable("precios_servicios_preestablecidos", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_producto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("DescripcionProducto")
                        .HasColumnType("text")
                        .HasColumnName("descripcion_producto");

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_creacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre_producto");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("precio");

                    b.Property<int?>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("stock");

                    b.HasKey("IdProducto")
                        .HasName("PK__producto__FF341C0D06157CC2");

                    b.ToTable("productos", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.QuejasSugerencia", b =>
                {
                    b.Property<int>("IdQuejaSugerencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_queja_sugerencia");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdQuejaSugerencia"));

                    b.Property<string>("ComentariosRespuesta")
                        .HasColumnType("text")
                        .HasColumnName("comentarios_respuesta");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<string>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Pendiente")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_registro")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo");

                    b.HasKey("IdQuejaSugerencia")
                        .HasName("PK__quejas_s__A4A9E1C313AE240B");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("quejas_sugerencias", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_servicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"));

                    b.Property<string>("DescripcionServicio")
                        .HasColumnType("text")
                        .HasColumnName("descripcion_servicio");

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_creacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("FrecuenciaRecurrencia")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Mensual")
                        .HasColumnName("frecuencia_recurrencia");

                    b.Property<string>("NombreServicio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre_servicio");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("precio");

                    b.Property<bool?>("Recurrente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("recurrente");

                    b.HasKey("IdServicio")
                        .HasName("PK__servicio__6FD07FDC551A374D");

                    b.ToTable("servicios", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_creacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre_completo");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre_usuario");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password_hash");

                    b.Property<string>("Rol")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("rol");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefono");

                    b.HasKey("IdUsuario")
                        .HasName("PK__usuarios__4E3E04AD4721B8EB");

                    b.HasIndex(new[] { "Email" }, "UQ__usuarios__AB6E6164FC81089A")
                        .IsUnique();

                    b.HasIndex(new[] { "NombreUsuario" }, "UQ__usuarios__D4D22D74543A167C")
                        .IsUnique();

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("crm_admin.Models.AceptacionesCotizacion", b =>
                {
                    b.HasOne("crm_admin.Models.Cliente", "IdClienteNavigation")
                        .WithMany("AceptacionesCotizacions")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__aceptacio__id_cl__68487DD7");

                    b.HasOne("crm_admin.Models.Cotizacione", "IdCotizacionNavigation")
                        .WithMany("AceptacionesCotizacions")
                        .HasForeignKey("IdCotizacion")
                        .HasConstraintName("FK__aceptacio__id_co__6754599E");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdCotizacionNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.Archivo", b =>
                {
                    b.HasOne("crm_admin.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Archivos")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__archivos__id_cli__5BE2A6F2");

                    b.HasOne("crm_admin.Models.Cotizacione", "IdCotizacionNavigation")
                        .WithMany("Archivos")
                        .HasForeignKey("IdCotizacion")
                        .HasConstraintName("FK__archivos__id_cot__5AEE82B9");

                    b.HasOne("crm_admin.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Archivos")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__archivos__id_usu__5CD6CB2B");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdCotizacionNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.ClientesActividad", b =>
                {
                    b.HasOne("crm_admin.Models.Cliente", "IdClienteNavigation")
                        .WithMany("ClientesActividads")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__clientes___id_cl__70DDC3D8");

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.Cotizacione", b =>
                {
                    b.HasOne("crm_admin.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__cotizacio__id_cl__5070F446");

                    b.HasOne("crm_admin.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__cotizacio__id_us__5165187F");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.DetalleCotizacion", b =>
                {
                    b.HasOne("crm_admin.Models.Cotizacione", "IdCotizacionNavigation")
                        .WithMany("DetalleCotizacions")
                        .HasForeignKey("IdCotizacion")
                        .HasConstraintName("FK__detalle_c__id_co__5629CD9C");

                    b.HasOne("crm_admin.Models.Producto", "IdProductoNavigation")
                        .WithMany("DetalleCotizacions")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK__detalle_c__id_pr__571DF1D5");

                    b.HasOne("crm_admin.Models.Servicio", "IdServicioNavigation")
                        .WithMany("DetalleCotizacions")
                        .HasForeignKey("IdServicio")
                        .HasConstraintName("FK__detalle_c__id_se__5812160E");

                    b.Navigation("IdCotizacionNavigation");

                    b.Navigation("IdProductoNavigation");

                    b.Navigation("IdServicioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.Empleado", b =>
                {
                    b.HasOne("crm_admin.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__empleados__id_us__412EB0B6");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.Interaccione", b =>
                {
                    b.HasOne("crm_admin.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Interacciones")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__interacci__id_cl__6C190EBB");

                    b.HasOne("crm_admin.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Interacciones")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__interacci__id_us__6D0D32F4");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.OrdenesCompra", b =>
                {
                    b.HasOne("crm_admin.Models.Cliente", "IdClienteNavigation")
                        .WithMany("OrdenesCompras")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__ordenes_c__id_cl__619B8048");

                    b.HasOne("crm_admin.Models.Cotizacione", "IdCotizacionNavigation")
                        .WithMany("OrdenesCompras")
                        .HasForeignKey("IdCotizacion")
                        .HasConstraintName("FK__ordenes_c__id_co__60A75C0F");

                    b.HasOne("crm_admin.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("OrdenesCompras")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__ordenes_c__id_us__628FA481");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdCotizacionNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.PreciosServiciosPreestablecido", b =>
                {
                    b.HasOne("crm_admin.Models.Servicio", "IdServicioNavigation")
                        .WithMany("PreciosServiciosPreestablecidos")
                        .HasForeignKey("IdServicio")
                        .HasConstraintName("FK__precios_s__id_se__4D94879B");

                    b.Navigation("IdServicioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.QuejasSugerencia", b =>
                {
                    b.HasOne("crm_admin.Models.Cliente", "IdClienteNavigation")
                        .WithMany("QuejasSugerencia")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__quejas_su__id_cl__76969D2E");

                    b.HasOne("crm_admin.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("QuejasSugerencia")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__quejas_su__id_us__778AC167");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("crm_admin.Models.Cliente", b =>
                {
                    b.Navigation("AceptacionesCotizacions");

                    b.Navigation("Archivos");

                    b.Navigation("ClientesActividads");

                    b.Navigation("Cotizaciones");

                    b.Navigation("Interacciones");

                    b.Navigation("OrdenesCompras");

                    b.Navigation("QuejasSugerencia");
                });

            modelBuilder.Entity("crm_admin.Models.Cotizacione", b =>
                {
                    b.Navigation("AceptacionesCotizacions");

                    b.Navigation("Archivos");

                    b.Navigation("DetalleCotizacions");

                    b.Navigation("OrdenesCompras");
                });

            modelBuilder.Entity("crm_admin.Models.Producto", b =>
                {
                    b.Navigation("DetalleCotizacions");
                });

            modelBuilder.Entity("crm_admin.Models.Servicio", b =>
                {
                    b.Navigation("DetalleCotizacions");

                    b.Navigation("PreciosServiciosPreestablecidos");
                });

            modelBuilder.Entity("crm_admin.Models.Usuario", b =>
                {
                    b.Navigation("Archivos");

                    b.Navigation("Cotizaciones");

                    b.Navigation("Empleados");

                    b.Navigation("Interacciones");

                    b.Navigation("OrdenesCompras");

                    b.Navigation("QuejasSugerencia");
                });
#pragma warning restore 612, 618
        }
    }
}
