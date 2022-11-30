namespace FleetsApi.Models
{
    public class Fleet
    {
        public Guid Id { get; set; }
        public DateTime? DateRegistered { get; set; }

        public string? Brand { get; set; }

        public string? Color { get; set; }

        public Driver? Driver { get; set; }
        public string? Coordinates { get; set; }

        public string? Status { get; set; }
    }
}
