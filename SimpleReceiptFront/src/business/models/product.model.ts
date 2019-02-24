import { PriceTableQuery } from './priceTableQuery.model';
import { Company } from './company.model';
export class Product {
  public id: number;
  public name: string;
  public type: number;
  public company: Company;
  public priceTableQueries: PriceTableQuery[];
}
