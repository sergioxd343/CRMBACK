using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Cotizacione
{
    public int IdCotizacion { get; set; }

    public int? IdCliente { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaCotizacion { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Impuestos { get; set; }

    public decimal? Total { get; set; }

    public string? Estado { get; set; }

    public string? ArchivoCotizacion { get; set; }

    public virtual ICollection<AceptacionesCotizacion> AceptacionesCotizacions { get; set; } = new List<AceptacionesCotizacion>();

    public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();
}
