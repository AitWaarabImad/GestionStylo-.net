using BLL;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BLL.Dto;
using Microsoft.AspNetCore.Authorization;

namespace GestionStylo.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly StyloService _styloService;
        public UserController(UserService userService,StyloService styloService)
        {
            _userService = userService;
            _styloService = styloService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Index(User user)
        {
            StyloUser styloUser = new StyloUser();
            styloUser.stylos = _styloService.GetAll();
            styloUser.user = user;
            return View(styloUser);

        }

        [HttpGet]
        public IActionResult Signin()
        { 
            return View();
        }


        [HttpPost]
        public IActionResult Signin(User user)
        {
            User userResult = _userService.Sign(user);
            if(userResult != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, userResult.UserName),
                new Claim(ClaimTypes.Role, "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Login login)
        {
            User userResult = _userService.Login(login);
            if (userResult != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, userResult.UserName),
                new Claim(ClaimTypes.Role, "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
            }
            return RedirectToAction("Index",userResult);
        }

        public IActionResult Logout()
        {
            
            
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            return RedirectToAction("Index","Stylo");
        }
    }
}
