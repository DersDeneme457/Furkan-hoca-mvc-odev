using System.ComponentModel.DataAnnotations;

namespace TicketProje.Dto.Responses
{
    public class CategoryRs
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
