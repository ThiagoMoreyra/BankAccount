import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-account-get',
  templateUrl: './account-get.component.html',
  styleUrls: ['./account-get.component.css']
})
export class AccountGetComponent implements OnInit {

  amount = 0;
  Account: Account | undefined

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  search(): any {
    this.accountService.get().subscribe(a => {
      this.amount = a;
      console.log('teste');
    })
  }
}
