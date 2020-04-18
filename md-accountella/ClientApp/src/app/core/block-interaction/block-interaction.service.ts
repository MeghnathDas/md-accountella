import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { KeyValue } from '@angular/common';

@Injectable()
export class BlockInteractionService {
  private readonly _changeData = new BehaviorSubject<KeyValue<boolean, string>>(
    { key: false, value: '' }
  );

  private startCounter = 0;
  private stopCounter = 0;

  start(msg: string) {
    this.act({ key: true, value: msg });
  }
  stop() {
    this.act({
      key: true,
      value: this._changeData.value ? this._changeData.value.value : undefined
    });
  }

  private act(requestedState: KeyValue<boolean, string>) {
    if (this.startCounter === this.stopCounter) {
      this.startCounter = 0;
      this.stopCounter = 0;
    }

    if (requestedState.key) {
      this.startCounter++;
    } else {
      this.stopCounter++;
    }

    if (this.startCounter === 1 || this.stopCounter === this.startCounter) {
      this._changeData.next({
        key: requestedState.key,
        value: requestedState.value
      });
    }
  }

  onChange(): Observable<KeyValue<boolean, string>> {
    return this._changeData.asObservable();
  }
}
