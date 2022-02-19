import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MasiniService } from 'src/app/services/masini.service';

@Component({
  selector: 'app-masina',
  templateUrl: './masina.component.html',
  styleUrls: ['./masina.component.scss']
})
export class MasinaComponent implements OnInit {

  public subscription!: Subscription;
  public id!: number;
  public masina: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private masiniService: MasiniService,
  ) { }

  ngOnInit(): void {
    this.subscription=this.route.params.subscribe(params =>{
      this.id = +params['id'];
      if (this.id)
      {
        this.getMasina();
      }
    })
  }

  public getMasina(): void{
    this.masiniService.getMasinaById({id:this.id}).subscribe(
      (result) =>{
        console.log(result);
        this.masina= result;
      },
      (error) =>{
        console.error(error);
      }
    );
  }
  public masini(): void{
    this.router.navigate(['/masini']);
  }
  public logout(): void
  {
    localStorage.removeItem('token');
    this.router.navigate(['/auth/login']);
  }

}
