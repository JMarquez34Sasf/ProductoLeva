using System;
using System.Collections.Generic;

namespace ProductoLeva.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int Plaan { get; set; }

    public int IdPlan { get; set; }

    public string Role { get; set; } = null!;

    public virtual Plane IdPlanNavigation { get; set; } = null!;
}
