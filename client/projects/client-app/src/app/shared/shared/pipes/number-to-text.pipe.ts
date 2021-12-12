import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'numberToText'
})
export class NumberToTextPipe implements PipeTransform {

  transform(value: number | string): string {
    const val = +value;

    if (val > 1000000) {
      return val.toFixed(1) + 'M';
    }

    if (val > 1000) {
      return val.toFixed(1) + 'k';
    }

    return val.toString();
  }

}
