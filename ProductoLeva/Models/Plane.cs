using System;
using System.Collections.Generic;

namespace ProductoLeva.Models;

public partial class Plane
{
    public int IdPlan { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Valor { get; set; }

    public string Frecuencia { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public int Plaan { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
