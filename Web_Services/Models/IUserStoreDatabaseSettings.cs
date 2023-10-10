namespace Web_Services.Models
{
    public interface IUserStoreDatabaseSettings
    {
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
