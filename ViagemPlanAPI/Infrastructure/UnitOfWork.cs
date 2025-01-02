using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ViagemPlanAPI.Infrastructure.Persistence;
using ViagemPlanAPI.Infrastructure.Repositories;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ViagemPlanDbContext _viagemContext;
    private readonly Dictionary<Type, object> _repositories = new();
    private IDbContextTransaction _transaction;

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

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _viagemContext.SaveChangesAsync(cancellationToken);
    }


    public void BeginTransaction()
    {
        _transaction = _viagemContext.Database.BeginTransaction();
    }

    public async Task CommitAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Transação não iniciada");
        }
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task RollbackAsync()
    {
        if (_transaction == null) throw new InvalidOperationException("Transação não iniciada");
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public void Dispose()
    {
        _viagemContext.Dispose();
    }

}
