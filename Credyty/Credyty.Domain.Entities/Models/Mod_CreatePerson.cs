namespace Credyty.Domain.Entities.Models
{
    public class Mod_CreatePerson
    {
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
