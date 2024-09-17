using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketProje.Models;
using TicketProje.Models.Vmodel;
using TicketProje.Services;

namespace TicketProje.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult ViewTicket(int? id)
        {
            TicketService ticketService = new TicketService();
            CategoryService categoryService = new CategoryService();
            TicketView ticketView = new TicketView();
            ticketView.categoryRs = categoryService.GettAll();
            if (id == null)
            {
                ticketView.ticketRs=ticketService.GettAll();               
            }
            else
            {
                ticketView.ticketRs=ticketService.GettAllById(id);            
            }
            return View(ticketView);
        }
        
    }
}
