using Web_Services.Models;

namespace Web_Services.Services
{
    public interface ITrainService
    {
        Train CreateTrain(Train train);
        List<Train> GetTrains(int page);
        Train GetTrainById(string id);
        void UpdateTrain(string id, Train train);
        void DeleteTrain(string id);
    }
}
