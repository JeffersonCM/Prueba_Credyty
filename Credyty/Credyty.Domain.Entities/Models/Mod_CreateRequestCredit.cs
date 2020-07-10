using System;
using System.Collections.Generic;
using System.Text;

namespace Credyty.Domain.Entities.Models
{
    public class Mod_CreateRequestCredit
    {
        public int PersonID { get; set; }
        public string University { get; set; }
        public string Career { get; set; }
        public decimal Amount { get; set; }
        public int StateID { get; set; }
    }
}
