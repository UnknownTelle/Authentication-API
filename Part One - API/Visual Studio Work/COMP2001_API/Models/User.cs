using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class User
    {
        public User()
        {
            Passwords = new HashSet<Password>();
            SessionTables = new HashSet<SessionTable>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string ResponceMessage { get; set; }

        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<SessionTable> SessionTables { get; set; }
    }
}
