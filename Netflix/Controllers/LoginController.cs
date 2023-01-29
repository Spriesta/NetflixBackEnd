using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Common;
using Netflix.Models;
using Netflix.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult ActLogin(UserModel model)
        {
            try
            {
                LoginRepository rep = new LoginRepository(Helpers.getConnStr());
                Boolean res = rep.ActLogin(model);
                AuthController auth = new AuthController();

                if (res == true)
                {
                    auth.LoginSuccess();

                    return Ok(new JsonResponseModel { success = true, data = "" });
                }
                else
                {
                    auth.Logout();
                    return Ok(new JsonResponseModel { success = false, data = "E-mail veya Şifre Yanlış..!" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new JsonResponseModel { success = false, data = ex.Message });
            }
        }
    }
}

