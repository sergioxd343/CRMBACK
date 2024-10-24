using System;
using System.Collections.Generic;

namespace crm_admin.Models;

public partial class Interaccione
{
    public int IdInteraccion { get; set; }

    public int? IdCliente { get; set; }

    public int? IdUsuario { get; set; }

    public string? TipoInteraccion { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInteraccion { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
