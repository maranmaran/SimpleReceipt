import { Cafe } from './cafe.model';
import { Product } from './product.model';

export class Company {
  public id: number;
  public name: string;
  public cafes: Cafe[];
  public products: Product[];
}
