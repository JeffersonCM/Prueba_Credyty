namespace Credyty.Domain.Entities
{
    public class Tab_CreditRequest
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string University { get; set; }
        public string Career { get; set; }
        public decimal Amount { get; set; }
        public int StateID { get; set; }
    }
}
