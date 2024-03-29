import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private dataService: DataService,
    private accountService: AccountService,
    ) { }

    public mesaj: any;

    get firstName(): AbstractControl{
      return this.registerForm.get('firstName') as FormGroup;
    }
    get lastName(): AbstractControl{
      return this.registerForm.get('lastName') as FormGroup;
    }
    get email(): AbstractControl{
      return this.registerForm.get('email') as FormGroup;
    }
    get password(): AbstractControl{
      return this.registerForm.get('password') as FormGroup;
    }

  ngOnInit(): void {
    this.mesaj='';
  }

  @HostListener ('document:keydown.enter') onKeydownHandler()
  {
    this.register();
  }

  public register(): void
  {
    const registerUser={
      firstName: this.registerForm.value.firstName,
      lastName: this.registerForm.value.lastName,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
    }
    this.accountService.verifyMail(registerUser).subscribe(
      (result) =>{
        console.log(result);
        if (result.status != "invalid")
        {
          this.dataService.changeRegisterUserData(this.registerForm.value);
          this.accountService.register(registerUser).subscribe((result) => {
          console.log(result);
          this.mesaj="Inregistrat cu succes!";
        }, 
      (error) => {
          console.log(error);
          this.mesaj=error.error;
        }
      );
        }
        else
        {
          this.mesaj="Mail invalid";
        }
      },
      (error) =>{
        if (error.status == 400)
        {
          this.mesaj = "Mail invalid";
        }
        console.log(error);
      }
    );
    
  }
  public login(): void {
    this.router.navigate(['/auth/login']);
  }
}
