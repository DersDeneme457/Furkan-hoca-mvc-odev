using TicketProje.Context;
using TicketProje.Dto.Responses;

namespace TicketProje.Services
{
    public class TicketService
    {
        MyContext _context;
        public TicketService()
        {
            _context = new MyContext();
        }
        public List<TicketRS> GettAll()
        {
            List<TicketRS> list = new List<TicketRS>();

            foreach (var t in _context.ticketss)
            {
                TicketRS ticketRS = new TicketRS();
                ticketRS.Id = t.Id;
                ticketRS.Name = t.Name;
                ticketRS.Price = t.Price;
                ticketRS.Quantity = t.Quantity;
                ticketRS.CategoryID = t.CategoryID;
                ticketRS.DateTime = t.DateTime;
                ticketRS.EventType = t.EventType;
                list.Add(ticketRS);
            }
            return list;
        }
        public List<TicketRS> GettAllById(int? id)
        {
            List<TicketRS> list = new List<TicketRS>();
            var tickets = _context.ticketss.Where(t => t.CategoryID == id).ToList();
            foreach (var t in tickets)
            {
                TicketRS ticketRS = new TicketRS();
                ticketRS.Id = t.Id;
                ticketRS.Name = t.Name;
                ticketRS.Price = t.Price;
                ticketRS.Quantity = t.Quantity;
                ticketRS.CategoryID = t.CategoryID;
                ticketRS.DateTime = t.DateTime;
                ticketRS.EventType = t.EventType;
                list.Add(ticketRS);
            }
            return list;

        }
        public TicketRS GetById(int id)
        {
            TicketRS ts = new TicketRS();
            var ticket = _context.ticketss.Where(t => t.Id == id).FirstOrDefault();
            ts.Id = ticket.Id;
            ts.Name = ticket.Name;
            ts.Price = ticket.Price;
            ts.Quantity = ticket.Quantity;
            ts.DateTime = ticket.DateTime;
            ts.EventType = ticket.EventType;
            ts.CategoryID = ticket.CategoryID;

            return ts;
        }
        public void DecreaseQuantity(int id)
        {
            var ticket = _context.ticketss.Where(t => t.Id == id).SingleOrDefault();
            ticket.Quantity--;
            _context.SaveChanges();
        }
        public List<TicketRS> Necessary()
        {
            List<TicketRS> list = new List<TicketRS>();
            TicketRS ticket = new TicketRS();
            DateTime currentDate = DateTime.Now;
            var futureTickets = _context.ticketss
       .Where(t => t.DateTime > currentDate)
       .ToList();
            foreach( var t in futureTickets )
            {
                if (ticket.Quantity > 0 )
                {
                    ticket.Price=t.Price;
                    ticket.Quantity = t.Quantity;
                    ticket.CategoryID = t.CategoryID;
                    ticket.EventType = t.EventType;
                    ticket.DateTime = t.DateTime;
                    ticket.Name = t.Name;
                    ticket.Id = t.Id;
                    list.Add(ticket);
                }
            }
            return list;
        }

    }
}
