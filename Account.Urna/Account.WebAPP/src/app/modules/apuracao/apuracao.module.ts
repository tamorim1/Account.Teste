import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApuracaoComponent } from './apuracao/apuracao.component';
import { RouterModule } from '@angular/router';
import { DashboardLayoutAllModule } from '@syncfusion/ej2-angular-layouts';
import { ToolbarAllModule } from '@syncfusion/ej2-angular-navigations';



@NgModule({
  declarations: [
    ApuracaoComponent
  ],
  imports: [
    CommonModule,
    DashboardLayoutAllModule,
    ToolbarAllModule,
    RouterModule.forChild([
      {
        path: '',
        component: ApuracaoComponent
      }
    ])
  ]
})
export class ApuracaoModule { }
