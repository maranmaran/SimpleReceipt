import { ReceiptPriceTableQuery } from './receiptPriceTableQuery.model';
import { Table } from './table.model';
import { ApplicationUser } from './applicationUser.model';
import { Cafe } from './cafe.model';
import { PriceTableQuery } from './priceTableQuery.model';

export class Receipt {
  public id: number;
  public total: number;
  public createdOn: Date;
  public tableId: string;
  public table: Table;
  public waiterId: string;
  public waiter: ApplicationUser;
  public cafeId: string;
  public cafe: Cafe;

  public receiptPriceTableQueries: ReceiptPriceTableQuery[];
}
