import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate'
})
export class TruncatePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    if (value == null)
      return 'Fara descriere';
    if (value.length>5)
      return value.slice(0,5)+'...';
    return value;
  }

}
