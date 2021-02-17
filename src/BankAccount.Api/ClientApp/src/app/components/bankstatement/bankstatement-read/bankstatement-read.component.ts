import { BankstatementService } from './../bankstatement.service';
import { BankStatement } from './../bankstatement.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bankstatement-read',
  templateUrl: './bankstatement-read.component.html',
  styleUrls: ['./bankstatement-read.component.css']
})
export class BankstatementReadComponent implements OnInit {

  bankStatements: BankStatement[];
  displayedColumns = ['amount', 'transaction', 'date', 'avaliablebalance'];

  EXAMPLE_DATA: BankStatement[] = [
    { amount: '1', transaction: 'Deposit', date: '23/11/2019', avaliableBalance: '123.0' },
    { amount: '1', transaction: 'Deposit', date: '23/11/2019', avaliableBalance: '140.0' },
  ];

  constructor(private bankSatementService: BankstatementService) { }

  ngOnInit(): void {
    //this.bankSatementService.read().subscribe(bankStatements => {
    this.bankStatements = this.EXAMPLE_DATA
    //})
  }

}
