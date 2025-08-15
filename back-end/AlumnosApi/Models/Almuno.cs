using System;
using System.ComponentModel.DataAnnotations;

namespace AlumnosApi.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        public string? NombreAlumno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? NombrePadre { get; set; }
        public string? NombreMadre { get; set; }
        public string? Grado { get; set; }
        public string? Seccion { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}