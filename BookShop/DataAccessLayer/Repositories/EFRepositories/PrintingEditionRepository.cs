using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class PrintingEditionRepository : GenericRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository (ApplicationContext applicationContext) : base(applicationContext)
        {
            
        }

        public async Task<List<PrintingEdition>> GetAll()
        {
            List<PrintingEdition> printingEditions = await _applicationContext.PrintingEditions.ToListAsync();
            return printingEditions;
        }

        public async Task<List<PrintingEdition>> GetAllWithoutIsDeleted()
        {
            List<PrintingEdition> printingEditions = await _applicationContext.PrintingEditions.ToListAsync();
            return printingEditions;
        }

        public async Task<List<PrintingEdition>> GetByName(string Name)
        {
            IQueryable<PrintingEdition> printings  = _applicationContext.PrintingEditions.Where(w => w.Name == Name);
            List<PrintingEdition> printingEditions = await printings.ToListAsync();

            return printingEditions;
        }
    }
}
