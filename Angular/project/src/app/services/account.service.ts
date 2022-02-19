import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
import { HttpClient } from '@angular/common/http';
import { RegisterUser } from '../interfaces/register-user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  public url: string = 'https://localhost:44395/api/Account';

  constructor(
    private http: HttpClient,
  ) {}

  
  public login(user: User): Observable<any> {
    return this.http.post<any>(`${this.url}/login`, user);
  }

  public verifyMail(registerUser: RegisterUser): Observable<any>
  {
   
    return this.http.get<any>("https://api.hunter.io/v2/email-verifier?email="+registerUser.email+"&api_key=be25d07775d9f5a1b18e3f9bfe89b321bbc860c0");
  }

  public register(registerUser: RegisterUser): Observable<any> {
    return this.http.post<any>(`${this.url}/register`,registerUser);
  }
}