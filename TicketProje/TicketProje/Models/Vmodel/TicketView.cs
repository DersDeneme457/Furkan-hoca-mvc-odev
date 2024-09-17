using TicketProje.Dto.Responses;

namespace TicketProje.Models.Vmodel
{
    public class TicketView
    {
        public List<TicketRS> ticketRs { get; set; }
        public List<CategoryRs> categoryRs {  get; set; }
    }
}
