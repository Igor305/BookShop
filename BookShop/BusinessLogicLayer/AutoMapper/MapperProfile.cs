using AutoMapper;
using BusinessLogicLayer.Models.Author;
using BusinessLogicLayer.Models.Response.Author;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorModel>();
        }

    }
}
