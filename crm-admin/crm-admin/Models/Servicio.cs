using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string? DescripcionServicio { get; set; }

    public decimal? Precio { get; set; }

    public bool? Recurrente { get; set; }

    public string? FrecuenciaRecurrencia { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual ICollection<PreciosServiciosPreestablecido> PreciosServiciosPreestablecidos { get; set; } = new List<PreciosServiciosPreestablecido>();
}
