import { Receipt } from './../../../../business/models/receipt.model';
import { Component, OnInit, Input, ViewChild, Output, EventEmitter, OnDestroy } from '@angular/core';
import { ReceiptService } from '../../../../business/services/receipt.service';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';

@Component({
  selector: 'app-receipts-list',
  templateUrl: './receipts-list.component.html',
  styleUrls: ['./receipts-list.component.scss']
})
export class ReceiptsListComponent implements OnInit, OnDestroy {


  receipts: Receipt[] = [];
  displayedColumns: string[] = ['date', 'waiter', 'table', 'total'];
  pageSize = 12;
  dataSource: MatTableDataSource<Receipt>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Output() selectedReceipt = new EventEmitter<Receipt>();

  constructor(private receiptService: ReceiptService) { }

  ngOnInit() {
    this.receiptService.newReceipts.subscribe(
      (receipts: Receipt[]) => {
        this.receipts = receipts;
        console.log(this.receipts);
        this.dataSource = new MatTableDataSource(this.receipts);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      err => console.log(err)
    );
  }

  ngOnDestroy() {
    this.receiptService.newReceipts.unsubscribe();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue;

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  formatOutput(types: string[]) {
    const output = types.join(', ');
    return output.trim();
  }

  onClick(receipt: Receipt) {
    this.selectedReceipt.emit(receipt);
  }

}
