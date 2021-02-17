import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/template/header/header.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { FooterComponent } from './components/template/footer/footer.component';
import { NavComponent } from './components/template/nav/nav.component';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { HomeComponent } from './views/home/home.component';
import { BankaccountCrudComponent } from './views/bankaccount-crud/bankaccount-crud.component';
import { AccountGetComponent } from './components/account/account-get/account-get.component';

import { HttpClientModule } from '@angular/common/http';
import { WithdrawalCreateComponent } from './components/withdrawal/withdrawal-create/withdrawal-create.component';

import { MatSnackBarModule } from '@angular/material/snack-bar';

import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { DepositCreateComponent } from './components/deposit/deposit-create/deposit-create.component';
import { PayCreateComponent } from './components/pay/pay-create/pay-create.component';
import { BankstatementReadComponent } from './components/bankstatement/bankstatement-read/bankstatement-read.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { BankstatementRead2Component } from './components/bankstatement/bankstatement-read2/bankstatement-read2.component';
import { BankstatementSearchComponent } from './components/bankstatement/bankstatement-search/bankstatement-search.component';

registerLocaleData(localePt);
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    HomeComponent,
    BankaccountCrudComponent,
    AccountGetComponent,
    WithdrawalCreateComponent,
    DepositCreateComponent,
    PayCreateComponent,
    BankstatementReadComponent,
    BankstatementRead2Component,
    BankstatementSearchComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    HttpClientModule,
    MatSnackBarModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule
  ],
  providers: [
    // provide: LOCALE_ID,
    // useValue: 'pt-BR'
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
