using System;
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

        [HttpGet]
        public async Task<AuthorResponseModel> GetAlWithoutIsDeleted()
        {
            AuthorResponseModel authorResponseModel = await _authorService.GetAllWithoutIsDeleted();
            return authorResponseModel;
        }

        [HttpGet("{Id}")]
        public async Task<AuthorResponseModel> GetById(Guid Id)
        {
            AuthorResponseModel authorResponseModel = await _authorService.GetById(Id);
            return authorResponseModel;
        }

        [HttpGet("{FirstName},{LastName}")]
        public async Task<AuthorResponseModel> GetFindName(string FirstName, string LastName)
        {
            AuthorResponseModel authorResponseModel = await _authorService.FindName(FirstName, LastName);
            return authorResponseModel;
        }

        [HttpPost]
        public async Task<AuthorResponseModel> Create([FromBody] CreateAuthorModel createAuthorModel)
        {
            AuthorResponseModel authorResponseModel = await _authorService.Create(createAuthorModel);
            return authorResponseModel;
        }

        [HttpPut("{Id}")]
        public async Task<AuthorResponseModel> Update(Guid Id, [FromBody] CreateAuthorModel createAuthorModel)
        {
            AuthorResponseModel authorResponseModel = await _authorService.Update(Id, createAuthorModel);
            return authorResponseModel;
        }

        [HttpPut("IsDeleted/{Id}")]
        public async Task<AuthorResponseModel> IsDeleted(Guid Id)
        {
            AuthorResponseModel authorResponseModel = await _authorService.IsDeleted(Id);
            return authorResponseModel;
        }

        [HttpPut("Restore/{Id}")]
        public async Task<AuthorResponseModel> Restore(Guid Id)
        {
            AuthorResponseModel authorResponseModel = await _authorService.Restore(Id);
            return authorResponseModel;
        }

        [HttpDelete("{Id}")]
        public async Task<AuthorResponseModel> Remove(Guid Id)
        {
            AuthorResponseModel authorResponseModel = await _authorService.Remove(Id);
            return authorResponseModel;
        }
    }
}
