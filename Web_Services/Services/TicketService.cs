﻿using MongoDB.Driver;
using Web_Services.Models;

namespace Web_Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMongoCollection<Ticket> _tickets;

        public TicketService(ITicketStoreDatabaseSettings settings, IMongoClient mongoClient)
        {

            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _tickets = database.GetCollection<Ticket>(settings.TicketCollectionName);
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            _tickets.InsertOne(ticket);
            return ticket;
        }

        public void DeleteTicket(string id)
        {
            _tickets.DeleteOne(ticket => ticket.Id == id);
        }

        public Ticket GetTicketById(string id)
        {
            return _tickets.Find(ticket => ticket.Id == id).FirstOrDefault();
        }

        public List<Ticket> GetTickets(int page)
        {
            var skip = (page - 1) * 8;
            return _tickets.Find(_ => true).Skip(skip).Limit(8).ToList();
        }

        public List<Ticket> GetTicketsByStatus(int value)
        {
            return _tickets.Find(ticket => ticket.Status.Equals(value)).ToList();
        }

        public void UpdateTicket(string id, Ticket ticket)
        {
            _tickets.ReplaceOne(ticket => ticket.Id == id, ticket);
        }
    }
}
