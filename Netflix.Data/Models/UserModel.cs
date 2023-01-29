using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public long id { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        [Computed]
        public DateTime? createDate { get; set; }
        [Computed]
        public DateTime? updateDate { get; set; }


    }
}
