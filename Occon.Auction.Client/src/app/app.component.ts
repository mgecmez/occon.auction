import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signalr.service';
import { HttpClient } from '@angular/common/http';
import { AuctionModel } from "./models/auction.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  // title = 'Occon Auction';
  data2;
  model: AuctionModel;

  constructor(public signalRService: SignalRService, private http: HttpClient) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferAuctionDataListener();
    this.signalRService.addSendPlaceBidListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:5001/api/auction')
      .subscribe(res => {
        this.signalRService.auctionData = res as AuctionModel;
      })
  }
}