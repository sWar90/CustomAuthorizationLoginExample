using CustomAuthorizationLoginExample.Domain.Features.Login;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuthorizationLoginExample.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
