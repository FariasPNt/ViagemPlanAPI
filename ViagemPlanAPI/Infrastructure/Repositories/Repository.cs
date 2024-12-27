using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ViagemPlanAPI.Infrastructure.Persistence;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    public Repository(ViagemPlanDbContext dbContex)
    {
        _dbSet = dbContex.Set<T>();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null
            ? await _dbSet.ToListAsync()
            : await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public T UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

  
}
