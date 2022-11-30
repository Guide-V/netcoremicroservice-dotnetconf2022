namespace FleetsApi.Models
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? Employed { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;
    }
}
