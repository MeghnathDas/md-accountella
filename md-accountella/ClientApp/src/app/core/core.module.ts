import { NgModule } from '@angular/core';
import { TitleService } from './title-service/title.service';
import { CustomClarityIcons } from './clarity-icons/custom-clearity-icons.service';
import { Title } from '@angular/platform-browser';
import { BlockInteractionService } from './block-interaction/block-interaction.service';

@NgModule({
    declarations: [],
    imports: [],
    providers: [
        Title,
        TitleService,
        CustomClarityIcons,
        BlockInteractionService
    ],
    exports: []
})
export class CoreModule {
}
