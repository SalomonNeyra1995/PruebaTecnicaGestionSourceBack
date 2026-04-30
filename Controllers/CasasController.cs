using Casas.Core.DTOs;
using Casas.Core.Entities;
using Casas.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaGestionSource.Controllers;  // ← Ajusta el namespace si tu proyecto se llama diferente

[Route("api/[controller]")]
[ApiController]
public class CasasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CasasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/casas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CasaResponseDto>>> GetCasas()
    {
        var casas = await _context.Casas
            .Where(c => c.EstaActivo)
            .Select(c => new CasaResponseDto
            {
                Id = c.Id,
                Direccion = c.Direccion,
                Distrito = c.Distrito,
                NumeroHabitaciones = c.NumeroHabitaciones,
                TipoCasa = c.TipoCasa,
                AreaMetrosCuadrados = c.AreaMetrosCuadrados,
                Precio = c.Precio,
                FechaRegistro = c.FechaRegistro
            })
            .ToListAsync();

        return Ok(casas);
    }

    // GET: api/casas/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CasaResponseDto>> GetCasa(int id)
    {
        var casa = await _context.Casas
            .Where(c => c.Id == id && c.EstaActivo)
            .Select(c => new CasaResponseDto
            {
                Id = c.Id,
                Direccion = c.Direccion,
                Distrito = c.Distrito,
                NumeroHabitaciones = c.NumeroHabitaciones,
                TipoCasa = c.TipoCasa,
                AreaMetrosCuadrados = c.AreaMetrosCuadrados,
                Precio = c.Precio,
                FechaRegistro = c.FechaRegistro
            })
            .FirstOrDefaultAsync();

        if (casa == null) return NotFound();
        return Ok(casa);
    }

    // POST: api/casas
    [HttpPost]
    public async Task<ActionResult<CasaResponseDto>> CreateCasa(CasaCreateDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var casa = new Casa
        {
            Direccion = createDto.Direccion,
            Distrito = createDto.Distrito,
            NumeroHabitaciones = createDto.NumeroHabitaciones,
            TipoCasa = createDto.TipoCasa,
            AreaMetrosCuadrados = createDto.AreaMetrosCuadrados,
            Precio = createDto.Precio,
            FechaRegistro = DateTime.UtcNow,
            EstaActivo = true
        };

        _context.Casas.Add(casa);
        await _context.SaveChangesAsync();

        var response = new CasaResponseDto
        {
            Id = casa.Id,
            Direccion = casa.Direccion,
            Distrito = casa.Distrito,
            NumeroHabitaciones = casa.NumeroHabitaciones,
            TipoCasa = casa.TipoCasa,
            AreaMetrosCuadrados = casa.AreaMetrosCuadrados,
            Precio = casa.Precio,
            FechaRegistro = casa.FechaRegistro
        };

        return CreatedAtAction(nameof(GetCasa), new { id = casa.Id }, response);
    }

    // PUT: api/casas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCasa(int id, CasaUpdateDto updateDto)
    {
        if (id != updateDto.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo");

        var casa = await _context.Casas.FirstOrDefaultAsync(c => c.Id == id && c.EstaActivo);
        if (casa == null) return NotFound();

        casa.Direccion = updateDto.Direccion;
        casa.Distrito = updateDto.Distrito;
        casa.NumeroHabitaciones = updateDto.NumeroHabitaciones;
        casa.TipoCasa = updateDto.TipoCasa;
        casa.AreaMetrosCuadrados = updateDto.AreaMetrosCuadrados;
        casa.Precio = updateDto.Precio;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/casas/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCasa(int id)
    {
        var casa = await _context.Casas.FirstOrDefaultAsync(c => c.Id == id && c.EstaActivo);
        if (casa == null) return NotFound();

        casa.EstaActivo = false;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}