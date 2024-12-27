using Microsoft.EntityFrameworkCore;
using ViagemPlanAPI.Infrastructure.Persistence;
using ViagemPlanAPI.Infrastructure.Repositories;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ViagemPlanDbContext _viagemContext;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ViagemPlanDbContext viagemContext)
    {
        _viagemContext = viagemContext;
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        if (!_repositories.ContainsKey(typeof(T)))
        {
            var repository = new Repository<T>(_viagemContext);
            _repositories[typeof(T)] = repository;
        }
        return (IRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _viagemContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _viagemContext.Dispose();
    }

}
