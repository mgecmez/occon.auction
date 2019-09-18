import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { AuctionModel } from "../models/auction.model";

@Injectable({
    providedIn: 'root'
})

export class SignalRService {
    public auctionData: AuctionModel;

    private hubConnection: signalR.HubConnection;

    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
                                .withUrl("https://localhost:5001/auction")
                                .build();
        
        this.hubConnection
            .start()
            .then(() => console.log("Connection started"))
            .catch(err => console.error("Error while starting connection: " + err));
    }

    public addTransferAuctionDataListener = () => {
        this.hubConnection.on("TransferAuctionData", (data) => {
            if(JSON.stringify(this.auctionData.bidders ) == JSON.stringify(data.bidders )){
                this.auctionData.balanceTime = data.balanceTime;
            }
            else{
                this.auctionData = data;
            }
        });
    }

    public sendPlaceBid = (txtPlaceBid) => {
        var user = txtPlaceBid.getAttribute('data-usern');
        var bid = txtPlaceBid.value;
        this.hubConnection.invoke("SendPlaceBid", user, bid)
        .catch(err => console.error(err));
    }

    public addSendPlaceBidListener = () => {
        this.hubConnection.on("SendPlaceBid", (data) => {
            this.auctionData = data;
        })
    }
}