using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TicketProje.Auth;
using TicketProje.Dto.Responses;
using TicketProje.Models.Vmodel;
using TicketProje.Services;

namespace TicketProje.Controllers
{
    public class UserPanelController : Controller
    {
        static public int ids;
        public IActionResult Main(int id)
        {
            if (AuthC.Auths != "User")
            {
                return RedirectToAction("Index", "Home");
            }
            
            ids = id;
            Console.WriteLine(ids);
            return View();
        }
        public IActionResult Tickets()
        {
            if (AuthC.Auths != "User")
            {
                return RedirectToAction("Index", "Home");
            }
            TicketView ticketView = new TicketView();
            TicketService ts = new TicketService();
            CategoryService categoryService = new CategoryService();
            ticketView.ticketRs = ts.GettAll();
            ticketView.categoryRs = categoryService.GettAll();
           
            return View(ticketView);
        }
        public IActionResult Succes(int id)
        {
            if (AuthC.Auths != "User")
            {
                return RedirectToAction("Index", "Home");
            }
            TicketService ts = new TicketService();
            ts.DecreaseQuantity(id);
            TicketHistoryService ths = new TicketHistoryService();
            ths.Entry(id, ids);
            UserIdView user = new UserIdView(); 
            user.UserId = ids;
           
            return View(user);
        }
        public IActionResult TicketHistory()
        {
            if (AuthC.Auths != "User")
            {
                return RedirectToAction("Index", "Home");
            }
            TicketHistory view = new TicketHistory();
            TicketService ts = new TicketService();
            UserService us = new UserService();
            TicketHistoryService ths = new TicketHistoryService();
            TicketHistoryRS thrs = new TicketHistoryRS();
            TicketRS tz = new TicketRS();
            List<TicketRS> lists = new List<TicketRS>();
            var s = ths.GettByUserId(ids);
            if (s != null)
            {

                view.history = s;
                foreach (var t in s)
                {

                    Console.WriteLine(t.TicketId);
                    tz=ts.GetById(t.TicketId);
                    lists.Add(tz);
                    
                }



            }
            view.ID = ids;
            view.ticketrs= lists;
            return View(view);  

        }


    }
}
