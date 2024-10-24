using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string? NombreCompleto { get; set; }

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Rol { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();

    public virtual ICollection<Cotizacione> Cotizaciones { get; set; } = new List<Cotizacione>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();

    public virtual ICollection<QuejasSugerencia> QuejasSugerencia { get; set; } = new List<QuejasSugerencia>();
}
