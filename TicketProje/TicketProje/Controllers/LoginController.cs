using Microsoft.AspNetCore.Mvc;
using TicketProje.Auth;
using TicketProje.Dto.Requests;
using TicketProje.Dto.Responses;
using TicketProje.Services;

namespace TicketProje.Controllers
{
    public class LoginController : Controller
    {


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginControl(LoginRQ loginRQ)
        {
            UserService userService = new UserService();
            var s = userService.GetUser(loginRQ.Mail, loginRQ.Password);
            if (s != null)
            {
                Console.WriteLine(s.Role);
                if (s.Role == "Admin")
                {
                    AuthC.Auths = "Admin";
                    return RedirectToAction("Main", "AdminPanel");

                }
                else
                {
                    AuthC.Auths = "User";
                    return RedirectToAction("Main", "UserPanel", new { id = s.Id });
                }
            }
            else
            {
                return RedirectToAction("Login", "Login" );
            }

        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterControl(LoginRQ loginRQ)
        {
            RegisterService registerServices = new RegisterService();
            var t = registerServices.Register(loginRQ.Mail, loginRQ.Password);
            if (t = true)
            {
                return RedirectToAction("Main", "UserPanel");
            }
            else
            {
                return View("Register");
            }
           
        }
    }
}
