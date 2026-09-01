using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmester.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = "Player";
        public bool isActive { get; set; }
        public bool isAdmin
        {
            get
            {
                return Role == "Admin";
            }
        }
    }
}
