import { BankStatementSearch } from './../bankstatement.search.model';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-bankstatement-search',
  templateUrl: './bankstatement-search.component.html',
  styleUrls: ['./bankstatement-search.component.css']
})
export class BankstatementSearchComponent implements OnInit {

  bankStatementSearch: BankStatementSearch

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('idAccount');
  }

  searchBankStatement(): void {
    this.router.navigate(['/bankstatementtable/' + this.bankStatementSearch.idAccount])
  }
}
