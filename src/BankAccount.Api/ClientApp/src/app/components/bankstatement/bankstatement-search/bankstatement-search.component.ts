import { BankStatementSearch } from './../bankstatement.search.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-bankstatement-search',
  templateUrl: './bankstatement-search.component.html',
  styleUrls: ['./bankstatement-search.component.css']
})
export class BankstatementSearchComponent implements OnInit {

  bankStatementSearch: BankStatementSearch = {
    idAccount: Guid.createEmpty()
  }

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  searchBankStatement(): void {
    this.router.navigate(['/bankstatementtable'])
  }
}
