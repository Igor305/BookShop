using DataAccessLayer.Entities.Base;
using DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class OrderItem : Generic
    {
        public int Amount { get; set; }
        public Currency Currency { get; set; }
        public decimal Count { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid PrintingEditionId { get; set; }
        public List<PrintingEdition> PrintingEditions { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
     }
}
