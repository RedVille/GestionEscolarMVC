using System;
using System.Collections.Generic;

namespace GestionEscolarMVC.Models;

public partial class Maestro
{
    public int Idmaestro { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;
    public ICollection<DetalleMaestro>? DetalleMaestros { get; set; }
}
