using System.Linq.Expressions;

namespace ViagemPlanAPI.Infrastructure.Repositories.Interfaces;

public interface IRepository<T>
{
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
}
