import { Directive, ElementRef, OnInit } from '@angular/core';
import { DecodeService } from './services/decode.service';

@Directive({
  selector: '[appAdminOnly]'
})
export class AdminOnlyDirective implements OnInit{

  constructor(
    private decodeService: DecodeService,
    public el: ElementRef,
  ) { }
  ngOnInit(): void {
    if (!this.decodeService.isAdmin(localStorage.getItem('token')+''))
      {
        this.el.nativeElement.style.display = "none";
      }
    else{
      this.el.nativeElement.style.cursor= "pointer";
    }
  }
  
}
