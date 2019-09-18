import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../services/signalr.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-auction',
  templateUrl: './auction.component.html',
  styleUrls: ['./auction.component.css']
})
export class AuctionComponent implements OnInit {

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
      })
  }

}
