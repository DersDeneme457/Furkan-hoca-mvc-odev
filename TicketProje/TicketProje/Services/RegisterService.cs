using TicketProje.Context;
using TicketProje.Controllers;
using TicketProje.Dto.Requests;
using TicketProje.Models.Entities;

namespace TicketProje.Services
{
    public class RegisterService
    {
        MyContext _context;
        public RegisterService()
        {
            _context = new MyContext();
        }
        public bool Register(string mail, string password)
        {
            var userlist = _context.users.FirstOrDefault(c => mail == c.Gmail);
            if (userlist == null)
            {
                UserEntity user = new UserEntity();
                user.Gmail = mail;
                user.Password = password;
                user.Role = "User";
                _context.users.Add(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
