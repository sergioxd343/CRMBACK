using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string? DescripcionProducto { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();
}
