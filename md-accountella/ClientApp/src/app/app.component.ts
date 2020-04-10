import { Component } from '@angular/core';
import { ClarityIcons } from '@clr/icons';
import { CustomClarityIcons } from './shared';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(private clIcons: CustomClarityIcons) {
    this.clIcons.load();
  }

}
