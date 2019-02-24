import { PriceTableQuery } from './../../../../business/models/priceTableQuery.model';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ReceiptService } from 'src/business/services/receipt.service';
import { AuthService } from '../../../../business/services/auth.service';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Receipt } from 'src/business/models/receipt.model';
import { ReceiptPriceTableQuery } from 'src/business/models/receiptPriceTableQuery.model';
import { ApplicationUser } from '../../../../business/models/applicationUser.model';
import { Table } from 'src/business/models/table.model';
import { CafeService } from '../../../../business/services/cafe.service';

@Component({
  selector: 'app-create-or-edit-receipt',
  templateUrl: './create-or-edit-receipt.component.html',
  styleUrls: ['./create-or-edit-receipt.component.scss'],
})
export class CreateOrEditReceiptComponent implements OnInit {

  receipt: Receipt = new Receipt();
  cafeId: string;
  userId: string;

  receiptPriceTableQueries: ReceiptPriceTableQuery[] = [
    new ReceiptPriceTableQuery(-1, 0)
  ];

  receiptForm: FormGroup;
  get formControls() { return (this.receiptForm.get('priceTableQueries') as FormArray).controls; }

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private receiptService: ReceiptService,
    private cafeService: CafeService,
    private authService: AuthService,
    private fb: FormBuilder,
    ) {
     // force route reload whenever params change;
     this.router.routeReuseStrategy.shouldReuseRoute = () => false;
   }

   ngOnInit() {
    this.cafeId = this.route.snapshot.paramMap.get('id');
    this.userId = this.authService.getUserId();

    this.receipt = new Receipt();
    this.receipt.cafeId = this.cafeId;
    this.receipt.total = 0;

    this.getData();

    this.createForm();
  }

  // tslint:disable-next-line:member-ordering
  waiters: ApplicationUser[] = [];
  // tslint:disable-next-line:member-ordering
  tables: Table[] = [];
  // tslint:disable-next-line:member-ordering
  priceTableQueries: PriceTableQuery[] = [];

  getData() {
     this.getWaiters();
     this.getTables();
     this.getPriceTableQueries();
  }

  getTables() {
    this.cafeService.getAllTables(this.cafeId).subscribe(
      (res: any) => {
        this.tables = res;
      },
      err => console.log(err)
    );
  }

  getWaiters() {
    this.cafeService.getAllWaiters(this.cafeId).subscribe(
      (res: any) => {
        this.waiters = res;
      },
      err => console.log(err)
    );
  }

  getPriceTableQueries()  {
    this.cafeService.getAllPriceTableQueries(this.cafeId).subscribe(
      (res: any) => {
        this.priceTableQueries = res;
      },
      err => console.log(err)
    );
  }

  createForm() {
    this.receiptForm = this.fb.group({
      table: new FormControl(-1, Validators.required),
      waiter: new FormControl(-1, Validators.required),
      priceTableQueries: this.fb.array([])
    });
    this.patchValues();
  }

  patchValues() {
    const controls = this.formControls;
    this.receiptPriceTableQueries.forEach(() => controls.push(
      this.fb.group({
        priceTableQuery: new FormControl(-1, Validators.required),
        quantity: new FormControl(0, [Validators.required, Validators.min(1)]),
      })));
  }

  onQuantityChange() {
    let sum = 0;
    this.formControls.forEach(item => {
        const priceTableQuery = item.get('priceTableQuery').value;
        const quantity = item.get('quantity').value;
        sum += quantity * this.priceTableQueries.find(x => x.id === priceTableQuery).price;
      });

    this.receipt.total = sum;
  }

  addNewItem() {
    const controls = this.formControls;
    controls.push(
      this.fb.group({
        priceTableQuery: new FormControl(-1, Validators.required),
        quantity: new FormControl(0, [Validators.required, Validators.min(1)]),
      }));
  }

  onSubmit() {
      const waiter = this.receiptForm.get('waiter').value;
      const table = this.receiptForm.get('table').value;

      let validity = true;
      const receiptPriceTableQueries = [];
      this.formControls.forEach(item => {
        if (item.valid) {
          const priceTableQuery = item.get('priceTableQuery').value;
          const quantity = item.get('quantity').value;

          receiptPriceTableQueries.push(new ReceiptPriceTableQuery(priceTableQuery, quantity));
        } else {
          validity = false;
        }
      });

      if (validity && waiter !== -1 && table !== -1) {
        this.receipt.waiterId = waiter;
        this.receipt.tableId = table;
        this.receipt.receiptPriceTableQueries = receiptPriceTableQueries;
        this.receipt.createdOn = new Date();

        this.receiptService.createReceipt(this.receipt);
        this.router.navigate(['/receipts', this.cafeId]);
      }
  }

  removeItem(index: number) {
    (this.receiptForm.get('priceTableQueries') as FormArray).removeAt(index);
  }

}
