using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int? IdUsuario { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string? ApellidoEmpleado { get; set; }

    public string EmailEmpleado { get; set; } = null!;

    public string? TelefonoEmpleado { get; set; }

    public string? Puesto { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
