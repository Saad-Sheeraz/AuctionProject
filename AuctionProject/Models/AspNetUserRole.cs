using System;
using System.Collections.Generic;

#nullable disable

namespace AuctionProject.Models
{
    public partial class AspNetUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRole Role { get; set; }
    }
}
