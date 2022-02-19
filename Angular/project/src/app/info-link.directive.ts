import { sanitizeIdentifier } from '@angular/compiler';
import { Directive, ElementRef, HostListener, OnInit } from '@angular/core';

@Directive({
  selector: '[appInfoLink]'
})
export class InfoLinkDirective implements OnInit{

  public originalSize!: string;
  constructor(
    public el: ElementRef,
  ) { }
  ngOnInit(): void {
    this.el.nativeElement.style.cursor = 'pointer';
    this.el.nativeElement.style.color = 'blue';
    this.originalSize=this.el.nativeElement.style.fontSize;
  }
    @HostListener('mouseenter') onMouseEnter()
    {
      this.resize('20px');
    }
    @HostListener('mouseleave') onMouseLeave()
    {
      this.resize(this.originalSize);
    }

    private resize(size: string){
      this.el.nativeElement.style.fontSize=size;
    }
}
