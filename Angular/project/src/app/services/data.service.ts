import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Id } from '../interfaces/id';
import { Message } from '../interfaces/message';
import { RegisterUser } from '../interfaces/register-user';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private userSource = new BehaviorSubject({
    email: '',
    password: '',
  });
  public currentUser = this.userSource.asObservable();

  private registerSource = new BehaviorSubject({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
  });
   public currentRegisterUser = this.registerSource.asObservable();

  private messageSource = new BehaviorSubject({
    msg: '',
  });
  public currentMsg = this.messageSource.asObservable();

  private idSource= new BehaviorSubject({
    id: 0,
  });
  public currentId = this.idSource.asObservable();

  constructor() { }

  public changeUserData(user: User): void{
    this.userSource.next(user)
  }
  public changeRegisterUserData (registerUser: RegisterUser): void{
    this.registerSource.next(registerUser);
  }

  public changeMessageData (message: Message): void{
    this.messageSource.next(message);
  }

  public changeIdData (id: Id) : void{
    this.idSource.next(id);
  }

}
