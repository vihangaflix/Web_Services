using Web_Services.Models;

namespace Web_Services.Services
{
    public interface IUserReservationService
    {
        UserReservation CreateUserReservation(UserReservation userReservation);
        List<UserReservation> GetUserReservations(int page);
        UserReservation GetUserReservationById(string id);
        void UpdateUserReservation(string id, UserReservation userReservation);
        void DeleteUserReservation(string id);
    }
}
