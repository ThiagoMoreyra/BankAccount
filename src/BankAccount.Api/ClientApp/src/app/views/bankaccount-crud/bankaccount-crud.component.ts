import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-bankaccount-crud',
  templateUrl: './bankaccount-crud.component.html',
  styleUrls: ['./bankaccount-crud.component.css']
})
export class BankaccountCrudComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

}
