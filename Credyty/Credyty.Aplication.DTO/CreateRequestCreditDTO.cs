using System;
using System.Collections.Generic;
using System.Text;

namespace Credyty.Aplication.DTO
{
    public class CreateRequestCreditDTO
    {
        public int PersonID { get; set; }
        public string University { get; set; }
        public string Career { get; set; }
        public decimal Amount { get; set; }
        public int StateID { get; set; }
    }
}
