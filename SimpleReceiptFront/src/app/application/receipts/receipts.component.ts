import {ReceiptService} from '../../../business/services/receipt.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Receipt } from 'src/business/models/receipt.model';

@Component({
  selector: 'app-receipts',
  templateUrl: './receipts.component.html',
  styleUrls: ['./receipts.component.scss'],
})
export class ReceiptsComponent implements OnInit {

  cafeId: string;
  receiptSelected = false;

  constructor(
    private route: ActivatedRoute,
    private receiptService: ReceiptService
    ) {
      this.route.params.subscribe(params => {
        this.cafeId = params.id;
      });
   }

  ngOnInit() {
    this.getAllCafeReceipts();

    this.receiptService.receiptCreated.subscribe(
      () => this.getAllCafeReceipts(),
      err => console.log(err)
    );
  }

  getAllCafeReceipts() {
    this.receiptService.getAllReceiptsByCafeId(this.cafeId)
    .subscribe(
      (res: any) => {
        this.receiptService.newReceipts.emit(res);
      },
      err => console.log(err)
    );
  }

  onSelectReceipt(receipt: Receipt) {
    this.receiptSelected = true;
    this.receiptService.selectedReceipt.emit(receipt);
  }
}
