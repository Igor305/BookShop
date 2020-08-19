using AutoMapper;
using BusinessLogicLayer.Models.Author;
using BusinessLogicLayer.Models.Response.Author;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService( IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorResponseModel> GetAll()
        {
            List<Author> authors = await _authorRepository.GetAll();

            List<AuthorModel> authorModel = _mapper.Map<List<Author>, List<AuthorModel>>(authors);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            authorResponseModel.AuthorModel = authorModel;

            return authorResponseModel;
        }
        public async Task<AuthorResponseModel> Create(CreateAuthorModel createAuthorModel)
        {
            Author author = _mapper.Map<CreateAuthorModel, Author>(createAuthorModel);
            author.CreateDateTime = DateTime.Now;
            author.UpdateDateTime = DateTime.Now;

            await _authorRepository.Create(author);

            AuthorModel authorModel = _mapper.Map<Author, AuthorModel>(author);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            authorResponseModel.AuthorModel.Add(authorModel);

            return authorResponseModel;
        }
    }
}
