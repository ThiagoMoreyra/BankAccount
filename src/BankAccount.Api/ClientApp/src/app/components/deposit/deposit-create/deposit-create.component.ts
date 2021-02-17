import { Router } from '@angular/router';
import { DepositService } from './../deposit.service';
import { Component, OnInit } from '@angular/core';
import { Deposit } from '../deposit.model';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-deposit-create',
  templateUrl: './deposit-create.component.html',
  styleUrls: ['./deposit-create.component.css']
})
export class DepositCreateComponent implements OnInit {

  deposit: Deposit = {
    amount: 0,
    idAccount: Guid.createEmpty()
  }

  constructor(private depositService: DepositService, private router: Router) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/'])
  }

  makeDeposit(): void {
    this.depositService.create(this.deposit).subscribe(() => {
      this.depositService.showMessage('Successful deposit!!!')
      this.router.navigate(['/deposit'])
    })
  }

}
