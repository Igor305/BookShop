using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IGenericRepository<PrintingEdition>
    {
        public Task<List<PrintingEdition>> GetAll();
        public Task<List<PrintingEdition>> GetAllWithoutIsDeleted();
        public Task<List<PrintingEdition>> GetByName(string Name);
    }
}
