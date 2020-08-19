using BusinessLogicLayer.Models.Response.Base;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response.Author
{
    public class AuthorResponseModel : GenericResponseModel
    {
        public List<AuthorModel> AuthorModel { get; set; }

        public AuthorResponseModel()
        {
            AuthorModel = new List<AuthorModel>();
        }
    }
}
