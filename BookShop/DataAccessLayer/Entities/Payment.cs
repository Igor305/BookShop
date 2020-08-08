using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public class Payment : Generic
    {
        public string TransactionId { get; set; }
        public Order Order { get; set; }
    }
}
