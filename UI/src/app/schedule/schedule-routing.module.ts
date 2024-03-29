import { NgModule } from '@angular/core'
import { RouterModule, type Routes } from '@angular/router'
import { ScheduleHomeComponent } from './schedule-home/schedule-home.component'

const routes: Routes = [
  {
    path: '',
    component: ScheduleHomeComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ScheduleRoutingModule {}
