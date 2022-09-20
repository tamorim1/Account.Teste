import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: 'votar',
    loadChildren: () => import('../app/modules/votar/votar.module').then(m => m.VotarModule)
  },
  {
    path: 'candidatos',
    loadChildren: () => import('../app/modules/candidatos/candidatos.module').then(m => m.CandidatosModule)
  },
  {
    path: 'apuracao',
    loadChildren: () => import('../app/modules/apuracao/apuracao.module').then(m => m.ApuracaoModule)
  },
  {
    path: '',
    component: HomeComponent
  },
  {
    path: '**',
    component: HomeComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
