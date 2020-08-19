using DataAccessLayer.Entities.Enum;

namespace BusinessLogicLayer.Models.PrintingEdition
{
    public class CreatePrintingEditionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public Status Status { get; set; }
        public Currency Currency { get; set; }
    }
}
