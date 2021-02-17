import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { Pay } from './pay.model';

@Injectable({
  providedIn: 'root'
})
export class PayService {

  baseUrl = "https://localhost:5001/api/v1/pay"

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

  create(pay: Pay): Observable<Pay> {
    return this.http.post<Pay>(this.baseUrl, pay)
  }
}
