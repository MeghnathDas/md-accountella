import { NgModule } from '@angular/core';
import { TitleService } from './title-service/title.service';
import { CustomClarityIcons } from './clarity-icons/custom-clearity-icons.service';
import { Title } from '@angular/platform-browser';

@NgModule({
    declarations: [],
    imports: [],
    providers: [Title, TitleService, CustomClarityIcons],
    exports: []
})
export class CoreModule {
}
