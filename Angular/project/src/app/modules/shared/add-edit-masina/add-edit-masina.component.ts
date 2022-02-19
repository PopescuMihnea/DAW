import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Id } from 'src/app/interfaces/id';
import { DataService } from 'src/app/services/data.service';
import { MasiniService } from 'src/app/services/masini.service';

@Component({
  selector: 'app-add-edit-masina',
  templateUrl: './add-edit-masina.component.html',
  styleUrls: ['./add-edit-masina.component.scss']
})
export class AddEditMasinaComponent implements OnInit, OnDestroy {

  public addMessage: any;
  public subscription!: Subscription;

  public editId: any;
  public subscription2!: Subscription;

  public titlu!: string;

  public masinaForm: FormGroup = new FormGroup({
    marca: new FormControl (''),
    model: new FormControl (''),
    culoare: new FormControl (''),
    anFabricare: new FormControl (''),
    km: new FormControl (0),
    cost: new FormControl (0),
    descriere: new FormControl(''),
  });
  constructor(
    private masiniService: MasiniService,
    private dataService: DataService,
  ) { }

  get marca(): AbstractControl{
    return this.masinaForm.get('marca') as FormGroup;
  }

  get model(): AbstractControl{
    return this.masinaForm.get('model') as FormGroup;
  }

  get culoare(): AbstractControl{
    return this.masinaForm.get('culoare') as FormGroup;
  }

  get anFabricare(): AbstractControl{
    return this.masinaForm.get('anFabricare') as FormGroup;
  }

  get km(): AbstractControl{
    return this.masinaForm.get('km') as FormGroup;
  }

  get cost(): AbstractControl{
    return this.masinaForm.get('cost') as FormGroup;
  }

  get descriere(): AbstractControl{
    return this.masinaForm.get('descriere') as FormGroup;
  }

  ngOnInit(): void {
    this.subscription=this.dataService.currentMsg.subscribe(message => this.addMessage = message)
    this.subscription2= this.dataService.currentId.subscribe( id => this.editId = id);

    if (this.editId.id != -1)
    {
      this.loadMasina({id: this.editId.id});
      this.titlu="Modifica masina";
    }
    else
    {
      this.titlu="Adauga masina";
    }
    console.log(this.editId.id);
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
      this.addMessage.msg='';
  }

  public addMasina(): void{
    this.masiniService.addMasina(this.masinaForm.value).subscribe(
      (result) => {
        this.dataService.changeMessageData({msg: "Adaugare reusita cu id:"+result.id})
        console.log(result);
      },
      (error) => {
        this.dataService.changeMessageData({msg: "Adaugare nereusita, eroare:"+error.error})
        console.error(error);
      }
    );
  }

  public loadMasina(id: Id): void{
    this.masiniService.getMasinaById(id).subscribe(
      (result) =>{
        this.dataService.changeMessageData({msg: "Incarcare date reusita, de la masina cu id:"+result.id})
        this.masinaForm.patchValue(result);
        console.log(result);
      },
      (error) => {
        this.dataService.changeMessageData({msg: "Incarcare date nereusita "+error.error})
        console.log(error);
      }
    );
  }

  public editMasina(): void{
    this.masiniService.editMasina(this.editId, this.masinaForm.value).subscribe(
      (result) =>{
        this.dataService.changeMessageData({msg: "Editare date reusita, la masina cu id:"+result.id})
        console.log(result);
      },
      (error) => {
        this.dataService.changeMessageData({msg: "Editare nereusita, eroare:"+error.error})
        console.error(error);
      }
    )
  }

}

