using System.ComponentModel.DataAnnotations;

namespace TicketProje.Models.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
