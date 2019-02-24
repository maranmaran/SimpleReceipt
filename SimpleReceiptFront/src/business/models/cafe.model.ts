import { Company } from './company.model';
import { Table } from './table.model';
import { ApplicationUser } from './applicationUser.model';
import { PriceTable } from './priceTable.model';
import { Receipt } from './receipt.model';

export class Cafe {
  public id: number;
  public name: string;
  public company: Company;
  public priceTable: PriceTable;
  public waiters: ApplicationUser[];
  public tables: Table;
  public receipts: Receipt[];
}
