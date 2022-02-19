import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Id } from '../interfaces/id';

@Injectable({
  providedIn: 'root'
})
export class PieseService {

  public url: string = 'https://localhost:44395/api/Piesa';

  private headers= new HttpHeaders()
  .set('Authorization', `Bearer ${localStorage.getItem('token')}`)
  .set('Content-Type', 'application/json');

  constructor(
    public http: HttpClient,
  ) { }

  public getPiese() : Observable<any>{
    return this.http.get(`${this.url}`,{headers: this.headers});
  }
  public getPiesaById(id: Id): Observable <any>{
    return this.http.get(`${this.url}/${id.id}`,{headers: this.headers});
  }

  public deletePiesa(id :any): Observable <any>
  {
    return this.http.delete(`${this.url}/${id}`,{headers: this.headers});
  }

  public addPiesa(piesa: any): Observable<any>{
    return this.http.post(`${this.url}`,piesa, {headers: this.headers});
  }

  public editPiesa(id: Id, piesa: any): Observable<any>{
    return this.http.put(`${this.url}/update_piesa/${id.id}`,piesa, {headers: this.headers});
  }
}
