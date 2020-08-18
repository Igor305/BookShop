using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> GetById(Guid Id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
