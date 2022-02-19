import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Id } from '../interfaces/id';

@Injectable({
  providedIn: 'root'
})
export class MasiniService {

  public url: string = 'https://localhost:44395/api/Masina';

  private headers= new HttpHeaders()
  .set('Authorization', `Bearer ${localStorage.getItem('token')}`)
  .set('Content-Type', 'application/json');

  constructor(
    public http: HttpClient,
  ) { }

  public getMasini() : Observable<any>{
    return this.http.get(`${this.url}`,{headers: this.headers});
  }

  public getMasinaById(id: any): Observable <any>{
    return this.http.get(`${this.url}/${id.id}`,{headers: this.headers});
  }

  public deleteMasina(id :any): Observable <any>
  {
    return this.http.delete(`${this.url}/${id}`,{headers: this.headers});
  }

  public addMasina(masina: any): Observable<any>{
    return this.http.post(`${this.url}`,masina, {headers: this.headers});
  }

  public editMasina(id: Id, masina: any): Observable<any>{
    return this.http.put(`${this.url}/update_masina/${id.id}`,masina, {headers: this.headers});
  }

}
