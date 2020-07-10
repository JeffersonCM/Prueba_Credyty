namespace Credyty.Domain.Entities.Models
{
    public class Result<T>
    {
        public bool Successful { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public dynamic Response { get; set; }
    }
}
