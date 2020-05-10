import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BaseLandingComponent } from './base-landing/base-landing.component';
import { BaseCollectionComponent } from './base-collection/base-collection.component';
import { ClarityModule } from '@clr/angular';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [BaseLandingComponent, BaseCollectionComponent],
    imports: [CommonModule, FormsModule, ClarityModule],
    providers: [],
    exports: [
        ClarityModule,
        FormsModule,
        ReactiveFormsModule,
        BaseLandingComponent,
        BaseCollectionComponent
    ]
})
export class SharedModule {

}
