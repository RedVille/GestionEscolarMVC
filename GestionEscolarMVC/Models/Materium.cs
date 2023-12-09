using System;
using System.Collections.Generic;

namespace GestionEscolarMVC.Models;

public partial class Materium
{
    public int Idmateria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Horario { get; set; }
}
