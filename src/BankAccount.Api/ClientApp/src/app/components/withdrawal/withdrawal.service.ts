import { MatSnackBarModule } from '@angular/material/snack-bar';
import { Withdrawal } from './Withdrawal.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class WithdrawalService {

  baseUrl = "https://localhost:5001/api/v1/withdrawal"

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

  create(withdrawal: Withdrawal): Observable<Withdrawal> {
    return this.http.post<Withdrawal>(this.baseUrl, withdrawal)
  }
}
