using TicketProje.Context;
using TicketProje.Dto.Responses;

namespace TicketProje.Services
{
    public class UserService
    {

        MyContext _context;
        public UserService()
        {
            _context = new MyContext();

        }
        public List<UserRs> GetAll()
        {
            var userlist = _context.users.ToList();
            List<UserRs> ulist = new List<UserRs>();
            foreach (var u in userlist)
            {
                UserRs user = new UserRs();
                user.UserName = u.UserName;
                user.Password = u.Password;
                user.Id = u.Id;
                user.Role = u.Role;
                user.Gmail = u.Gmail;
                ulist.Add(user);
            }
            return ulist;

        }
        public UserRs? GetUser(string mail, string password)
        {
            UserRs? user = new UserRs();
            var userc = _context.users.FirstOrDefault(c => c.Gmail == mail);
            if (userc == null)
            {
                return null;
            }
            else
            {
                if (userc.Password == password)
                {
                    user.UserName = userc.UserName;
                    user.Password = userc.Password;
                    user.Id = userc.Id;
                    user.Role = userc.Role;
                    user.Gmail = userc.Gmail;
                    return user;
                }
                return null;
            }
           
        }
        public UserRs GetById(int id)
        {
            UserRs user = new UserRs();
            var us = _context.users.FirstOrDefault(u => u.Id == id);
            user.Id = id;
            user.UserName = us.UserName;
            user.Password = "123";
            user.Gmail = us.Gmail;
            user.Role = us.Role;
            return user;

        }
    }
}
