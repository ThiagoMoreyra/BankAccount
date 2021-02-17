import { WithdrawalCreateComponent } from './components/withdrawal/withdrawal-create/withdrawal-create.component';
import { BankaccountCrudComponent } from './views/bankaccount-crud/bankaccount-crud.component';
import { HomeComponent } from './views/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountGetComponent } from './components/account/account-get/account-get.component';
import { DepositCreateComponent } from './components/deposit/deposit-create/deposit-create.component';
import { PayCreateComponent } from './components/pay/pay-create/pay-create.component';
import { BankstatementReadComponent } from './components/bankstatement/bankstatement-read/bankstatement-read.component';
import { BankstatementRead2Component } from './components/bankstatement/bankstatement-read2/bankstatement-read2.component';

import { BankstatementSearchComponent } from './components/bankstatement/bankstatement-search/bankstatement-search.component';

const routes: Routes = [{
  path: "",
  component: HomeComponent
},
{
  path: "account",
  component: AccountGetComponent
},
{
  path: "withdrawal",
  component: WithdrawalCreateComponent
},
{
  path: "deposit",
  component: DepositCreateComponent
},
{
  path: "pay",
  component: PayCreateComponent
},
{
  path: "bankstatement",
  component: BankstatementSearchComponent
},
{
  path: "bankstatementtable",
  component: BankstatementReadComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
