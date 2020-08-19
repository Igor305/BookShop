using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response.Base
{
    public class GenericResponseModel
    {
        public string Messege { get; set; }
        public bool Status { get; set; }
        public List<string> Errors { get; set; }
        public GenericResponseModel()
        {
            Errors = new List<string>();
        }
    }
}
