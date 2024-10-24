using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class PreciosServiciosPreestablecido
{
    public int IdPrecio { get; set; }

    public int? IdServicio { get; set; }

    public decimal Precio { get; set; }

    public DateTime? FechaVigenciaInicio { get; set; }

    public DateTime? FechaVigenciaFin { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }
}
