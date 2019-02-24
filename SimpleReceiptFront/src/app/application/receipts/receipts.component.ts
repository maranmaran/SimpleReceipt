import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Receipt } from 'src/business/models/receipt.model';
import { ReceiptService } from 'src/business/services/receipt.service';

@Component({
  selector: 'app-receipts',
  templateUrl: './receipts.component.html',
  styleUrls: ['./receipts.component.scss'],
  providers: [ReceiptService]
})
export class ReceiptsComponent implements OnInit {

  cafeId: string;
  receiptSelected = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private receiptService: ReceiptService
    ) {
     // force route reload whenever params change;
     this.router.routeReuseStrategy.shouldReuseRoute = () => false;
   }

  ngOnInit() {
    this.cafeId = this.route.snapshot.paramMap.get('id');
    this.getAllCafeReceipts();
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
