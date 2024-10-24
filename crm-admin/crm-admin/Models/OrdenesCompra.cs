using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class OrdenesCompra
{
    public int IdOrdenCompra { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdCliente { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public decimal? Total { get; set; }

    public string? Estado { get; set; }

    public string? ArchivoOrdenCompra { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Cotizacione? IdCotizacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
