namespace TicketProje.Dto.Requests
{
    public class TikcetRQ
    {
        public string? Name { get; set; }
        public int CategoryID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime DateTime { get; set; }
        public string? EventType { get; set; }
    }
}
