using AutoMapper;
using BusinessLogicLayer.Models.Author;
using BusinessLogicLayer.Models.Response.Author;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<AuthorResponseModel> GetAllWithoutIsDeleted()
        {
            List<Author> authors = await _authorRepository.GetAllWithoutIsDeleted();

            List<AuthorModel> authorModels = _mapper.Map<List<Author>, List<AuthorModel>>(authors);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            authorResponseModel.AuthorModel = authorModels;

            return authorResponseModel;
        }

        public async Task <AuthorResponseModel> GetById(Guid Id)
        {
            Author author = await _authorRepository.GetById(Id);

            AuthorModel authorModel = _mapper.Map<Author, AuthorModel>(author);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            authorResponseModel.AuthorModel.Add(authorModel);

            return authorResponseModel;
        }

        public async Task<AuthorResponseModel> FindName(string FirstName, string LastName)
        {
            Author author = await _authorRepository.GetByName(FirstName, LastName);

            AuthorModel authorModel = _mapper.Map<Author, AuthorModel>(author);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            authorResponseModel.AuthorModel.Add(authorModel);

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

        public async Task<AuthorResponseModel> Update(Guid Id, CreateAuthorModel createAuthorModel)
        {
            Author author = await _authorRepository.GetById(Id);
            _mapper.Map(createAuthorModel, author);
            author.UpdateDateTime = DateTime.Now;

            await _authorRepository.Update(author);

            AuthorModel authorModel = _mapper.Map<Author, AuthorModel>(author);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            authorResponseModel.AuthorModel.Add(authorModel);

            return authorResponseModel;
        }

        public async Task<AuthorResponseModel> IsDeleted(Guid Id)
        {
            Author author = await _authorRepository.GetById(Id);

            author.IsDeleted = true;
            author.UpdateDateTime = DateTime.Now;

            await _authorRepository.Update(author);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            return authorResponseModel;
        }

        public async Task<AuthorResponseModel> Restore(Guid Id)
        {
            Author author = await _authorRepository.GetById(Id);

            author.UpdateDateTime = DateTime.Now;
            author.IsDeleted = false;

            await _authorRepository.Update(author);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            return authorResponseModel;
        }

        public async Task<AuthorResponseModel> Remove(Guid Id)
        {
            Author author = await _authorRepository.GetById(Id);

            await _authorRepository.Delete(author);

            AuthorResponseModel authorResponseModel = new AuthorResponseModel();
            return authorResponseModel;
        }
    }
}