using System;
using System.Collections.Generic;

namespace GestionEscolarMVC.Models;

public partial class Alumno
{
    public int Idalumno { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;
    public ICollection<DetalleCalif>? DetalleCalifs { get; set; }
}
