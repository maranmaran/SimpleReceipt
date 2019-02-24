import { PriceTableQuery } from './priceTableQuery.model';
import { Receipt } from './receipt.model';
export class ReceiptPriceTableQuery {
  public quantity: number;
  public receiptId: number;
  public receipt: Receipt;
  public priceTableQueryId: number;
  public priceTableQuery: PriceTableQuery;

  constructor(priceTableQueryId: number, quantity: number) {
      this.priceTableQueryId = priceTableQueryId;
      this.quantity = quantity;

  }
}
