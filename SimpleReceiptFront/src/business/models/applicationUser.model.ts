import { Company } from './company.model';
import { Cafe } from './cafe.model';
import { Receipt } from './receipt.model';

export class ApplicationUser {
  public id: string;
  public userName?: string;
  public firstName: string;
  public lastName: string;
  public cafes: Cafe[];
  public receipts: Receipt[];
}
