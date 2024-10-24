using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Archivo
{
    public int IdArchivo { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdCliente { get; set; }

    public int? IdUsuario { get; set; }

    public string? TipoArchivo { get; set; }

    public string? NombreArchivo { get; set; }

    public string? RutaArchivo { get; set; }

    public DateTime? FechaSubida { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Cotizacione? IdCotizacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
