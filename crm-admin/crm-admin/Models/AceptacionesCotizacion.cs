using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class AceptacionesCotizacion
{
    public int IdAceptacion { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdCliente { get; set; }

    public DateTime? FechaAceptacion { get; set; }

    public string? Estado { get; set; }

    public string? Comentarios { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Cotizacione? IdCotizacionNavigation { get; set; }
}
