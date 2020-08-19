using BusinessLogicLayer.Models.Response.Base;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response.PrintingEdition
{
    public class PrintingEditionResponseModel : GenericResponseModel
    {
        public List<PrintingEditionModel> printingEditionModel { get; set; }

        public PrintingEditionResponseModel()
        {
            printingEditionModel = new List<PrintingEditionModel>();
        }
    }
}
