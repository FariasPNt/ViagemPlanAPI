using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ViagemPlanAPI.Context;
using ViagemPlanAPI.Infrastructure.Repositories.Interfaces;

namespace ViagemPlanAPI.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ViagemPlanDbContext _context;

    public Repository(ViagemPlanDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }
    public T Create(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }
    public T Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }
}
