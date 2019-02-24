import { Table } from './table.model';
import { ApplicationUser } from './applicationUser.model';
import { Cafe } from './cafe.model';
import { PriceTableQuery } from './priceTableQuery.model';

export class Receipt {
  public id: number;
  public total: number;
  public createdOn: Date;
  public table: Table;
  public waiter: ApplicationUser;
  public cafe: Cafe;

  public priceTableQueries: PriceTableQuery[];
}
