import { BankStatement } from './bankstatement.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BankstatementService {

  baseUrl = "https://localhost:5001/api/v1/bankstatement"

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

  read(): Observable<BankStatement[]> {
    return this.http.get<BankStatement[]>(this.baseUrl)
  }
}
