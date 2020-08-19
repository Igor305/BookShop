using AutoMapper;
using BusinessLogicLayer.Models.PrintingEdition;
using BusinessLogicLayer.Models.Response.PrintingEdition;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class PrintingEditionService :  IPrintingEditionService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IMapper _mapper;
        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository, IMapper mapper)
        {
            _printingEditionRepository = printingEditionRepository;
            _mapper = mapper;
        }

        public async Task<PrintingEditionResponseModel> GetAll()
        {
            List<PrintingEdition> printingEditions = await _printingEditionRepository.GetAll();

            List<PrintingEditionModel> printingEditionModels = _mapper.Map<List<PrintingEdition>, List<PrintingEditionModel>>(printingEditions);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            printingEditionResponseModel.printingEditionModel = printingEditionModels;

            return printingEditionResponseModel;
        }

        public async Task<PrintingEditionResponseModel> GetAllWithoutIsDeleted()
        {
            List<PrintingEdition> printingEditions = await _printingEditionRepository.GetAllWithoutIsDeleted();

            List<PrintingEditionModel> printingEditionModels = _mapper.Map<List<PrintingEdition>, List<PrintingEditionModel>>(printingEditions);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            printingEditionResponseModel.printingEditionModel = printingEditionModels;

            return printingEditionResponseModel;
        }

        public async Task<PrintingEditionResponseModel> GetById(Guid Id)
        {
            PrintingEdition printingEdition = await _printingEditionRepository.GetById(Id);

            PrintingEditionModel printingEditionModel = _mapper.Map<PrintingEdition, PrintingEditionModel>(printingEdition);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            printingEditionResponseModel.printingEditionModel.Add(printingEditionModel);

            return printingEditionResponseModel;
        }

        public async Task<PrintingEditionResponseModel> GetByName(string Name)
        {
            List<PrintingEdition> printingEditions = await _printingEditionRepository.GetByName(Name);

            List<PrintingEditionModel> printingEditionModels = _mapper.Map<List<PrintingEdition>, List<PrintingEditionModel>>(printingEditions);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            printingEditionResponseModel.printingEditionModel = printingEditionModels;
            return printingEditionResponseModel;
        }

        public async Task<PrintingEditionResponseModel> Create(CreatePrintingEditionModel createPrintingEditionModel)
        {
            PrintingEdition printingEdition = _mapper.Map<CreatePrintingEditionModel, PrintingEdition>(createPrintingEditionModel);
            printingEdition.CreateDateTime = DateTime.Now;
            printingEdition.UpdateDateTime = DateTime.Now;

            await _printingEditionRepository.Create(printingEdition);

            PrintingEditionModel printingEditionModel = _mapper.Map<PrintingEdition, PrintingEditionModel>(printingEdition);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            printingEditionResponseModel.printingEditionModel.Add(printingEditionModel);

            return printingEditionResponseModel;
        }

        public async Task<PrintingEditionResponseModel> Update (Guid Id, CreatePrintingEditionModel createPrintingEditionModel)
        {
            PrintingEdition printingEdition = await _printingEditionRepository.GetById(Id);
            _mapper.Map(createPrintingEditionModel, printingEdition);
            printingEdition.UpdateDateTime = DateTime.Now;

            await _printingEditionRepository.Update(printingEdition);

            PrintingEditionModel printingEditionModel = _mapper.Map<PrintingEdition, PrintingEditionModel>(printingEdition);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            printingEditionResponseModel.printingEditionModel.Add(printingEditionModel);

            return printingEditionResponseModel;
        }

        public async Task<PrintingEditionResponseModel> IsDeleted (Guid Id)
        {
            PrintingEdition printingEdition = await _printingEditionRepository.GetById(Id);

            printingEdition.IsDeleted = true;
            printingEdition.UpdateDateTime = DateTime.Now;

            await _printingEditionRepository.Update(printingEdition);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            return printingEditionResponseModel;
        }

        public async Task<PrintingEditionResponseModel> Restore (Guid Id)
        {
            PrintingEdition printingEdition = await _printingEditionRepository.GetById(Id);

            printingEdition.IsDeleted = false;
            printingEdition.UpdateDateTime = DateTime.Now;

            await _printingEditionRepository.Update(printingEdition);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            return printingEditionResponseModel;
        } 

        public async Task<PrintingEditionResponseModel> Remove (Guid Id)
        {
            PrintingEdition printingEdition = await _printingEditionRepository.GetById(Id);

            await _printingEditionRepository.Delete(printingEdition);

            PrintingEditionResponseModel printingEditionResponseModel = new PrintingEditionResponseModel();
            return printingEditionResponseModel;
        }
    }
}