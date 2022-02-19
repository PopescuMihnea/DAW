import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { PieseService } from 'src/app/services/piese.service';
import { AddEditPiesaComponent } from '../../shared/add-edit-piesa/add-edit-piesa.component';

@Component({
  selector: 'app-piese',
  templateUrl: './piese.component.html',
  styleUrls: ['./piese.component.scss']
})
export class PieseComponent implements OnInit {

  public piese = [];
  public displayedColumns = ['position','cost','tip','producator',
'anFabricatie','serie','info','sterge','modifica','descriere'];
  constructor(
    private router: Router,
    private pieseService: PieseService,
    private dialog: MatDialog,
    private dataService: DataService,
  ) { }

  ngOnInit(): void {
    this.pieseService.getPiese().subscribe(
      (result) => {
        console.log(result);
        this.piese=result.$values;
      },
      (error) =>{
        console.error(error);
      }
    );
  }
  public userArea(): void{
    this.router.navigate(['/user']);
  }
  public logout(): void
  {
    localStorage.removeItem('token');
    this.router.navigate(['/auth/login']);
  }
  public goToPiesa(id: any): void{
    this.router.navigate(['/piesa',id]);
  }
  public deletePiesa(id: any): void{
    this.pieseService.deletePiesa(id).subscribe(
      (result) =>{
        console.log(result);
        this.loadPiese();
      },
      (error) =>{
        console.error(error);
      }
    );
  }
  public loadPiese(): void{
    this.pieseService.getPiese().subscribe(
      (result) => {
        console.log(result);
        this.piese=result.$values;
      },
      (error) =>{
        console.error(error);
      }
    );
  }
  
  public openModal(): void{
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width= '600px';
    dialogConfig.height = '800px';
    const dialog = this.dialog.open(AddEditPiesaComponent, dialogConfig);

    dialog.afterClosed().subscribe(
      () => {
        this.loadPiese();
      }
    )
  }

  public addNewPiesa(): void{
    this.openModal();
    this.dataService.changeIdData({id:-1});
  }

  public editPiesa(id: any): void{
    this.openModal();
    this.dataService.changeIdData({id: id});
  }

}
