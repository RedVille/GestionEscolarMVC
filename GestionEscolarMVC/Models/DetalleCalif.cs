using System;
using System.Collections.Generic;

namespace GestionEscolarMVC.Models;

public partial class DetalleCalif
{
    public int Id { get; set; }

    public int Idmateria { get; set; }

    public int Idalumno { get; set; }

    public double? Calif1 { get; set; }

    public double? Calif2 { get; set; }

    public double? Calif3 { get; set; }
}
