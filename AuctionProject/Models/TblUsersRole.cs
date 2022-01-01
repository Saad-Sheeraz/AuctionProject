using System;
using System.Collections.Generic;

#nullable disable

namespace AuctionProject.Models
{
    public partial class TblUsersRole
    {
        public TblUsersRole()
        {
            TblUserDataLogins = new HashSet<TblUserDataLogin>();
        }

        public int RoleId { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<TblUserDataLogin> TblUserDataLogins { get; set; }
    }
}
