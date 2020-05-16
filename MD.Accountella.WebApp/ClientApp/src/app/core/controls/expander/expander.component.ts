import { Component, OnInit, forwardRef, Input, HostListener, HostBinding } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { SafeStyle, DomSanitizer } from '@angular/platform-browser';

export const DEFAULT_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => ExpanderComponent),
  multi: true
};
export enum ChevronDirection {
  right = 'right',
  left = 'left'
}
@Component({
  selector: 'app-expander',
  templateUrl: './expander.component.html',
  styleUrls: ['./expander.component.css']
})
export class ExpanderComponent implements OnInit {
  @HostBinding('style') style: SafeStyle;
  @HostBinding('attr.disabled') isDisabled: any;
  private _direction: ChevronDirection;
  @Input() set direction(value: ChevronDirection) {
    this._direction = value;
    this.setStyle();
  }
  get direction(): ChevronDirection {
    return this._direction;
  }
  private _expanded = true;
  @Input() set expanded(value: boolean) {
    this._expanded = value;
    this.setStyle();
  }
  get expanded(): boolean {
    return this._expanded;
  }
  private setStyle(): void {
    let strStyle = this.direction === ChevronDirection.left ?
      'flex-direction: row-reverse' : 'flex-direction: row';
    strStyle += '';
    this.style = this.sanitizer.bypassSecurityTrustStyle(strStyle);
  }

  constructor(private sanitizer: DomSanitizer) { }
  ngOnInit(): void {
  }
  get currentDirection(): string {
    if (this._expanded === true) {
      return this.direction;
    } else if (this._expanded === false) {
      return this.direction === ChevronDirection.left ? ChevronDirection.right : ChevronDirection.left;
    }
  }
  toggle(): void {
    // if (this.isDisabled === true) { return; }
    this.expanded = !this.expanded;
  }
  // @HostListener('click', ['$event'])
  // onMouseEnter(event: any) {
  //   console.log('Is disabled:', this.isDisabled);
  //   console.log('Is expanded: ', this._expanded);
  //   console.log('Direction: ', this.currentDirection);
  // }
}
