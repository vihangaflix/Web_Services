namespace Web_Services.Models
{
    public class TrainStoreDatabaseSettings : ITrainStoreDatabaseSettings
    {
        public string TrainCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    
    }
}
