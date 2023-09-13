using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Paquete
{
    public int Iidpaquete { get; set; }

    public int? Cajon { get; set; }

    public string? Tracking { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? Fechaingreso { get; set; }

    public DateTime? Fechasalida { get; set; }

    public string? Firma { get; set; }
}
