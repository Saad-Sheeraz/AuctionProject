using System;
using System.Collections.Generic;

#nullable disable

namespace AuctionProject.Models
{
    public partial class TblInventory
    {
        public TblInventory()
        {
            TblBiddingTables = new HashSet<TblBiddingTable>();
        }

        public int InventoryId { get; set; }
        public string InvName { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
        public int? UserId { get; set; }

        public virtual TblUserDataLogin User { get; set; }
        public virtual ICollection<TblBiddingTable> TblBiddingTables { get; set; }
    }
}
