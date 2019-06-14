using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rezerwacja_pokoi.Models
{
    public class PermRoles
    {   public int PermRolesID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }


        public Role Role { get; set; } 
        public User User { get; set; }


    }
}
