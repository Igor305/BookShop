using System.Threading.Tasks;
using BusinessLogicLayer.Models.Author;
using BusinessLogicLayer.Models.Response.Author;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public async Task<AuthorResponseModel> GetAll()
        {
            AuthorResponseModel authorResponseModel = await _authorService.GetAll();
            return authorResponseModel;
        }

        [HttpPost("Create")]
        public async Task<AuthorResponseModel> Create ([FromBody]CreateAuthorModel createAuthorModel)
        {
            AuthorResponseModel authorResponseModel = await _authorService.Create(createAuthorModel);
            return authorResponseModel;
        }
    }
}
