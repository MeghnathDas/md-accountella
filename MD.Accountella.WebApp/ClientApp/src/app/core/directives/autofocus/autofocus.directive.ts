import { Directive, ElementRef } from '@angular/core';

// tslint:disable-next-line:directive-selector
@Directive({ selector: '[autofocus]' })
export class AutofocusDirective {
  constructor(public elementRef: ElementRef) { }

  setFocus() {
    this.elementRef.nativeElement.select();
  }
}
