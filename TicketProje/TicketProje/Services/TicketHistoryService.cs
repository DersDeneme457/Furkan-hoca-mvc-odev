using TicketProje.Context;
using TicketProje.Dto.Responses;
using TicketProje.Models.Entities;

namespace TicketProje.Services
{
    public class TicketHistoryService
    {
        MyContext _context;
        public List<TicketHistoryRS> GettAll()
        {
            List<TicketHistoryRS> ticketHistoryRs = new List<TicketHistoryRS>();
            
            _context = new MyContext();
            List<TicketHistoyEntity> ticketHistoyEntities = new List<TicketHistoyEntity>();
            ticketHistoyEntities = _context.tickethistory.ToList();
            foreach (var t  in ticketHistoyEntities)
            {
                TicketHistoryRS trs = new TicketHistoryRS();
                trs.Id = t.Id;
                trs.UserId = t.UserId;
                trs.TicketId = t.TicketId;
                ticketHistoryRs.Add(trs);
            }
            return ticketHistoryRs;
        }
        public List<TicketHistoryRS> GettByUserId(int userid)
        {
            List<TicketHistoryRS> ticketHistoryRs = new List<TicketHistoryRS>();

            _context = new MyContext();
            List<TicketHistoyEntity> ticketHistoyEntities = new List<TicketHistoyEntity>();
            ticketHistoyEntities = _context.tickethistory.Where(a => a.UserId==userid).ToList();
            foreach (var t in ticketHistoyEntities)
            {
                TicketHistoryRS trs = new TicketHistoryRS();
                trs.Id = t.Id;
                trs.UserId = t.UserId;
                trs.TicketId = t.TicketId;
                ticketHistoryRs.Add(trs);
            }
            return ticketHistoryRs;

        }
        public void Entry(int ticketid, int Userid)
        {
            TicketHistoyEntity tc = new TicketHistoyEntity();
            tc.TicketId = ticketid;
            tc.UserId = Userid;
            _context = new MyContext();
            _context.tickethistory.Add(tc);
            _context.SaveChanges();
        }
    }
}
