import { BidderModel } from './bidder.model';

export interface AuctionModel{
    EndTime: string,
    deadline: string,
    bidders: BidderModel[],
    highestBidder: string,
    highestBid: number,
    balanceTime: string,
    key: string
}