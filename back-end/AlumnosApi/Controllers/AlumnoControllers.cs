using AlumnosApi.Data;
using AlumnosApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumnosApi.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly EscuelaContext _context;

        public AlumnosController(EscuelaContext context)
        {
            _context = context;
        }

        // POST: api/Alumnos
        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlumno), new { id = alumno.Id }, alumno);
        }

        // GET: api/Alumnos/grado?grado=tercero
        [HttpGet("grado")]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnosPorGrado([FromQuery] string grado)
        {
            if (string.IsNullOrEmpty(grado))
            {
                return BadRequest("Debe especificar un grado para la búsqueda.");
            }

            var alumnos = await _context.Alumnos
                                        .Where(a => a.Grado.ToLower() == grado.ToLower())
                                        .ToListAsync();

            if (!alumnos.Any())
            {
                return NotFound($"No se encontraron alumnos en el grado {grado}.");
            }

            return Ok(alumnos);
        }

        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return alumno;
        }
    }
}