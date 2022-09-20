import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CandidatosComponent } from './candidatos/candidatos.component';
import { RouterModule } from '@angular/router';
import { DashboardLayoutAllModule } from '@syncfusion/ej2-angular-layouts';
import { ToolbarAllModule } from '@syncfusion/ej2-angular-navigations';
import { DialogAllModule } from '@syncfusion/ej2-angular-popups';
import { ButtonAllModule } from '@syncfusion/ej2-angular-buttons';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CandidatosComponent
  ],
  imports: [
    CommonModule,
    DashboardLayoutAllModule,
    ButtonAllModule,
    ToolbarAllModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {
        path: '',
        component: CandidatosComponent
      }
    ])
  ],
  providers: [ ]
})
export class CandidatosModule { }
