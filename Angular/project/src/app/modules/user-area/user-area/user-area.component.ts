import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-user-area',
  templateUrl: './user-area.component.html',
  styleUrls: ['./user-area.component.scss']
})
export class UserAreaComponent implements OnInit, OnDestroy {
  public subscription!: Subscription;
  public loggedUser: any;
  constructor(
    private router: Router,
    private dataService: DataService,
    ) { }

  ngOnInit(): void {
    this.subscription=this.dataService.currentUser.subscribe(user => this.loggedUser= user);
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }
  public logout(): void
  {
    localStorage.removeItem('token');
    this.router.navigate(['/auth/login']);
  }
  public masini(): void
  {
    this.router.navigate(['/masini']);
  }
  public piese(): void
  {
    this.router.navigate(['/piese']);
  }
}
