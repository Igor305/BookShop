using BusinessLogicLayer.Models.PrintingEdition;
using BusinessLogicLayer.Models.Response.PrintingEdition;
using System;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<PrintingEditionResponseModel> GetAll();
        public Task<PrintingEditionResponseModel> GetAllWithoutIsDeleted();
        public Task<PrintingEditionResponseModel> GetById(Guid Id);
        public Task<PrintingEditionResponseModel> GetByName(string Name);
        public Task<PrintingEditionResponseModel> Create(CreatePrintingEditionModel createPrintingEditionModel);
        public Task<PrintingEditionResponseModel> Update(Guid Id, CreatePrintingEditionModel createPrintingEditionModel);
        public Task<PrintingEditionResponseModel> IsDeleted(Guid Id);
        public Task<PrintingEditionResponseModel> Restore(Guid Id);
        public Task<PrintingEditionResponseModel> Remove(Guid Id);

    }
}
