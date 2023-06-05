using Facebook;
using LoginMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LoginMicroservice.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("FacebookRedirect")]
        public IActionResult FacebookRedirect(string code)
        {
            if (_authService.FacebookRedirect(code))
            {
                return Ok("Login Success");
            }
            return Ok("Login Fail");
        }
    }
}
