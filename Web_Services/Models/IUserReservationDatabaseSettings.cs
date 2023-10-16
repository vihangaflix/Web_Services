namespace Web_Services.Models
{
    public interface IUserReservationDatabaseSettings
    {
        string UserReservationCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
