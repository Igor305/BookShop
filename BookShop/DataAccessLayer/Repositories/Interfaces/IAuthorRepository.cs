using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<List<Author>> GetAll();
        Task<List<Author>> GetAllWithoutIsDeleted();
        Task<Author> GetByName(string FirstName, string LastName);
        IQueryable<Author> Pagination();
    }
}
