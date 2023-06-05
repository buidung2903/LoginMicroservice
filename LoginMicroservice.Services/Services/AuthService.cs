using Facebook;
using LoginMicroservice.Helpers.Config;
using LoginMicroservice.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace LoginMicroservice.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly FacebookConfig _facebookConfig;

        public AuthService(IOptions<FacebookConfig> facebookConfig)
        {
            _facebookConfig = facebookConfig.Value;
        }

        public bool FacebookRedirect(string code)
        {
            try
            {
                var fb = new FacebookClient();
                dynamic result = fb.Get("/oauth/access_token", new
                {
                    client_id = _facebookConfig.AppId,
                    client_secret = _facebookConfig.AppSecret,
                    redirect_uri = _facebookConfig.RedirectUri,
                    code,
                });
                fb.AccessToken = result.access_token;
                dynamic me = fb.Get("/me?fields=id,name");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
