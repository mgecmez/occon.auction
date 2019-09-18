using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occon.Auction.Server.Api.Models
{
    public class AuctionModel
    {
        public Guid Key { get; set; }
        public DateTime EndTime { get; set; }
        public string Deadline { get; set; }
        public List<Bidder> Bidders { get; set; }
        public string HighestBidder { get; set; }
        public decimal HighestBid { get; set; }
        public string BalanceTime { get; set; }
    }

    public class Bidder
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
