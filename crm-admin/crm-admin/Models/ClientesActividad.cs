using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class ClientesActividad
{
    public int IdActividadCliente { get; set; }

    public int? IdCliente { get; set; }

    public int? TotalCotizaciones { get; set; }

    public int? TotalOrdenesCompra { get; set; }

    public decimal? TotalGastado { get; set; }

    public DateTime? FechaUltimaInteraccion { get; set; }

    public string? EstadoCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
