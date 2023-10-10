namespace Web_Services.Models
{
    public interface ITicketStoreDatabaseSettings
    {
        string TicketCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
