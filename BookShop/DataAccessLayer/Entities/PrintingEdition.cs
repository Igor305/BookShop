using DataAccessLayer.Entities.Base;
using DataAccessLayer.Entities.Enum;

namespace DataAccessLayer.Entities
{
    public class PrintingEdition : Generic
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public Status Status { get; set; }
        public Currency Currency { get; set; }
        public OrderItem OtderItem { get; set; }

    }
}
