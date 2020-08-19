using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository (ApplicationContext applicationContext): base(applicationContext)
        {

        }

        public async Task<List<Author>> GetAll()
        {
            List<Author> all = await _applicationContext.Authors.ToListAsync();

            return all;
        }

        public async Task<List<Author>> GetAllWithoutIsDeleted()
        {
            List<Author> all = await _applicationContext.Authors.ToListAsync();

            return all;
        }

        public async Task<Author> GetName(string FirstName, string LastName)
        {
            IQueryable<Author> authors = _applicationContext.Authors.Where(x => x.LastName == LastName);
            Author author = await authors.FirstOrDefaultAsync(x => x.FirstName == FirstName);

            return author;
        }
        public IQueryable<Author> Pagination()
        {
            IQueryable<Author> authors = _applicationContext.Authors.Include(x => x.AuthorInPrintingEditions);
            return authors;
        }

    }
}
