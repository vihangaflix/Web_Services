using MongoDB.Driver;
using Web_Services.Models;

namespace Web_Services.Services
{
    public class TrainService : ITrainService
    {
        private readonly IMongoCollection<Train> _trains;

        public TrainService(ITrainStoreDatabaseSettings settings, IMongoClient mongoClient)
        {

            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _trains = database.GetCollection<Train>(settings.DatabaseName);
        }

        public Train CreateTrain(Train train)
        {
            _trains.InsertOne(train);
            return train;
        }

        public void DeleteTrain(string id)
        {
            _trains.DeleteOne(train => train.Id == id);
        }

        public Train GetTrainById(string id)
        {
            return _trains.Find(train => train.Id == id).FirstOrDefault();
        }

        public List<Train> GetTrains()
        {
            return _trains.Find(train => true).ToList();
        }

        public void UpdateTrain(string id, Train train)
        {
            _trains.ReplaceOne(train => train.Id == id, train);
        }
    }
}