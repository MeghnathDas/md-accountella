import { Injectable } from '@angular/core';
import { ClarityIcons } from '@clr/icons';

@Injectable()
export class CustomClarityIcons {
    icons: any = {
        'org-icon': `<svg version="1.0" xmlns="http://www.w3.org/2000/svg"
        width="138.000000pt" height="138.000000pt" viewBox="0 0 138.000000 138.000000"
        preserveAspectRatio="xMidYMid meet">
       <metadata>
        Author: Meghnath Das
       </metadata>
       <g transform="translate(0.000000,138.000000) scale(0.100000,-0.100000)"
       fill="#D5D4D4" stroke="none">
       <path d="M90 690 l0 -610 605 0 605 0 0 610 0 610 -605 0 -605 0 0 -610z m345
       108 c27 -37 52 -67 55 -67 3 -1 28 31 55 69 47 66 52 70 85 68 l35 -3 0 -180
       0 -180 -30 0 -30 0 -5 119 -5 119 -48 -62 c-27 -33 -52 -61 -56 -61 -12 0
       -181 224 -181 239 0 8 13 11 37 9 33 -3 43 -11 88 -70z m532 61 c93 -35 138
       -158 94 -255 -36 -79 -99 -107 -226 -102 l-80 3 -3 33 -3 32 86 0 c117 0 159
       23 165 90 5 55 -1 80 -24 107 -23 26 -30 28 -123 33 l-98 5 -3 33 -3 32 95 0
       c52 0 107 -5 123 -11z"/>
       </g>
       </svg>`
    };
    public load() {
        window['ClarityIcons'].add(this.icons);
    }
}
