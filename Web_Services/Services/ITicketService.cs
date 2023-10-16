using Web_Services.Models;

namespace Web_Services.Services
{
    public interface ITicketService
    {
        Ticket CreateTicket(Ticket ticket);
        List<Ticket> GetTickets(int page);
        List<Ticket> GetTicketsByStatus(int value);
        Ticket GetTicketById(string id);
        void UpdateTicket(string id, Ticket ticket);
        void DeleteTicket(string id);
    }
}
