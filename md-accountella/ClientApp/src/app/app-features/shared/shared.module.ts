import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BaseLandingComponent } from './base-landing/base-landing.component';
import { BaseCollectionComponent } from './base-collection/base-collection.component';
import { ClarityModule } from '@clr/angular';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [BaseLandingComponent, BaseCollectionComponent],
    imports: [CommonModule, FormsModule, ClarityModule],
    providers: [],
    exports: [BaseLandingComponent, BaseCollectionComponent]
})
export class SharedModule {

}
