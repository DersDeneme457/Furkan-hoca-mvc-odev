using System.Collections.Generic;
using TicketProje.Context;
using TicketProje.Dto.Responses;

namespace TicketProje.Services
{
    public class CategoryService
    {
        MyContext _context;
        public CategoryService()
        {
            _context = new MyContext();
        }
        public List<CategoryRs> GettAll()
        {
          
            var c = _context.categories.ToList();
            List<CategoryRs> listc = new List<CategoryRs>();
            foreach ( var item in c)
            {
                 CategoryRs rs = new CategoryRs();
                rs.CategoryID = item.CategoryID;
                rs.Name = item.Name;
                listc.Add(rs);
            }
            return listc;
            
        }
    }
}
