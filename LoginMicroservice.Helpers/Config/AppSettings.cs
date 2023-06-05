using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMicroservice.Helpers.Config
{
    public class AppSettings
    {
    }
    public class FacebookConfig
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string RedirectUri { get; set; }
    }
}
