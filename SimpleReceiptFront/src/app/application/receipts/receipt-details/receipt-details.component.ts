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
  ngOnInit() {
    this.receiptService.selectedReceipt.subscribe(
      (receipt: Receipt) => this.receipt = receipt,
      err => console.log(err)
    );
  }

}
