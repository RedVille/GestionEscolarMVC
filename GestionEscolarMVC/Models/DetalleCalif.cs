using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace GestionEscolarMVC.Models;

public partial class DetalleCalif
{
    public int Id { get; set; }

    public int Idmateria { get; set; }

    public int Idalumno { get; set; }

    public double? Calif1 { get; set; }

    public double? Calif2 { get; set; }

    public double? Calif3 { get; set; }

    public Materium? Materium { get; set; }
    public Alumno? Alumno { get; set; }

    public double? Promedio
    {
        get
        {
            // Filtra las calificaciones que no son nulas
            List<double> calificaciones = new List<double> { Calif1 ?? 0, Calif2 ?? 0, Calif3 ?? 0 };

            // Calcula el promedio solo si hay calificaciones
            if (calificaciones.Count > 0)
            {
                return Math.Round(calificaciones.Average(), 1); 
            }

            // Si no hay calificaciones, devuelve null
            return null;
        }
    }
}
