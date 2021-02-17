import { PayService } from './../pay.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pay } from '../pay.model';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-pay-create',
  templateUrl: './pay-create.component.html',
  styleUrls: ['./pay-create.component.css']
})
export class PayCreateComponent implements OnInit {

  pay: Pay = {
    amount: 0,
    idAccount: Guid.createEmpty()
  }

  constructor(private payService: PayService,
    private router: Router) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/'])
  }

  makePay(): void {
    this.payService.create(this.pay).subscribe(() => {
      this.payService.showMessage('Successful pay!!!')
      this.router.navigate(['/pay'])
    })
  }

}
