using DataAccessLayer.Entities.Base;
using System;

namespace DataAccessLayer.Entities
{
    public class Payment : Generic
    {
        public Guid TransactionId { get; set; }
        public Order Order { get; set; }
    }
}
