using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViagemPlanAPI.Application.DTOs.ReservaDTOs;
using ViagemPlanAPI.Application.Services.Interfaces;

namespace ViagemPlanAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservaController : ControllerBase
{
    private readonly IReservaService _reservaService;

    public ReservaController(IReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReservaById(int id)
    {
        var reserva = await _reservaService.GetReservaByIdAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return Ok(reserva);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReserva([FromBody] CreateReservaDTO reservaDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var novaReserva = await _reservaService.CreateReservaAsync(reservaDto);
        return CreatedAtAction(nameof(GetReservaById), new { id = novaReserva.Id }, novaReserva);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReserva(int id, [FromBody] UpdateReservaDto reservaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var atualizada = await _reservaService.UpdateReservaAsync(id, reservaDto);
        if(atualizada == null)
            return NotFound();

        return Ok(atualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReserva(int id)
    {
        var deletada = await _reservaService.DeleteReservaAsync(id);
        if (!deletada)
            return NotFound();

        return NoContent();
    }

}
