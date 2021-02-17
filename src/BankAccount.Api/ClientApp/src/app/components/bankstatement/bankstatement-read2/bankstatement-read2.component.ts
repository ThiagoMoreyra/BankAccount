import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { BankStatement } from '../bankstatement.model';
import { BankstatementRead2DataSource } from './bankstatement-read2-datasource';

@Component({
  selector: 'app-bankstatement-read2',
  templateUrl: './bankstatement-read2.component.html',
  styleUrls: ['./bankstatement-read2.component.css']
})
export class BankstatementRead2Component implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<BankStatement>;
  dataSource: BankstatementRead2DataSource;

  bankStatments: BankStatement[]
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['amount', 'transaction', 'date', 'avaliableBalance'];

  ngOnInit() {
    this.dataSource = new BankstatementRead2DataSource();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
