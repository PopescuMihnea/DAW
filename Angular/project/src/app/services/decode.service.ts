import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DecodeService {

  constructor() { }

  public isAdmin(token: string) {
    let tokenData= token.split('.')[1];
    let decodedTokenJsonData=window.atob(tokenData);
    let decodedTokenData=JSON.parse(decodedTokenJsonData);

    return decodedTokenData.role == 'Admin';
  }
}
