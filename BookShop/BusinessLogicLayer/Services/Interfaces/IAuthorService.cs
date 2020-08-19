using BusinessLogicLayer.Models.Author;
using BusinessLogicLayer.Models.Response.Author;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<AuthorResponseModel> GetAll();
        public Task<AuthorResponseModel> Create(CreateAuthorModel createAuthorModel);
    }
}
