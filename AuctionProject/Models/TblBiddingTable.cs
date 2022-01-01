using System;
using System.Collections.Generic;

#nullable disable

namespace AuctionProject.Models
{
    public partial class TblBiddingTable
    {
        public int BiddingId { get; set; }
        public int? InventoryId { get; set; }
        public string Bidval { get; set; }
        public int? OwnerId { get; set; }
        public DateTime? Dateofbid { get; set; }
        public bool? BidCloseStatus { get; set; }
        public int? BidderId { get; set; }

        public virtual TblUserDataLogin Bidder { get; set; }
        public virtual TblInventory Inventory { get; set; }
    }
}
