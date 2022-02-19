import { Directive, ElementRef, HostListener, OnInit } from '@angular/core';

@Directive({
  selector: '[appResize]'
})
export class ResizeDirective implements OnInit {
  public originalSize!: string;

  constructor(
    public el: ElementRef,
  ) { }

  ngOnInit(): void {
    this.originalSize=this.el.nativeElement.style.fontSize;
  }

  @HostListener('mouseenter') onMouseEnter()
  {
    this.resize('35px');
    this.el.nativeElement.style.color = "red";
  }
  @HostListener('mouseleave') onMouseLeave()
  {
    this.resize(this.originalSize);
    this.el.nativeElement.style.color = "";
  }

  private resize(size: string){
    this.el.nativeElement.style.fontSize=size;
  }

}
