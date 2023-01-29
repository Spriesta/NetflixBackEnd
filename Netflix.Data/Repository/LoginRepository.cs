using Netflix.Common;
using Netflix.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Shared.Common;
//using Microsoft.Extensions.Configuration;

namespace Netflix.Repository
{
    public class LoginRepository : GenericRepository<UserModel>
    {
        public LoginRepository(string connection) : base(connection)
        { }

        public Boolean ActLogin(UserModel model)
        {
            string crpytPass = CryptHash.ToSHA256(model.password);

            UserModel isAnyEntity = base.GetAll().Where(x => x.email == model.email).FirstOrDefault();
            if (isAnyEntity != null)
            {
                if (isAnyEntity.password == crpytPass)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
