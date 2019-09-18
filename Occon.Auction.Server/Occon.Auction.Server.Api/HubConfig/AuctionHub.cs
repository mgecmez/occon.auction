using Microsoft.AspNetCore.SignalR;
using Occon.Auction.Server.Api.DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occon.Auction.Server.Api.HubConfig
{
    public class AuctionHub : Hub
    {
        public async Task SendPlaceBid(string name, decimal price)
        {
            var data = DataManager.SetData(name, price);
            await Clients.All.SendAsync("SendPlaceBid", data);
        }

        public async Task RestoreData()
        {
            var data = DataManager.GetData(true);
            await Clients.All.SendAsync("RestoreData", data);
        }
    }
}
