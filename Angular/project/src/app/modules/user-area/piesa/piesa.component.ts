import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PieseService } from 'src/app/services/piese.service';

@Component({
  selector: 'app-piesa',
  templateUrl: './piesa.component.html',
  styleUrls: ['./piesa.component.scss']
})
export class PiesaComponent implements OnInit {

  public subscription!: Subscription;
  public id!: number;
  public piesa: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private pieseService: PieseService,
  ) { }

  ngOnInit(): void {
    this.subscription=this.route.params.subscribe(params =>{
      this.id = +params['id'];
      if (this.id)
      {
        this.getPiesa();
      }
    })
  }

  public getPiesa(): void{
    this.pieseService.getPiesaById({id:this.id}).subscribe(
      (result) =>{
        console.log(result);
        this.piesa= result;
      },
      (error) =>{
        console.error(error);
      }
    );
  }
  public piese(): void{
    this.router.navigate(['/piese']);
  }
  public logout(): void
  {
    localStorage.removeItem('token');
    this.router.navigate(['/auth/login']);
  }
}
