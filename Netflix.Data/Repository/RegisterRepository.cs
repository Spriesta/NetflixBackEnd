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
    public class RegisterRepository : GenericRepository<UserModel>
    {
        public RegisterRepository(string connection) : base(connection)
        { }

        public Boolean ActRegister(UserModel model)  
        {
            UserModel res = new UserModel();
                        
            res.password = CryptHash.ToSHA256(model.password); 
            res.email = model.email;

            //varlık kontrolü
            UserModel isAnyEntity = base.GetAll().Where(x => x.email == res.email).FirstOrDefault();
            if (isAnyEntity == null)
            {
                base.Add(res);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
