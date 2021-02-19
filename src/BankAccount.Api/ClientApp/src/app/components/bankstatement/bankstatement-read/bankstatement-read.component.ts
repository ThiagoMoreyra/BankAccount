import { BankstatementService } from './../bankstatement.service';
import { BankStatement } from './../bankstatement.model';
import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Route } from '@angular/compiler/src/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bankstatement-read',
  templateUrl: './bankstatement-read.component.html',
  styleUrls: ['./bankstatement-read.component.css']
})
export class BankstatementReadComponent implements OnInit {

  bankStatements: BankStatement[];
  displayedColumns = ['amount', 'transaction', 'date', 'avaliablebalance'];

  // EXAMPLE_DATA: BankStatement[] = [
  //   { amount: '1', transaction: 'Deposit', date: '23/11/2019', avaliableBalance: '123.0' },
  //   { amount: '1', transaction: 'Deposit', date: '23/11/2019', avaliableBalance: '140.0' },
  // ];

  constructor(
    private bankSatementService: BankstatementService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('idAccount');
    this.bankSatementService.read(Guid.create()).subscribe(res => {
      this.bankStatements = res;
    })
  }
}
