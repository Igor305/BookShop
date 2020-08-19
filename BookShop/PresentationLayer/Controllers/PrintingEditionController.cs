using System;
using System.Threading.Tasks;
using BusinessLogicLayer.Models.PrintingEdition;
using BusinessLogicLayer.Models.Response.PrintingEdition;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintingEditionController : ControllerBase
    {
        private readonly IPrintingEditionService _printingEditionService;
        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        [HttpGet("GetAll")]
        public async Task<PrintingEditionResponseModel> GetAll()
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.GetAll();
            return printingEditionResponseModel;
        }

        [HttpGet]
        public async Task<PrintingEditionResponseModel> GetAllWithoutIsDeleted()
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.GetAllWithoutIsDeleted();
            return printingEditionResponseModel;
        }

        [HttpGet("{Id}")]
        public async Task<PrintingEditionResponseModel> GetById(Guid Id)
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.GetById(Id);
            return printingEditionResponseModel;
        }

        [HttpGet("Name/{Name}")]
        public async Task<PrintingEditionResponseModel> GetByName(string Name)
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.GetByName(Name);
            return printingEditionResponseModel;
        }

        [HttpPost]
        public async Task<PrintingEditionResponseModel> Create([FromBody] CreatePrintingEditionModel createPrintingEditionModel)
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.Create(createPrintingEditionModel);
            return printingEditionResponseModel;
        }

        [HttpPut("{Id}")]
        public async Task<PrintingEditionResponseModel> Update(Guid Id, [FromBody] CreatePrintingEditionModel createPrintingEditionModel)
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.Update(Id, createPrintingEditionModel);
            return printingEditionResponseModel;
        }

        [HttpPut("IsDeleted/{Id}")]
        public async Task<PrintingEditionResponseModel> IsDeleted(Guid Id)
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.IsDeleted(Id);
            return printingEditionResponseModel;
        }

        [HttpPut("Restore/{Id}")]
        public async Task<PrintingEditionResponseModel> Restore (Guid Id)
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.Restore(Id);
            return printingEditionResponseModel;
        }

        [HttpDelete("{Id}")]
        public async Task<PrintingEditionResponseModel> Remove (Guid Id)
        {
            PrintingEditionResponseModel printingEditionResponseModel = await _printingEditionService.Remove(Id);
            return printingEditionResponseModel;
        }
    }
}
