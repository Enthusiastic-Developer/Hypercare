import { NgModule } from '@angular/core'
import { RouterModule, type Routes } from '@angular/router'
import { HomeComponent } from './home/home.component'
import { NotfoundComponent } from './shared/notfound/notfound.component'

const routes: Routes = [
  {
    path: 'menu',
    loadChildren: async () =>
      await import('./layout/layout.module').then((m) => m.LayoutModule),
  },
  {
    path: '',
    component: HomeComponent,
  },
  { path: '**', component: NotfoundComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
