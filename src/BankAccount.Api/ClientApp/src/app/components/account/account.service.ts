import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = "https://localhost:5001/api/v1/account-yield"

  constructor(private http: HttpClient) { }

  get(): Observable<number> {
    return this.http.get<number>(this.baseUrl)
  }
}
