import { NgModule } from '@angular/core';
import { TitleService } from './title-service/title.service';
import { CustomClarityIcons } from './clarity-icons/custom-clearity-icons.service';
import { Title } from '@angular/platform-browser';
import { BlockInteractionService } from './block-interaction/block-interaction.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpInterceptorService } from './http-interceptor/http-intercept.service';
import { AutofocusDirective } from './directives/autofocus/autofocus.directive';
import { ChevronToggleComponent } from './controls/chevron-toggle/chevron-toggle.component';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [AutofocusDirective, ChevronToggleComponent],
    imports: [CommonModule],
    providers: [
        Title,
        TitleService,
        CustomClarityIcons,
        BlockInteractionService,
        { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptorService, multi: true }
    ],
    exports: [AutofocusDirective, ChevronToggleComponent]
})
export class CoreModule {
}
