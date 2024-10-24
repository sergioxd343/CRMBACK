using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<AceptacionesCotizacion> AceptacionesCotizacions { get; set; } = new List<AceptacionesCotizacion>();

    public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();

    public virtual ICollection<ClientesActividad> ClientesActividads { get; set; } = new List<ClientesActividad>();

    public virtual ICollection<Cotizacione> Cotizaciones { get; set; } = new List<Cotizacione>();

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();

    public virtual ICollection<QuejasSugerencia> QuejasSugerencia { get; set; } = new List<QuejasSugerencia>();
}
