import { Product } from './product.model';
import { PriceTable } from './priceTable.model';
import { ReceiptPriceTableQuery } from './receiptPriceTableQuery.model';

export class PriceTableQuery {
    public id: number;
    public price: number;
    public product: Product;
    public priceTable: PriceTable;
    public receiptPriceTableQueries: ReceiptPriceTableQuery[];
}
