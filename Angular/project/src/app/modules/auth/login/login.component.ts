import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  public loginForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });
  public loginMessage: any;
  public subscription!: Subscription;
  constructor(
    private router: Router,
    private accountService: AccountService,
    private dataService: DataService,
  ) { }

  get email(): AbstractControl{
    return this.loginForm.get("email") as FormGroup; 
  }
  get password(): AbstractControl{
    return this.loginForm.get("password") as FormGroup;
  }

  ngOnInit(): void {
    this.subscription=this.dataService.currentMsg.subscribe(message => this.loginMessage = message)
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  @HostListener ('document:keydown.enter') onKeydownHandler()
  {
    this.login();
  }

  public login(): void {
    const user = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password,
    }
    this.dataService.changeUserData(this.loginForm.value);
    this.accountService.login(user).subscribe((result) => {
      localStorage.setItem('token', result.token);
      this.dataService.changeMessageData({msg: ""})
      this.router.navigate(['/user-area']);
    }, 
    (error) => {
      this.dataService.changeMessageData({msg: "Login nereusit, eroare:"+error.error})
      console.log(error);
    }
    );
  }
  public register(): void {
    this.router.navigate(['auth/register']);
  }
}