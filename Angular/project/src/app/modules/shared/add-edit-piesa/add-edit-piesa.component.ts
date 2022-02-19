import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Id } from 'src/app/interfaces/id';
import { DataService } from 'src/app/services/data.service';
import { PieseService } from 'src/app/services/piese.service';

@Component({
  selector: 'app-add-edit-piesa',
  templateUrl: './add-edit-piesa.component.html',
  styleUrls: ['./add-edit-piesa.component.scss']
})
export class AddEditPiesaComponent implements OnInit, OnDestroy {

  public addMessage: any;
  public subscription!: Subscription;

  public editId: any;
  public subscription2!: Subscription;

  public titlu!: string;

  public piesaForm: FormGroup = new FormGroup({

    cost: new FormControl (0),
    tip: new FormControl (''),
    producator: new FormControl (''),
    anFabricatie: new FormControl (0),
    serie: new FormControl (''),
    descriere: new FormControl(''),
  });
  constructor(
    private pieseService: PieseService,
    private dataService: DataService,
  ) { }

  get cost(): AbstractControl{
    return this.piesaForm.get('cost') as FormGroup;
  }

  get tip(): AbstractControl{
    return this.piesaForm.get('tip') as FormGroup;
  }

  get producator(): AbstractControl{
    return this.piesaForm.get('producator') as FormGroup;
  }

  get anFabricatie(): AbstractControl{
    return this.piesaForm.get('anFabricatie') as FormGroup;
  }

  get serie(): AbstractControl{
    return this.piesaForm.get('serie') as FormGroup;
  }

  get descriere(): AbstractControl{
    return this.piesaForm.get('descriere') as FormGroup;
  }

  ngOnInit(): void {
    this.subscription=this.dataService.currentMsg.subscribe(message => this.addMessage = message)
    this.subscription2= this.dataService.currentId.subscribe( id => this.editId = id);

    if (this.editId.id != -1)
    {
      this.loadPiesa({id: this.editId.id});
      this.titlu="Modifica piesa";
    }
    else
    {
      this.titlu="Adauga piesa";
    }
    console.log(this.editId.id);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.addMessage.msg='';
}

public addPiesa(): void{
  if (this.piesaForm.value.serie == '')
  {
    this.dataService.changeMessageData({msg: "Trebuie introdusa seria"});
    console.error("Nu a fost data seria");
  }
  else
  {
    this.pieseService.addPiesa(this.piesaForm.value).subscribe(
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
}

public loadPiesa(id: Id): void{
  this.pieseService.getPiesaById(id).subscribe(
    (result) =>{
      this.dataService.changeMessageData({msg: "Incarcare date reusita, de la piesa cu id:"+result.id})
      this.piesaForm.patchValue(result);
      console.log(result);
    },
    (error) => {
      this.dataService.changeMessageData({msg: "Incarcare date nereusita "+error.error})
      console.log(error);
    }
  );
}

public editPiesa(): void{
  if (this.piesaForm.value.serie == '')
  {
    this.dataService.changeMessageData({msg: "Trebuie introdusa seria"});
    console.error("Nu a fost data seria");
  }
  else
  {
  this.pieseService.editPiesa(this.editId, this.piesaForm.value).subscribe(
    (result) =>{
      this.dataService.changeMessageData({msg: "Editare date reusita, la piesa cu id:"+result.id})
      console.log(result);
    },
    (error) => {
      this.dataService.changeMessageData({msg: "Editare nereusita, eroare:"+error.error})
      console.error(error);
    }
  );
  }
}

}
