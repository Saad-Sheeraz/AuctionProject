using System;
using System.Collections.Generic;

#nullable disable

namespace AuctionProject.Models
{
    public partial class TblUserDataLogin
    {
        public TblUserDataLogin()
        {
            TblBiddingTables = new HashSet<TblBiddingTable>();
            TblInventories = new HashSet<TblInventory>();
        }

        public int UserId { get; set; }
        public byte[] UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public DateTime? DateofRegister { get; set; }

        public virtual TblUsersRole Role { get; set; }
        public virtual ICollection<TblBiddingTable> TblBiddingTables { get; set; }
        public virtual ICollection<TblInventory> TblInventories { get; set; }
    }
}
