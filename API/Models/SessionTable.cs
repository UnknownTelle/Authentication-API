using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class SessionTable
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public DateTime SessionTime { get; set; }

        public virtual User User { get; set; }
    }
}
