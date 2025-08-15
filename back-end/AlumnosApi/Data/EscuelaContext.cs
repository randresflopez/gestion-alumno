    using AlumnosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumnosApi.Data
{
    public class EscuelaContext : DbContext
    {
        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}