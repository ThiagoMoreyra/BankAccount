import { Withdrawal } from './../Withdrawal.model';
import { Router } from '@angular/router';
import { WithdrawalService } from './../withdrawal.service';
import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-withdrawal-create',
  templateUrl: './withdrawal-create.component.html',
  styleUrls: ['./withdrawal-create.component.css']
})
export class WithdrawalCreateComponent implements OnInit {

  withdrawal: Withdrawal = {
    amount: 0,
    idAccount: Guid.createEmpty()
  }

  constructor(private withdrawalService: WithdrawalService,
    private router: Router) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/'])
  }

  makeWithdrawal(): void {
    this.withdrawalService.create(this.withdrawal).subscribe(() => {
      this.withdrawalService.showMessage('Successful withdrawal!!!')
      this.router.navigate(['/withdrawal'])
    })
  }

}
