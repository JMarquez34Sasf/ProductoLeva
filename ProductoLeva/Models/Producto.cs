using System;
using System.Collections.Generic;

namespace ProductoLeva.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public string Estado { get; set; } = null!;

    public string Detalle { get; set; } = null!;
}
