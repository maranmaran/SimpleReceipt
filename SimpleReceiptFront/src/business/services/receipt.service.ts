import { Injectable, OnInit, EventEmitter } from '@angular/core';
import { Receipt } from '../models/receipt.model';
import { HttpClient } from '@angular/common/http';
import { plainToClass } from 'class-transformer';

@Injectable()
export class ReceiptService implements OnInit {

  headers = { headers: { 'Content-Type': 'application/json' } };

  newReceipts = new EventEmitter<Receipt[]>();
  selectedReceipt = new EventEmitter<Receipt>();
  receiptCreated = new EventEmitter<void>();

  constructor(
    private http: HttpClient
    ) {}

  ngOnInit() {
  }

  newInstance(plainObject: Receipt) {
    return plainToClass(Receipt, plainObject);
  }

  createInstances(items: Receipt[]): Array<Receipt> {
    const model = items;
    const viewModel = new Array<Receipt>();
    model.forEach(modelItem => {
      viewModel.push(this.newInstance(modelItem));
    });

    return viewModel;
  }

  getAllReceiptsByCafeId(cafeId: string, url = 'api/receipts/getallreceipts/') {
    return this.http.get(url + cafeId, this.headers);
  }

  GetAllReceiptPriceTableQueryByReceiptId(receiptId: number, url = 'api/receipts/GetAllReceiptPriceTableQueryByReceiptId/') {
    return this.http.get(url + receiptId, this.headers);
  }


  createReceipt(receipt: Receipt, url = 'api/receipts/createreceipt') {
    this.http.post(url, receipt, this.headers).subscribe(
      () => {
        this.receiptCreated.emit();
      },
      err => console.log(err)
    );
  }

}
