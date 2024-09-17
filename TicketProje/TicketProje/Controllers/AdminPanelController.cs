using Microsoft.AspNetCore.Mvc;
using TicketProje.Auth;
using TicketProje.Dto.Requests;
using TicketProje.Dto.Responses;
using TicketProje.Models.Vmodel;
using TicketProje.Services;

namespace TicketProje.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Main()
        {
            if (AuthC.Auths != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public  IActionResult AddTicket()
        {
            if (AuthC.Auths != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            CategoryView cw = new CategoryView();
            CategoryService categoryService = new CategoryService();
            cw.categories = categoryService.GettAll();
            return View(cw);
        }
        public IActionResult AddTickets(TikcetRQ rQ)
        {
           
            Console.WriteLine(rQ.CategoryID);
            if (AuthC.Auths != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Main");
        }
        public IActionResult UserList()
        {
           UserView uw = new UserView();
            UserService us =new UserService();
            uw.Users = us.GetAll();
            return View(uw); 
        }
    }
}
