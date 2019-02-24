import { PriceTableQuery } from './priceTableQuery.model';
import { Receipt } from './receipt.model';
export class ReceiptPriceTableQuery {
  public quantity: number;
  public receipt: Receipt;
  public priceTableQuery: PriceTableQuery;
}
