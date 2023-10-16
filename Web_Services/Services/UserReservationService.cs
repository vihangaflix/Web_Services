using MongoDB.Driver;
using Web_Services.Models;

namespace Web_Services.Services
{
    public class UserReservationService : IUserReservationService
    {
        private readonly IMongoCollection<UserReservation> _userReservations;

        public UserReservationService(IUserReservationDatabaseSettings settings, IMongoClient mongoClient)
        {

            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userReservations = database.GetCollection<UserReservation>(settings.UserReservationCollectionName);
        }
        public UserReservation CreateUserReservation(UserReservation userReservation)
        {
            _userReservations.InsertOne(userReservation);
            return userReservation;
        }

        public void DeleteUserReservation(string id)
        {
            _userReservations.DeleteOne(userReservation => userReservation.Id == id);
        }

        public UserReservation GetUserReservationById(string id)
        {
            return _userReservations.Find(userReservation => userReservation.Id == id).FirstOrDefault();
        }

        public List<UserReservation> GetUserReservations(int page)
        {
            var skip = (page - 1) * 8;
            return _userReservations.Find(_ => true).Skip(skip).Limit(8).ToList();
        }

        public void UpdateUserReservation(string id, UserReservation userReservation)
        {
            _userReservations.ReplaceOne(userReservation => userReservation.Id == id, userReservation);
        }
    }
}
