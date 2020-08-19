using BusinessLogicLayer.Models.Author;
using BusinessLogicLayer.Models.Response.Author;
using System;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<AuthorResponseModel> GetAll();
        public Task<AuthorResponseModel> GetAllWithoutIsDeleted();
        public Task<AuthorResponseModel> GetById(Guid Id);
        public Task<AuthorResponseModel> FindName(string FirstName, string LastName);
        public Task<AuthorResponseModel> Create(CreateAuthorModel createAuthorModel);
        public Task<AuthorResponseModel> Update(Guid Id, CreateAuthorModel createAuthorModel);
        public Task<AuthorResponseModel> IsDeleted(Guid Id);
        public Task<AuthorResponseModel> Restore(Guid Id);
        public Task<AuthorResponseModel> Remove(Guid Id);
    }
}
