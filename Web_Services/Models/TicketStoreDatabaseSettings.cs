namespace Web_Services.Models
{
    public class TicketStoreDatabaseSettings : ITicketStoreDatabaseSettings
    {
        public string TicketCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
