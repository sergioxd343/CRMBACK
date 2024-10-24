using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class DetalleCotizacion
{
    public int IdDetalle { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdProducto { get; set; }

    public int? IdServicio { get; set; }

    public string? DescripcionPersonalizada { get; set; }

    public int Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Total { get; set; }

    public virtual Cotizacione? IdCotizacionNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }
}
