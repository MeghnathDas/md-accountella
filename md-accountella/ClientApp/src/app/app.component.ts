import { Component } from '@angular/core';
import { CustomClarityIcons } from './shared';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private clIcons: CustomClarityIcons) {
    this.clIcons.load();
  }

}

