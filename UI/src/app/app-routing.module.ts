import { NgModule } from '@angular/core'
import { RouterModule, type Routes } from '@angular/router'
import { HomeComponent } from './home/home.component'
import { NotfoundComponent } from './shared/notfound/notfound.component'

const routes: Routes = [
  {
    path: 'history',
    loadChildren: async () => await import('./history/history.module').then((m) => m.HistoryModule)
  },
  {
    path: 'mapper',
    loadChildren: async () => await import('./mapper/mapper.module').then((m) => m.MapperModule)
  },
  {
    path: 'master',
    loadChildren: async () => await import('./master/master.module').then((m) => m.MasterModule)
  },
  {
    path: 'schedule',
    loadChildren: async () =>
      await import('./schedule/schedule.module').then((m) => m.ScheduleModule)
  },
  {
    path: 'team',
    loadChildren: async () => await import('./team/team.module').then((m) => m.TeamModule)
  },
  {
    path: '',
    component: HomeComponent
  },
  { path: '**', component: NotfoundComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
