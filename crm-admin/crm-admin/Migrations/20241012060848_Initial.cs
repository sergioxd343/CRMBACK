using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crm_admin.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ciudad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    pais = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__clientes__677F38F578B8720C", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_producto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    descripcion_producto = table.Column<string>(type: "text", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__producto__FF341C0D06157CC2", x => x.id_producto);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    id_servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_servicio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    descripcion_servicio = table.Column<string>(type: "text", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    recurrente = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    frecuencia_recurrencia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Mensual"),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__servicio__6FD07FDC551A374D", x => x.id_servicio);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_usuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    nombre_completo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    rol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    password_hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuarios__4E3E04AD4721B8EB", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "clientes_actividad",
                columns: table => new
                {
                    id_actividad_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    total_cotizaciones = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    total_ordenes_compra = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    total_gastado = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    fecha_ultima_interaccion = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado_cliente = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__clientes__7E75FEEFA21021E6", x => x.id_actividad_cliente);
                    table.ForeignKey(
                        name: "FK__clientes___id_cl__70DDC3D8",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                });

            migrationBuilder.CreateTable(
                name: "precios_servicios_preestablecidos",
                columns: table => new
                {
                    id_precio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_servicio = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    fecha_vigencia_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_vigencia_fin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__precios___A70EF6ED0346A07D", x => x.id_precio);
                    table.ForeignKey(
                        name: "FK__precios_s__id_se__4D94879B",
                        column: x => x.id_servicio,
                        principalTable: "servicios",
                        principalColumn: "id_servicio");
                });

            migrationBuilder.CreateTable(
                name: "cotizaciones",
                columns: table => new
                {
                    id_cotizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: true),
                    fecha_cotizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    impuestos = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Pendiente"),
                    archivo_cotizacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cotizaci__9713D1745748D082", x => x.id_cotizacion);
                    table.ForeignKey(
                        name: "FK__cotizacio__id_cl__5070F446",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK__cotizacio__id_us__5165187F",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    id_empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: true),
                    nombre_empleado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    apellido_empleado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email_empleado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono_empleado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    puesto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fecha_contratacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__empleado__88B513943400A147", x => x.id_empleado);
                    table.ForeignKey(
                        name: "FK__empleados__id_us__412EB0B6",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "interacciones",
                columns: table => new
                {
                    id_interaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: true),
                    tipo_interaccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    fecha_interaccion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__interacc__0152426C64E817F6", x => x.id_interaccion);
                    table.ForeignKey(
                        name: "FK__interacci__id_cl__6C190EBB",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK__interacci__id_us__6D0D32F4",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "quejas_sugerencias",
                columns: table => new
                {
                    id_queja_sugerencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: true),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Pendiente"),
                    comentarios_respuesta = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__quejas_s__A4A9E1C313AE240B", x => x.id_queja_sugerencia);
                    table.ForeignKey(
                        name: "FK__quejas_su__id_cl__76969D2E",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK__quejas_su__id_us__778AC167",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "aceptaciones_cotizacion",
                columns: table => new
                {
                    id_aceptacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cotizacion = table.Column<int>(type: "int", nullable: true),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    fecha_aceptacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Pendiente"),
                    comentarios = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aceptaci__5439A8404986EB4B", x => x.id_aceptacion);
                    table.ForeignKey(
                        name: "FK__aceptacio__id_cl__68487DD7",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK__aceptacio__id_co__6754599E",
                        column: x => x.id_cotizacion,
                        principalTable: "cotizaciones",
                        principalColumn: "id_cotizacion");
                });

            migrationBuilder.CreateTable(
                name: "archivos",
                columns: table => new
                {
                    id_archivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cotizacion = table.Column<int>(type: "int", nullable: true),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: true),
                    tipo_archivo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nombre_archivo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ruta_archivo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fecha_subida = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__archivos__9B6964437C3E7BDD", x => x.id_archivo);
                    table.ForeignKey(
                        name: "FK__archivos__id_cli__5BE2A6F2",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK__archivos__id_cot__5AEE82B9",
                        column: x => x.id_cotizacion,
                        principalTable: "cotizaciones",
                        principalColumn: "id_cotizacion");
                    table.ForeignKey(
                        name: "FK__archivos__id_usu__5CD6CB2B",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "detalle_cotizacion",
                columns: table => new
                {
                    id_detalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cotizacion = table.Column<int>(type: "int", nullable: true),
                    id_producto = table.Column<int>(type: "int", nullable: true),
                    id_servicio = table.Column<int>(type: "int", nullable: true),
                    descripcion_personalizada = table.Column<string>(type: "text", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__detalle___4F1332DE4C927331", x => x.id_detalle);
                    table.ForeignKey(
                        name: "FK__detalle_c__id_co__5629CD9C",
                        column: x => x.id_cotizacion,
                        principalTable: "cotizaciones",
                        principalColumn: "id_cotizacion");
                    table.ForeignKey(
                        name: "FK__detalle_c__id_pr__571DF1D5",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "FK__detalle_c__id_se__5812160E",
                        column: x => x.id_servicio,
                        principalTable: "servicios",
                        principalColumn: "id_servicio");
                });

            migrationBuilder.CreateTable(
                name: "ordenes_compra",
                columns: table => new
                {
                    id_orden_compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cotizacion = table.Column<int>(type: "int", nullable: true),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: true),
                    fecha_generacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Pendiente"),
                    archivo_orden_compra = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ordenes___71B729AF1834301A", x => x.id_orden_compra);
                    table.ForeignKey(
                        name: "FK__ordenes_c__id_cl__619B8048",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK__ordenes_c__id_co__60A75C0F",
                        column: x => x.id_cotizacion,
                        principalTable: "cotizaciones",
                        principalColumn: "id_cotizacion");
                    table.ForeignKey(
                        name: "FK__ordenes_c__id_us__628FA481",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_aceptaciones_cotizacion_id_cliente",
                table: "aceptaciones_cotizacion",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_aceptaciones_cotizacion_id_cotizacion",
                table: "aceptaciones_cotizacion",
                column: "id_cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_archivos_id_cliente",
                table: "archivos",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_archivos_id_cotizacion",
                table: "archivos",
                column: "id_cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_archivos_id_usuario",
                table: "archivos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "UQ__clientes__AB6E6164E447BAE8",
                table: "clientes",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_actividad_id_cliente",
                table: "clientes_actividad",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_cotizaciones_id_cliente",
                table: "cotizaciones",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_cotizaciones_id_usuario",
                table: "cotizaciones",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cotizacion_id_cotizacion",
                table: "detalle_cotizacion",
                column: "id_cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cotizacion_id_producto",
                table: "detalle_cotizacion",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cotizacion_id_servicio",
                table: "detalle_cotizacion",
                column: "id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_id_usuario",
                table: "empleados",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "UQ__empleado__9815ABE010D4DBFC",
                table: "empleados",
                column: "email_empleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interacciones_id_cliente",
                table: "interacciones",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_interacciones_id_usuario",
                table: "interacciones",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_compra_id_cliente",
                table: "ordenes_compra",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_compra_id_cotizacion",
                table: "ordenes_compra",
                column: "id_cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_compra_id_usuario",
                table: "ordenes_compra",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_precios_servicios_preestablecidos_id_servicio",
                table: "precios_servicios_preestablecidos",
                column: "id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_quejas_sugerencias_id_cliente",
                table: "quejas_sugerencias",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_quejas_sugerencias_id_usuario",
                table: "quejas_sugerencias",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "UQ__usuarios__AB6E6164FC81089A",
                table: "usuarios",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__usuarios__D4D22D74543A167C",
                table: "usuarios",
                column: "nombre_usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aceptaciones_cotizacion");

            migrationBuilder.DropTable(
                name: "archivos");

            migrationBuilder.DropTable(
                name: "clientes_actividad");

            migrationBuilder.DropTable(
                name: "detalle_cotizacion");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "interacciones");

            migrationBuilder.DropTable(
                name: "ordenes_compra");

            migrationBuilder.DropTable(
                name: "precios_servicios_preestablecidos");

            migrationBuilder.DropTable(
                name: "quejas_sugerencias");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "cotizaciones");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
