using System;
using System.Collections.Generic;
using System.Text;

namespace Credyty.Aplication.DTO
{
    public class ModifyPersonDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public int GenderID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
