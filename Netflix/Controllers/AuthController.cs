using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public Boolean isValid { get; set; }

        public Boolean getAuth()
        {
            isValid = isValid == null ? false : true;
            return isValid;
        }

        public void Logout()
        {
            isValid = false;
        }

        public void LoginSuccess()
        {
            isValid = true;
        }
    }
}
