using System;
using System.Collections.Generic;

namespace MoneyLake.Api.DataAccess.DTO
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredDateTime { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        
        public Role Role { get; set; }
        public int RoleId { get; set; }
        
        public ICollection<Operation> Operations { get; set; }
    }
}
