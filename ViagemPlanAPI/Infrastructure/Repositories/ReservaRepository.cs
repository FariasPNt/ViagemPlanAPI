using Microsoft.EntityFrameworkCore;
using ViagemPlanAPI.Infrastructure.Persistence;
using ViagemPlanAPI.Infrastructure.Repositories.Interfaces;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Infrastructure.Repositories;

public class ReservaRepository : Repository<Reserva>
{
    private readonly ViagemPlanDbContext _context;
    public ReservaRepository(ViagemPlanDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reserva>> GetReservaPorViagemAsync(int viagemId)
    {
        return await _context.Set<Reserva>()
            .Where(r => r.ViagemId == viagemId)
            .ToListAsync();
    }

}
