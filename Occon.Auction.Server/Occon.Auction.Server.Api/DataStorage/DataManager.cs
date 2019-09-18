using Occon.Auction.Server.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occon.Auction.Server.Api.DataStorage
{
    public static class DataManager
    {
        public static AuctionModel staticList;

        public static AuctionModel GetData()
        {
            if (staticList != null && staticList.EndTime > DateTime.Now)
            {

                var nowtime = DateTime.Now.ToLongTimeString();
                var finishtime = staticList.EndTime.ToLongTimeString();

                TimeSpan duration = DateTime.Parse(finishtime).Subtract(DateTime.Parse(nowtime));

                staticList.BalanceTime = duration.ToString(@"mm\:ss");
                return staticList;
            }
            else if (staticList == null || staticList.EndTime <= DateTime.Now)
            {
                var r = new Random();
                var endtime = DateTime.Now.AddMinutes(1);
                staticList = new AuctionModel
                {
                    EndTime = endtime,
                    Deadline = endtime.ToString("dd.MM.yyyy HH:mm:ss"),
                    Bidders = new List<Bidder>
                {
                    new Bidder { Name = "User 1", Price = r.Next(1, 40) },
                    new Bidder { Name = "User 2", Price = r.Next(1, 40) },
                    new Bidder { Name = "User 3", Price = r.Next(1, 40) }
                }
                };

                var highest = staticList.Bidders.OrderByDescending(x => x.Price).FirstOrDefault();
                staticList.HighestBid = highest.Price;
                staticList.HighestBidder = highest.Name;

                return staticList;
            }

            return staticList;
        }

        public static AuctionModel SetData(string user, decimal price)
        {
            staticList.Bidders.Find(x => x.Name == user).Price = price;

            var highest = staticList.Bidders.OrderByDescending(x => x.Price).FirstOrDefault();
            staticList.HighestBid = highest.Price;
            staticList.HighestBidder = highest.Name;

            return staticList;
        }
    }
}
