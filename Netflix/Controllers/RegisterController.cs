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
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult ActRegister(UserModel model)
        {
            try
            {
                RegisterRepository rep = new RegisterRepository(Helpers.getConnStr());
                Boolean res = rep.ActRegister(model);

                if (res == true)
                {
                    return Ok(new JsonResponseModel { success = true, data = "" });
                }
                else
                {
                    return Ok(new JsonResponseModel { success = false, data = "Bu E-Posta Adresi Daha önce Tanımlanmış..!" });                   
                }
            }
            catch (Exception ex)
            {
                return Ok(new JsonResponseModel { success = false, data = ex.Message });
            }     
        }







    }
}

