namespace Web_Services.Models
{
    public class UserReservationDatabaseSettings : IUserReservationDatabaseSettings
    {
        public string UserReservationCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
