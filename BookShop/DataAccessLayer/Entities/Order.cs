using DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Order : Generic
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
