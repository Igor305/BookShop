using AutoMapper;
using BusinessLogicLayer.Models.Author;
using BusinessLogicLayer.Models.PrintingEdition;
using BusinessLogicLayer.Models.Response.Author;
using BusinessLogicLayer.Models.Response.PrintingEdition;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorModel>();
            CreateMap<PrintingEdition, PrintingEditionModel>();
            CreateMap<CreatePrintingEditionModel, PrintingEdition>();
            CreateMap<PrintingEdition, PrintingEditionModel>();
        }
    }
}
