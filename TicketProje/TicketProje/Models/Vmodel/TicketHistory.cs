using TicketProje.Dto.Responses;

namespace TicketProje.Models.Vmodel
{
    public class TicketHistory
    {
        public List<TicketHistoryRS> history { get; set; }
        public List<TicketRS> ticketrs { get; set; }
        public int ID {  get; set; }
    }
}
