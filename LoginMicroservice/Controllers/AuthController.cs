using DotNetOpenAuth.AspNet.Clients;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LoginMicroservice.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost("LoginWithFacebook")]
        public async Task<IActionResult> LoginWithFacebook()
        {
           
            //var loginUrl = fb.get
            return Redirect("https://www.facebook.com/v17.0/dialog/oauth?client_id=1079338452912062&client_secret=5a7c8fc35b300adbd53559b4fe6c7297&redirect_uri=https://localhost:7042/LoginWithFacebook");
        }
    }
}
