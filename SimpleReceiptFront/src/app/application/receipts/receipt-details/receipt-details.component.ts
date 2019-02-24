import { ReceiptPriceTableQuery } from './../../../../business/models/receiptPriceTableQuery.model';
import { Component, OnInit } from '@angular/core';
import { ReceiptService } from 'src/business/services/receipt.service';
import { Receipt } from 'src/business/models/receipt.model';

@Component({
  selector: 'app-receipt-details',
  templateUrl: './receipt-details.component.html',
  styleUrls: ['./receipt-details.component.scss']
})
export class ReceiptDetailsComponent implements OnInit {

  constructor(private receiptService: ReceiptService) { }

  receipt: Receipt;
  receiptPriceTableQueries: ReceiptPriceTableQuery[] = [];
  ngOnInit() {
    this.receiptService.selectedReceipt.subscribe(
      (receipt: Receipt) => {
        this.receipt = receipt;
        this.loadPriceTableQueries();
      },
      err => console.log(err)
    );
  }

  loadPriceTableQueries() {
    this.receiptService.GetAllReceiptPriceTableQueryByReceiptId(this.receipt.id).subscribe(
      (response: ReceiptPriceTableQuery[]) => this.receiptPriceTableQueries = response,
      err => console.log(err)
    );
  }

}
