import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VotarComponent } from './votar/votar.component';
import { RouterModule } from '@angular/router';
import { ButtonAllModule } from '@syncfusion/ej2-angular-buttons';
import { TextBoxAllModule } from '@syncfusion/ej2-angular-inputs';



@NgModule({
  declarations: [
    VotarComponent
  ],
  imports: [
    CommonModule,
    ButtonAllModule,
    TextBoxAllModule,
    RouterModule.forChild([
      {
        path: '',
        component: VotarComponent
      }
    ])
  ]
})
export class VotarModule { }
