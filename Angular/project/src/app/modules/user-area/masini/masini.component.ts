import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { MasiniService } from 'src/app/services/masini.service';
import { AddEditMasinaComponent } from '../../shared/add-edit-masina/add-edit-masina.component';

@Component({
  selector: 'app-masini',
  templateUrl: './masini.component.html',
  styleUrls: ['./masini.component.scss']
})
export class MasiniComponent implements OnInit {


  public masini = [];
  public displayedColumns = ['position','marca','model','culoare',
'anFabricare','km','cost','info','sterge','modifica','descriere'];
  constructor(
    private router: Router,
    private masiniService: MasiniService,
    public dialog: MatDialog,
    private dataService: DataService,
  ) { }

  ngOnInit(): void {
    this.masiniService.getMasini().subscribe(
      (result) => {
        console.log(result);
        this.masini=result.$values;
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
  public goToMasina(id: any): void{
    this.router.navigate(['/masina',id]);
  }
  public deleteMasina(id: any): void{
    this.masiniService.deleteMasina(id).subscribe(
      (result) =>{
        console.log(result);
        this.loadMasini();
      },
      (error) =>{
        console.error(error);
      }
    );
  }
  public loadMasini(): void{
    this.masiniService.getMasini().subscribe(
      (result) => {
        console.log(result);
        this.masini=result.$values;
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
    const dialog = this.dialog.open(AddEditMasinaComponent, dialogConfig);

    dialog.afterClosed().subscribe(
      () => {
        this.loadMasini();
      }
    )
  }

  public addNewMasina(): void{
    this.openModal();
    this.dataService.changeIdData({id:-1});
  }

  public editMasina(id: any): void{
    this.openModal();
    this.dataService.changeIdData({id: id});
  }
}
