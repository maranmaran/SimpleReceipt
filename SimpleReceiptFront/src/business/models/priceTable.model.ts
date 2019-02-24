import { PriceTableQuery } from './priceTableQuery.model';
import { Cafe } from './cafe.model';
export class PriceTable {
  public id: number;
  public cafe: Cafe;
  public priceTableQueries: PriceTableQuery[];
}
