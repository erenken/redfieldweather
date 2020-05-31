import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CurrentComponent } from './weather/current/current.component';
import { AboutComponent } from './about/about.component';


const routes: Routes = [
  { path: 'current', component: CurrentComponent },
  { path: 'about', component: AboutComponent },
  { path: '', redirectTo: '/current', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
