using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Occon.Auction.Server.Api.DataStorage;
using Occon.Auction.Server.Api.HubConfig;
using Occon.Auction.Server.Api.TimerFeatures;

namespace Occon.Auction.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private IHubContext<AuctionHub> _hub;

        public AuctionController(IHubContext<AuctionHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() =>
                _hub.Clients.All.SendAsync("TransferAuctionData", DataManager.GetData(false)));

            return Ok(DataManager.GetData(false));
        }
    }
}